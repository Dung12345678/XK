
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class LocationFacade : BaseFacade
	{
		protected static LocationFacade instance = new LocationFacade(new LocationModel());
		protected LocationFacade(LocationModel model) : base(model)
		{
		}
		public static LocationFacade Instance
		{
			get { return instance; }
		}
		protected LocationFacade():base() 
		{ 
		} 
	
	}
}
	