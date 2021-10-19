
using System;
using System.Collections;
using IE.Facade;
using IE.Model;
namespace IE.Business
{

	
	public class UserGroupLinkBO : BaseBO
	{
		private UserGroupLinkFacade facade = UserGroupLinkFacade.Instance;
		protected static UserGroupLinkBO instance = new UserGroupLinkBO();

		protected UserGroupLinkBO()
		{
			this.baseFacade = facade;
		}

		public static UserGroupLinkBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	