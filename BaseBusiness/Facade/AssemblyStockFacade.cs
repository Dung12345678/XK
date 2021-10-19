
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class AssemblyStockFacade : BaseFacade
	{
		protected static AssemblyStockFacade instance = new AssemblyStockFacade(new AssemblyStockModel());
		protected AssemblyStockFacade(AssemblyStockModel model) : base(model)
		{
		}
		public static AssemblyStockFacade Instance
		{
			get { return instance; }
		}
		protected AssemblyStockFacade():base() 
		{ 
		} 
	
	}
}
	