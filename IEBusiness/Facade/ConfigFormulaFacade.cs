
using System.Collections;
using IE.Model;
namespace IE.Facade
{
	
	public class ConfigFormulaFacade : BaseFacade
	{
		protected static ConfigFormulaFacade instance = new ConfigFormulaFacade(new ConfigFormulaModel());
		protected ConfigFormulaFacade(ConfigFormulaModel model) : base(model)
		{
		}
		public static ConfigFormulaFacade Instance
		{
			get { return instance; }
		}
		protected ConfigFormulaFacade():base() 
		{ 
		} 
	
	}
}
	