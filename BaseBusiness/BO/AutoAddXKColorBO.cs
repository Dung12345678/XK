
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class AutoAddXKColorBO : BaseBO
	{
		private AutoAddXKColorFacade facade = AutoAddXKColorFacade.Instance;
		protected static AutoAddXKColorBO instance = new AutoAddXKColorBO();

		protected AutoAddXKColorBO()
		{
			this.baseFacade = facade;
		}

		public static AutoAddXKColorBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	