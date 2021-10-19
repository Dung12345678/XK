
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class PartOutDetailBO : BaseBO
	{
		private PartOutDetailFacade facade = PartOutDetailFacade.Instance;
		protected static PartOutDetailBO instance = new PartOutDetailBO();

		protected PartOutDetailBO()
		{
			this.baseFacade = facade;
		}

		public static PartOutDetailBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	