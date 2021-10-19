
using System;
using System.Collections;
using IE.Facade;
using IE.Model;
namespace IE.Business
{

	
	public class GearWorkingBO : BaseBO
	{
		private GearWorkingFacade facade = GearWorkingFacade.Instance;
		protected static GearWorkingBO instance = new GearWorkingBO();

		protected GearWorkingBO()
		{
			this.baseFacade = facade;
		}

		public static GearWorkingBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	