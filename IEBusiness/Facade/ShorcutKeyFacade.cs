
using System.Collections;
using IE.Model;
namespace IE.Facade
{
	
	public class ShorcutKeyFacade : BaseFacade
	{
		protected static ShorcutKeyFacade instance = new ShorcutKeyFacade(new ShorcutKeyModel());
		protected ShorcutKeyFacade(ShorcutKeyModel model) : base(model)
		{
		}
		public static ShorcutKeyFacade Instance
		{
			get { return instance; }
		}
		protected ShorcutKeyFacade():base() 
		{ 
		} 
	
	}
}
	