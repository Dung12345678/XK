
using System.Collections;
using IE.Model;
namespace IE.Facade
{
	
	public class ProductionPlanFacade : BaseFacade
	{
		protected static ProductionPlanFacade instance = new ProductionPlanFacade(new ProductionPlanModel());
		protected ProductionPlanFacade(ProductionPlanModel model) : base(model)
		{
		}
		public static ProductionPlanFacade Instance
		{
			get { return instance; }
		}
		protected ProductionPlanFacade():base() 
		{ 
		} 
	
	}
}
	