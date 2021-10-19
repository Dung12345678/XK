
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class SkipOrderBO : BaseBO
	{
		private SkipOrderFacade facade = SkipOrderFacade.Instance;
		protected static SkipOrderBO instance = new SkipOrderBO();

		protected SkipOrderBO()
		{
			this.baseFacade = facade;
		}

		public static SkipOrderBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	