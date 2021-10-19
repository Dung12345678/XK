
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class AutoAddXKColorFacade : BaseFacade
	{
		protected static AutoAddXKColorFacade instance = new AutoAddXKColorFacade(new AutoAddXKColorModel());
		protected AutoAddXKColorFacade(AutoAddXKColorModel model) : base(model)
		{
		}
		public static AutoAddXKColorFacade Instance
		{
			get { return instance; }
		}
		protected AutoAddXKColorFacade():base() 
		{ 
		} 
	
	}
}
	