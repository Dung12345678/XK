
using System.Collections;
using IE.Model;
namespace IE.Facade
{
	
	public class SettingFFTFacade : BaseFacade
	{
		protected static SettingFFTFacade instance = new SettingFFTFacade(new SettingFFTModel());
		protected SettingFFTFacade(SettingFFTModel model) : base(model)
		{
		}
		public static SettingFFTFacade Instance
		{
			get { return instance; }
		}
		protected SettingFFTFacade():base() 
		{ 
		} 
	
	}
}
	