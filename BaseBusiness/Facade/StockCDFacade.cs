
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class StockCDFacade : BaseFacade
	{
		protected static StockCDFacade instance = new StockCDFacade(new StockCDModel());
		protected StockCDFacade(StockCDModel model) : base(model)
		{
		}
		public static StockCDFacade Instance
		{
			get { return instance; }
		}
		protected StockCDFacade():base() 
		{ 
		} 
	
	}
}
	