
using System.Collections;
using IE.Model;
namespace IE.Facade
{
	
	public class TesttaFacade : BaseFacade
	{
		protected static TesttaFacade instance = new TesttaFacade(new TesttaModel());
		protected TesttaFacade(TesttaModel model) : base(model)
		{
		}
		public static TesttaFacade Instance
		{
			get { return instance; }
		}
		protected TesttaFacade():base() 
		{ 
		} 
	
	}
}
	