
using System;
using System.Collections;
using IE.Facade;
using IE.Model;
namespace IE.Business
{

	
	public class ProductTypeBO : BaseBO
	{
		private ProductTypeFacade facade = ProductTypeFacade.Instance;
		protected static ProductTypeBO instance = new ProductTypeBO();

		protected ProductTypeBO()
		{
			this.baseFacade = facade;
		}

		public static ProductTypeBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	