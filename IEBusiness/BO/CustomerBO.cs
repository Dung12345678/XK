
using System;
using System.Collections;
using IE.Facade;
using IE.Model;
namespace IE.Business
{

	
	public class CustomerBO : BaseBO
	{
		private CustomerFacade facade = CustomerFacade.Instance;
		protected static CustomerBO instance = new CustomerBO();

		protected CustomerBO()
		{
			this.baseFacade = facade;
		}

		public static CustomerBO Instance
		{
			get { return instance; }
		}
		
	    
	}
}
	