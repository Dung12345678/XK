
using System.Collections;
using IE.Model;
namespace IE.Facade
{
	
	public class ProductWorkingAuditFacade : BaseFacade
	{
		protected static ProductWorkingAuditFacade instance = new ProductWorkingAuditFacade(new ProductWorkingAuditModel());
		protected ProductWorkingAuditFacade(ProductWorkingAuditModel model) : base(model)
		{
		}
		public static ProductWorkingAuditFacade Instance
		{
			get { return instance; }
		}
		protected ProductWorkingAuditFacade():base() 
		{ 
		} 
	
	}
}
	