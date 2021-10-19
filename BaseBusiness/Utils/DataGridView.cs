using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace BMS
{

    public class DatagridView : DataGridView
    {
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            if (this.CurrentCell.IsInEditMode == true)
            {
                if (e.KeyCode == Keys.Up | e.KeyCode == Keys.Down | e.KeyCode == Keys.Left | e.KeyCode == Keys.Right)
                {
                    return false;
                }
            }
            return base.ProcessDataGridViewKey(e);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            //if (keyData.ToString().Trim() == "Tab, Shift")
            //{
            //    base.EndEdit();
            //    return true;
            //}
            //if ((keyData == Keys.Enter)||(keyData==Keys.Tab))
            //{
            //    base.EndEdit();
            //    return true;
            //}

            if (keyData == Keys.Tab)
            {
                base.EndEdit();
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }
    }
}
