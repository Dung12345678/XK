
using System;
using System.Collections;
using IE.Facade;
using IE.Model;
namespace IE.Business
{

	
	public class CompanyBO : BaseBO
	{
		private CompanyFacade facade = CompanyFacade.Instance;
		protected static CompanyBO instance = new CompanyBO();

		protected CompanyBO()
		{
			this.baseFacade = facade;
		}

		public static CompanyBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	