
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class OrderPartBO : BaseBO
	{
		private OrderPartFacade facade = OrderPartFacade.Instance;
		protected static OrderPartBO instance = new OrderPartBO();

		protected OrderPartBO()
		{
			this.baseFacade = facade;
		}

		public static OrderPartBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	