
using System;
using System.Collections;
using IE.Facade;
using IE.Model;
namespace IE.Business
{
	
	public class UsersBO : BaseBO
	{
		private UsersFacade facade = UsersFacade.Instance;
		protected static UsersBO instance = new UsersBO();

		protected UsersBO()
		{
			this.baseFacade = facade;
		}

		public static UsersBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	