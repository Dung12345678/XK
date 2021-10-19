
using System;
using System.Collections;
using IE.Facade;
using IE.Model;
namespace IE.Business
{

	
	public class GearBO : BaseBO
	{
		private GearFacade facade = GearFacade.Instance;
		protected static GearBO instance = new GearBO();

		protected GearBO()
		{
			this.baseFacade = facade;
		}

		public static GearBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	