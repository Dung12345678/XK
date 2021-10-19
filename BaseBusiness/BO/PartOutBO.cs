
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class PartOutBO : BaseBO
	{
		private PartOutFacade facade = PartOutFacade.Instance;
		protected static PartOutBO instance = new PartOutBO();

		protected PartOutBO()
		{
			this.baseFacade = facade;
		}

		public static PartOutBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	