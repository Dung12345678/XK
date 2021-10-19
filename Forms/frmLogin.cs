using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BMS
{
	public partial class frmLogin : Form
	{
		public frmLogin()
		{
			InitializeComponent();
		}

        public string _fullName = "";
        public bool Log(string U, string P, string code)
        {
            try
            {
                DataTable dt = TextUtils.LoadDataFromSP("getAuthenticationByIdGroupUser", "A", new string[] { "@username", "@password", "@code" }, new object[] { U, Utils.MD5.EncryptPassword(P), code });
                if ((dt != null) && (dt.Rows.Count > 0))
                {

                    _fullName = TextUtils.ToString(dt.Rows[0]["FullName"]);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Vadidate 
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (username == "" || password == "")
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập hoặc mật khẩu!", "Thông báo");
                return;
            }
            bool isLogin = Log(username, password, "N0005");
            if (!isLogin)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
