
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class OrderPartFacade : BaseFacade
	{
		protected static OrderPartFacade instance = new OrderPartFacade(new OrderPartModel());
		protected OrderPartFacade(OrderPartModel model) : base(model)
		{
		}
		public static OrderPartFacade Instance
		{
			get { return instance; }
		}
		protected OrderPartFacade():base() 
		{ 
		} 
	
	}
}
	