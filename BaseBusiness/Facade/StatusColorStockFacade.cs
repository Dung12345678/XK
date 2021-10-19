
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class StatusColorStockFacade : BaseFacade
	{
		protected static StatusColorStockFacade instance = new StatusColorStockFacade(new StatusColorStockModel());
		protected StatusColorStockFacade(StatusColorStockModel model) : base(model)
		{
		}
		public static StatusColorStockFacade Instance
		{
			get { return instance; }
		}
		protected StatusColorStockFacade():base() 
		{ 
		} 
	
	}
}
	