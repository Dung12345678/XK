
using System;
using System.Collections;
using IE.Facade;
using IE.Model;
namespace IE.Business
{

	
	public class SupplierBO : BaseBO
	{
		private SupplierFacade facade = SupplierFacade.Instance;
		protected static SupplierBO instance = new SupplierBO();

		protected SupplierBO()
		{
			this.baseFacade = facade;
		}

		public static SupplierBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	