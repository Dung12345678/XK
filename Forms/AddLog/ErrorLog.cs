using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMS
{
	class ErrorLog
	{
		/// <summary>
		/// Ghi ra 1 file Error.txt biết khi lỗi xảy ra 
		/// </summary>
		/// <param name="nd">Nội dung</param>
		/// <param name="line">dòng bị lỗi Environment.NewLine  catch (Exception ex)</param>
		public static void errorLog(string name, string nd, string line)
		{
			if (!File.Exists(Application.StartupPath + "/Error.txt"))
			{
				File.WriteAllText(Application.StartupPath + "/Error.txt", name + " " + nd + " " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + " " + line + "\r\n");
			}
			else
			{
				File.AppendAllText(Application.StartupPath + "/Error.txt", nd + " " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + " " + line + "\r\n");
			}
		}
		/// <summary>
		/// Đọc file Error.txt 
		/// </summary>
		/// <returns></returns>
		public static string readErrorLog()
		{
			if (File.Exists(Application.StartupPath + "/Error.txt"))
			{
				string Read = File.ReadAllText(Application.StartupPath + "/Error.txt");
				return Read;
			}
			else
				return "Không tìm thấy file Error";
		}
		/// <summary>
		/// Hiển thị ra consoler khi đag chạy chương trình
		/// </summary>
		/// <param name="x"></param>
		public static void ShowConsole(string x)
		{
			try
			{
				Console.WriteLine($"{x}");
			}
			catch
			{

			}
		}

	}
}
