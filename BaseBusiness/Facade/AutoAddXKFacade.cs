
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class AutoAddXKFacade : BaseFacade
	{
		protected static AutoAddXKFacade instance = new AutoAddXKFacade(new AutoAddXKModel());
		protected AutoAddXKFacade(AutoAddXKModel model) : base(model)
		{
		}
		public static AutoAddXKFacade Instance
		{
			get { return instance; }
		}
		protected AutoAddXKFacade():base() 
		{ 
		} 
	
	}
}
	