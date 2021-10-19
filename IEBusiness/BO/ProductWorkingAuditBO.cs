
using System;
using System.Collections;
using IE.Facade;
using IE.Model;
namespace IE.Business
{
	
	public class ProductWorkingAuditBO : BaseBO
	{
		private ProductWorkingAuditFacade facade = ProductWorkingAuditFacade.Instance;
		protected static ProductWorkingAuditBO instance = new ProductWorkingAuditBO();

		protected ProductWorkingAuditBO()
		{
			this.baseFacade = facade;
		}

		public static ProductWorkingAuditBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	