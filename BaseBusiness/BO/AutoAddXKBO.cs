
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class AutoAddXKBO : BaseBO
	{
		private AutoAddXKFacade facade = AutoAddXKFacade.Instance;
		protected static AutoAddXKBO instance = new AutoAddXKBO();

		protected AutoAddXKBO()
		{
			this.baseFacade = facade;
		}

		public static AutoAddXKBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	