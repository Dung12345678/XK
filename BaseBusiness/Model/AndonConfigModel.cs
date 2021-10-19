
using System;
namespace BMS.Model
{
	public class AndonConfigModel : BaseModel
	{
		private int iD;
		private decimal fontSize1;
		private decimal fontSize2;
		private decimal fontSize3;
		private decimal fontSize4;
		private decimal fontSize5;
		private int takt;
		private string tcpIp;
		private int socketPort;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public decimal FontSize1
		{
			get { return fontSize1; }
			set { fontSize1 = value; }
		}
	
		public decimal FontSize2
		{
			get { return fontSize2; }
			set { fontSize2 = value; }
		}
	
		public decimal FontSize3
		{
			get { return fontSize3; }
			set { fontSize3 = value; }
		}
	
		public decimal FontSize4
		{
			get { return fontSize4; }
			set { fontSize4 = value; }
		}
	
		public decimal FontSize5
		{
			get { return fontSize5; }
			set { fontSize5 = value; }
		}
	
		public int Takt
		{
			get { return takt; }
			set { takt = value; }
		}
	
		public string TcpIp
		{
			get { return tcpIp; }
			set { tcpIp = value; }
		}
	
		public int SocketPort
		{
			get { return socketPort; }
			set { socketPort = value; }
		}
	
	}
}
	