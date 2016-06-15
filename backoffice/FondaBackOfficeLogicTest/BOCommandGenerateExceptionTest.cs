using FondaLogic;
using FondaLogic.Factory;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaBackOfficeLogicTest
{
    [TestFixture()]
    public class BOCommandGenerateExceptionTest 
    {
        Command _commandGenerateException;

        [SetUp]
        public void Init()
        {
            _commandGenerateException = CommandFactory.GetCommandGenerateException();
        }

        [Test]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionByZeroExceptionTest()
        {
            _commandGenerateException.Execute();

        }

    }
}
