
using System.Collections;
using IE.Model;
namespace IE.Facade
{
	
	public class SettingRatioRoundFacade : BaseFacade
	{
		protected static SettingRatioRoundFacade instance = new SettingRatioRoundFacade(new SettingRatioRoundModel());
		protected SettingRatioRoundFacade(SettingRatioRoundModel model) : base(model)
		{
		}
		public static SettingRatioRoundFacade Instance
		{
			get { return instance; }
		}
		protected SettingRatioRoundFacade():base() 
		{ 
		} 
	
	}
}
	