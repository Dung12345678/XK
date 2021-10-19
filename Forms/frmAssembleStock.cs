using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMS
{
    public partial class frmAssembleStock : Form
    {
        DataTable dtAssemblyStock;
        public frmAssembleStock()
        {
            InitializeComponent();
        }
        private void frmAssembleStock_Load(object sender, EventArgs e)
        {
            loadStock();
        }

        private void loadStock()
        {
            DataTable dt = TextUtils.Select("SELECT ID,Name FROM dbo.AssemblyStock");
            DataRow r = dt.NewRow();
            r["ID"] = 0;
            r["Name"] = "";
            dt.Rows.InsertAt(r, 0);
            cboAssembleStock.DataSource = dt;
            cboAssembleStock.DisplayMember = "Name";
            cboAssembleStock.ValueMember = "ID";
        }

        private void frmAssembleStock_SizeChanged(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 247;
        }

        private void txtOrderAssembleStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            loadOrderAssembleStockDataTable(txtOrderAssembleStock.Text.Trim());
        }

        async void loadOrderAssembleStockDataTable(string order)
        {
            Task task = Task.Factory.StartNew(() =>
            {
                string sql = $"select * from dbo.ProductionPlan Where OrderCode='{order}' order by ID desc";
                dtAssemblyStock = TextUtils.Select(sql);
                this.Invoke(new MethodInvoker(delegate ()
                {
                    txtQtyAssembleStock.Text =TextUtils.ToString( dtAssemblyStock.Rows[0]["Qty"]);
                    txtTargetAssembleStock.Text = TextUtils.ToString(dtAssemblyStock.Rows[0]["ShipTo"]);
                    grdData.DataSource = dtAssemblyStock;
                }));
            });
            await task;
        }
    }
}
