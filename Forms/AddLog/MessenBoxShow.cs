using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMS
{
	class MessageBoxShows
	{
		/// <summary>
		/// Cảnh báo Warning
		/// </summary>
		/// <param name="text"></param>
		/// <param name="caption"></param>
		public static void MessageBoxWarning(string text, string caption)
		{
			MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
		/// <summary>
		/// Báo lỗi
		/// </summary>
		/// <param name="text"></param>
		/// <param name="caption"></param>
		public static void MessageBoxError(string text, string caption)
		{
			MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		/// <summary>
		/// Hỏi muốn làm gì hay k
		/// </summary>
		/// <param name="text"></param>
		/// <param name="caption"></param>
		public static bool MessageBoxQuestion(string text, string caption)
		{
			DialogResult result = MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.No)
				return false;
			else
				return true;
		}
	}
}
