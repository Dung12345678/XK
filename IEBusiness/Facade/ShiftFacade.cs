
using System.Collections;
using IE.Model;
namespace IE.Facade
{
	
	public class ShiftFacade : BaseFacade
	{
		protected static ShiftFacade instance = new ShiftFacade(new ShiftModel());
		protected ShiftFacade(ShiftModel model) : base(model)
		{
		}
		public static ShiftFacade Instance
		{
			get { return instance; }
		}
		protected ShiftFacade():base() 
		{ 
		} 
	
	}
}
	