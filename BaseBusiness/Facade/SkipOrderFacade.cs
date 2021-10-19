
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class SkipOrderFacade : BaseFacade
	{
		protected static SkipOrderFacade instance = new SkipOrderFacade(new SkipOrderModel());
		protected SkipOrderFacade(SkipOrderModel model) : base(model)
		{
		}
		public static SkipOrderFacade Instance
		{
			get { return instance; }
		}
		protected SkipOrderFacade():base() 
		{ 
		} 
	
	}
}
	