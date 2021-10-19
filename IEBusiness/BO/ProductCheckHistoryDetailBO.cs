
using System;
using System.Collections;
using IE.Facade;
using IE.Model;
namespace IE.Business
{

	
	public class ProductCheckHistoryDetailBO : BaseBO
	{
		private ProductCheckHistoryDetailFacade facade = ProductCheckHistoryDetailFacade.Instance;
		protected static ProductCheckHistoryDetailBO instance = new ProductCheckHistoryDetailBO();

		protected ProductCheckHistoryDetailBO()
		{
			this.baseFacade = facade;
		}

		public static ProductCheckHistoryDetailBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	