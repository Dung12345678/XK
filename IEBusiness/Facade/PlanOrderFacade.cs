
using System.Collections;
using IE.Model;
namespace IE.Facade
{
	
	public class PlanOrderFacade : BaseFacade
	{
		protected static PlanOrderFacade instance = new PlanOrderFacade(new PlanOrderModel());
		protected PlanOrderFacade(PlanOrderModel model) : base(model)
		{
		}
		public static PlanOrderFacade Instance
		{
			get { return instance; }
		}
		protected PlanOrderFacade():base() 
		{ 
		} 
	
	}
}
	