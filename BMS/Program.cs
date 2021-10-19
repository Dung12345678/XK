using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.VisualBasic.ApplicationServices;
using System.Security.AccessControl;
using System.IO;
using DevExpress.XtraGrid.Localization;

namespace BMS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static List<int> RequestIDList = new List<int>();
        private static Mutex mutex = null;
        [STAThread]       
        static void Main(string[] args)
        {
            //const string appName = "PMLine";
            //bool createdNew;
            //mutex = new Mutex(true, appName, out createdNew);
            //if (!createdNew)
            //{
            //    MessageBox.Show("App is already running! Exiting the application", "Warning", MessageBoxButtons.OK);
            //    //app is already running! Exiting the application  
            //    return;
            //}
            //Application.EnableVisualStyles();

            //GridLocalizer.Active = new NVGridLocalizer();
            //Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new frmXK());
            //Application.Run(new ProductCheckHistory());
        }
        static bool SetAccessRule()
        {
            FileSystemRights pRights = (FileSystemRights)0;
            pRights = FileSystemRights.FullControl;

            // [HocPD]: Add Access Rule to the actual directory itself
            FileSystemAccessRule pAccessRule = new FileSystemAccessRule("Users", pRights,
                                        InheritanceFlags.None,
                                        PropagationFlags.NoPropagateInherit,
                                        AccessControlType.Allow);

            DirectoryInfo pInfo = new DirectoryInfo(Application.StartupPath);
            DirectorySecurity pSecurity = pInfo.GetAccessControl(AccessControlSections.Access);

            bool pResult = false;
            pSecurity.ModifyAccessRule(AccessControlModification.Set, pAccessRule, out pResult);

            if (!pResult)
                return false;

            // [HocPD]: Always allow objects to inherit on a directory
            InheritanceFlags iFlags = InheritanceFlags.ObjectInherit;
            iFlags = InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit;

            // [HocPD]: Add Access rule for the inheritance
            pAccessRule = new FileSystemAccessRule("Users", pRights,
                                        iFlags,
                                        PropagationFlags.InheritOnly,
                                        AccessControlType.Allow);
            pResult = false;
            pSecurity.ModifyAccessRule(AccessControlModification.Add, pAccessRule, out pResult);

            if (!pResult)
                return false;

            pInfo.SetAccessControl(pSecurity);

            return true;
        }
    }
}