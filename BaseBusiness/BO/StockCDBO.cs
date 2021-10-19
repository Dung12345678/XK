
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class StockCDBO : BaseBO
	{
		private StockCDFacade facade = StockCDFacade.Instance;
		protected static StockCDBO instance = new StockCDBO();

		protected StockCDBO()
		{
			this.baseFacade = facade;
		}

		public static StockCDBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	