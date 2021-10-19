
using System;
using System.Collections;
using IE.Facade;
using IE.Model;
namespace IE.Business
{

	
	public class SettingStandardValueBO : BaseBO
	{
		private SettingStandardValueFacade facade = SettingStandardValueFacade.Instance;
		protected static SettingStandardValueBO instance = new SettingStandardValueBO();

		protected SettingStandardValueBO()
		{
			this.baseFacade = facade;
		}

		public static SettingStandardValueBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	