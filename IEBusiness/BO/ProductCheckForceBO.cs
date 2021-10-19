
using System;
using System.Collections;
using IE.Facade;
using IE.Model;
namespace IE.Business
{

	
	public class ProductCheckForceBO : BaseBO
	{
		private ProductCheckForceFacade facade = ProductCheckForceFacade.Instance;
		protected static ProductCheckForceBO instance = new ProductCheckForceBO();

		protected ProductCheckForceBO()
		{
			this.baseFacade = facade;
		}

		public static ProductCheckForceBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	