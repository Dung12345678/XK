
using System.Collections;
using IE.Model;
namespace IE.Facade
{
	
	public class ProductTypeFacade : BaseFacade
	{
		protected static ProductTypeFacade instance = new ProductTypeFacade(new ProductTypeModel());
		protected ProductTypeFacade(ProductTypeModel model) : base(model)
		{
		}
		public static ProductTypeFacade Instance
		{
			get { return instance; }
		}
		protected ProductTypeFacade():base() 
		{ 
		} 
	
	}
}
	