
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class HistoryShelfMotorBO : BaseBO
	{
		private HistoryShelfMotorFacade facade = HistoryShelfMotorFacade.Instance;
		protected static HistoryShelfMotorBO instance = new HistoryShelfMotorBO();

		protected HistoryShelfMotorBO()
		{
			this.baseFacade = facade;
		}

		public static HistoryShelfMotorBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	