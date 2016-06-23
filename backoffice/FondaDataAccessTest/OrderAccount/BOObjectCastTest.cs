using com.ds201625.fonda.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Tests.DataAccess
{
    [TestFixture()]
    public class BOObjectCastTest
    {
        int nA1, nA2, nD1, nD2;
        Zone z;
        Object o;
        IList<int> listN, listD;

        [SetUp]
        public void Init()
        {
            z = new Zone();
            listN = new List<int>();

            z.Id = 1;
            z.Name = "Caracas";
            nA1 = 1;
            nA2 = 2;
            listN.Add(nA1);
            listN.Add(nA2);
        }

        [Test]
        public void CastObjectToEntity()
        {
            Object o = z;

            z = (Zone)o;

            Assert.AreEqual(z.Id, 1);
            Assert.AreEqual(z.Name, "Caracas");

        }

        [Test]
        public void CastObjectToCollection()
        {
            Object o = listN;

            listD = (IList<int>)o;

            nD1 = listD[0];
            nD2 = listD[1];

            Assert.AreEqual(nA1, nD1);
            Assert.AreEqual(nA2, nD2);

        }
    }
}
