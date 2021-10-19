
using System;
using System.Collections;
using IE.Facade;
using IE.Model;
namespace IE.Business
{

	
	public class ManufacturerBO : BaseBO
	{
		private ManufacturerFacade facade = ManufacturerFacade.Instance;
		protected static ManufacturerBO instance = new ManufacturerBO();

		protected ManufacturerBO()
		{
			this.baseFacade = facade;
		}

		public static ManufacturerBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	