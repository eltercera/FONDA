using com.ds201625.fonda.Logic.FondaLogic.Commands.OrderAccount;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Tests.DataAccess
{
    [TestFixture]
    public class BOValidationsTest
    {
        CommandGetOrders compareCommand;
        Object parameter;
        Object compare;
        bool result;

        [SetUp]
        public void Init()
        {
            parameter = 1;
            compare = 1;
        }

        [Test(Description = "Prueba para testear la validación")]
        public void ValidateParameters()
        {
            CommandGetOrders cmdords = new CommandGetOrders(parameter);
            compareCommand = new CommandGetOrders(parameter);

            string t1 = cmdords.GetType().ToString();
            string t2 = compareCommand.GetType().ToString();


            Assert.AreEqual(result, true);
            Assert.AreEqual(cmdords.Receiver, compare);
            Assert.AreEqual(t1,t2);
        }

        [Test]
        public void CheckType()
        {
        }

    }
}
