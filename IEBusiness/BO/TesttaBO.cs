
using System;
using System.Collections;
using IE.Facade;
using IE.Model;
namespace IE.Business
{

	
	public class TesttaBO : BaseBO
	{
		private TesttaFacade facade = TesttaFacade.Instance;
		protected static TesttaBO instance = new TesttaBO();

		protected TesttaBO()
		{
			this.baseFacade = facade;
		}

		public static TesttaBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	