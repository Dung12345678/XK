
using System;
using System.Collections;
using IE.Facade;
using IE.Model;
namespace IE.Business
{

	
	public class ProductGroupBO : BaseBO
	{
		private ProductGroupFacade facade = ProductGroupFacade.Instance;
		protected static ProductGroupBO instance = new ProductGroupBO();

		protected ProductGroupBO()
		{
			this.baseFacade = facade;
		}

		public static ProductGroupBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	