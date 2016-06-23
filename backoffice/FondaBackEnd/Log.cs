using System;
using log4net;

namespace com.ds201625.fonda.BackEnd.Log
{
	public class Log
	{
		private static readonly ILog _log = 
			LogManager.GetLogger("FondaBackend");

		public static ILog Logger
		{
			get { return _log; }
		}
	}
}

