
using System.Collections;
using IE.Model;
namespace IE.Facade
{
	
	public class ProductFacade : BaseFacade
	{
		protected static ProductFacade instance = new ProductFacade(new ProductModel());
		protected ProductFacade(ProductModel model) : base(model)
		{
		}
		public static ProductFacade Instance
		{
			get { return instance; }
		}
		protected ProductFacade():base() 
		{ 
		} 
	
	}
}
	