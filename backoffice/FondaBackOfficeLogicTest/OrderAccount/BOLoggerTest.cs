using FondaLogic.Log;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaBackOfficeLogicTest.OrderAccount
{
    public class BOLoggerTest
    {
        //private Logger _logger;
        private String _classe;
        private Exception e;
        [SetUp]
        public void Init()
        {
            _classe = "Invoice";
            //_logger = new Logger();
            e = new Exception();
            
        }

        [Test]
        public void WriteErrorLogTest()
        {

            Logger.WriteErrorLog(_classe, e);
            Logger.WriteSuccessLog(_classe, "Mensaje","Metodo");

        }
    }
}
