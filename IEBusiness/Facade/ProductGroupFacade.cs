
using System.Collections;
using IE.Model;
namespace IE.Facade
{
	
	public class ProductGroupFacade : BaseFacade
	{
		protected static ProductGroupFacade instance = new ProductGroupFacade(new ProductGroupModel());
		protected ProductGroupFacade(ProductGroupModel model) : base(model)
		{
		}
		public static ProductGroupFacade Instance
		{
			get { return instance; }
		}
		protected ProductGroupFacade():base() 
		{ 
		} 
	
	}
}
	