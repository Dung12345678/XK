
using System;
using System.Collections;
using IE.Facade;
using IE.Model;
namespace IE.Business
{

	
	public class UserGroupBO : BaseBO
	{
		private UserGroupFacade facade = UserGroupFacade.Instance;
		protected static UserGroupBO instance = new UserGroupBO();

		protected UserGroupBO()
		{
			this.baseFacade = facade;
		}

		public static UserGroupBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	