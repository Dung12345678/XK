
using System;
using System.Collections;
using IE.Facade;
using IE.Model;
namespace IE.Business
{
	
	public class ConfigFormulaAllBO : BaseBO
	{
		private ConfigFormulaAllFacade facade = ConfigFormulaAllFacade.Instance;
		protected static ConfigFormulaAllBO instance = new ConfigFormulaAllBO();

		protected ConfigFormulaAllBO()
		{
			this.baseFacade = facade;
		}

		public static ConfigFormulaAllBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	