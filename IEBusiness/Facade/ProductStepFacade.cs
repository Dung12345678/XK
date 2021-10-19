
using System.Collections;
using IE.Model;
namespace IE.Facade
{
	
	public class ProductStepFacade : BaseFacade
	{
		protected static ProductStepFacade instance = new ProductStepFacade(new ProductStepModel());
		protected ProductStepFacade(ProductStepModel model) : base(model)
		{
		}
		public static ProductStepFacade Instance
		{
			get { return instance; }
		}
		protected ProductStepFacade():base() 
		{ 
		} 
	
	}
}
	