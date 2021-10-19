
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class SonPlanFacade : BaseFacade
	{
		protected static SonPlanFacade instance = new SonPlanFacade(new SonPlanModel());
		protected SonPlanFacade(SonPlanModel model) : base(model)
		{
		}
		public static SonPlanFacade Instance
		{
			get { return instance; }
		}
		protected SonPlanFacade():base() 
		{ 
		} 
	
	}
}
	