
using System;
using System.Collections;
using IE.Facade;
using IE.Model;
namespace IE.Business
{

	
	public class FormAndFunctionGroupBO : BaseBO
	{
		private FormAndFunctionGroupFacade facade = FormAndFunctionGroupFacade.Instance;
		protected static FormAndFunctionGroupBO instance = new FormAndFunctionGroupBO();

		protected FormAndFunctionGroupBO()
		{
			this.baseFacade = facade;
		}

		public static FormAndFunctionGroupBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	