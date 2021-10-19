using System;
using IE.Utils;
using IE.Facade;
using IE.Exceptions;
using IE.Business;
using IE.Model;
namespace IE.Exceptions
{
	public class FacadeException : Exception
	{
		public FacadeException(String message) : base(message)
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public FacadeException(Exception e)
		{			
		}
	}
}