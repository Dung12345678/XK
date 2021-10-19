
using System;
using System.Collections;
using IE.Facade;
using IE.Model;
namespace IE.Business
{
	
	public class ConfigShipToBO : BaseBO
	{
		private ConfigShipToFacade facade = ConfigShipToFacade.Instance;
		protected static ConfigShipToBO instance = new ConfigShipToBO();

		protected ConfigShipToBO()
		{
			this.baseFacade = facade;
		}

		public static ConfigShipToBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	