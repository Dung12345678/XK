
using System.Collections;
using IE.Model;
namespace IE.Facade
{
	
	public class UserGroupFacade : BaseFacade
	{
		protected static UserGroupFacade instance = new UserGroupFacade(new UserGroupModel());
		protected UserGroupFacade(UserGroupModel model) : base(model)
		{
		}
		public static UserGroupFacade Instance
		{
			get { return instance; }
		}
		protected UserGroupFacade():base() 
		{ 
		} 
	
	}
}
	