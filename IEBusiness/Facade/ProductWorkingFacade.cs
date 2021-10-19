
using System.Collections;
using IE.Model;
namespace IE.Facade
{
	
	public class ProductWorkingFacade : BaseFacade
	{
		protected static ProductWorkingFacade instance = new ProductWorkingFacade(new ProductWorkingModel());
		protected ProductWorkingFacade(ProductWorkingModel model) : base(model)
		{
		}
		public static ProductWorkingFacade Instance
		{
			get { return instance; }
		}
		protected ProductWorkingFacade():base() 
		{ 
		} 
	
	}
}
	