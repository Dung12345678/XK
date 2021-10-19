
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class StatusColorStockBO : BaseBO
	{
		private StatusColorStockFacade facade = StatusColorStockFacade.Instance;
		protected static StatusColorStockBO instance = new StatusColorStockBO();

		protected StatusColorStockBO()
		{
			this.baseFacade = facade;
		}

		public static StatusColorStockBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	