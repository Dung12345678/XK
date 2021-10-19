
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class PartOutFacade : BaseFacade
	{
		protected static PartOutFacade instance = new PartOutFacade(new PartOutModel());
		protected PartOutFacade(PartOutModel model) : base(model)
		{
		}
		public static PartOutFacade Instance
		{
			get { return instance; }
		}
		protected PartOutFacade():base() 
		{ 
		} 
	
	}
}
	