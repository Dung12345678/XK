
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class PartOutDetailFacade : BaseFacade
	{
		protected static PartOutDetailFacade instance = new PartOutDetailFacade(new PartOutDetailModel());
		protected PartOutDetailFacade(PartOutDetailModel model) : base(model)
		{
		}
		public static PartOutDetailFacade Instance
		{
			get { return instance; }
		}
		protected PartOutDetailFacade():base() 
		{ 
		} 
	
	}
}
	