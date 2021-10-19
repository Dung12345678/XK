
using System.Collections;
using IE.Model;
namespace IE.Facade
{
	
	public class SettingStandardValueFacade : BaseFacade
	{
		protected static SettingStandardValueFacade instance = new SettingStandardValueFacade(new SettingStandardValueModel());
		protected SettingStandardValueFacade(SettingStandardValueModel model) : base(model)
		{
		}
		public static SettingStandardValueFacade Instance
		{
			get { return instance; }
		}
		protected SettingStandardValueFacade():base() 
		{ 
		} 
	
	}
}
	