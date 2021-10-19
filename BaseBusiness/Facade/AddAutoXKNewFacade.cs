
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class AddAutoXKNewFacade : BaseFacade
	{
		protected static AddAutoXKNewFacade instance = new AddAutoXKNewFacade(new AddAutoXKNewModel());
		protected AddAutoXKNewFacade(AddAutoXKNewModel model) : base(model)
		{
		}
		public static AddAutoXKNewFacade Instance
		{
			get { return instance; }
		}
		protected AddAutoXKNewFacade():base() 
		{ 
		} 
	
	}
}
	