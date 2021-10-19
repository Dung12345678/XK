
using System;
using System.Collections;
using IE.Facade;
using IE.Model;
namespace IE.Business
{
	
	public class ProductionPlanBO : BaseBO
	{
		private ProductionPlanFacade facade = ProductionPlanFacade.Instance;
		protected static ProductionPlanBO instance = new ProductionPlanBO();

		protected ProductionPlanBO()
		{
			this.baseFacade = facade;
		}

		public static ProductionPlanBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	