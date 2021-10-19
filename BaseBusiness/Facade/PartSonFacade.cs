
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class PartSonFacade : BaseFacade
	{
		protected static PartSonFacade instance = new PartSonFacade(new PartSonModel());
		protected PartSonFacade(PartSonModel model) : base(model)
		{
		}
		public static PartSonFacade Instance
		{
			get { return instance; }
		}
		protected PartSonFacade():base() 
		{ 
		} 
	
	}
}
	