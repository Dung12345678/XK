
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class AssemblyStockBO : BaseBO
	{
		private AssemblyStockFacade facade = AssemblyStockFacade.Instance;
		protected static AssemblyStockBO instance = new AssemblyStockBO();

		protected AssemblyStockBO()
		{
			this.baseFacade = facade;
		}

		public static AssemblyStockBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	