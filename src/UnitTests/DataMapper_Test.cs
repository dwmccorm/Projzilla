using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace UnitTests
{
    using ProjectBugzilla;

    [TestFixture]
    public class DataMapper_Test
    {
        /// <summary>
        /// 
        /// </summary>
        [SetUp]
        public void Init()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        ///
        [Test]
        public void GetElement()
        {
            DataMapper map = new DataMapper("..\\..\\artifacts\\DataMapping_Test_0.xml", "map");
            map.Reload();
            Assert.AreEqual(map["Id"], "Number1");
        }

        /// <summary>
        /// 
        /// </summary>
        ///
        [Test]
        public void MultipleGetElement()
        {
            DataMapper map = new DataMapper("..\\..\\artifacts\\DataMapping_Test_0.xml", "map");
            map.Reload();
            Assert.AreEqual(map["Id"], "Number1");
            Assert.AreEqual(map["Summary"], "Name");
        }

        /// <summary>
        /// 
        /// </summary>
        ///
        [Test]
        public void MissingElement()
        {
            DataMapper map = new DataMapper("..\\..\\artifacts\\DataMapping_Test_0.xml", "map");
            map.Reload();
            try
            {
                string str = map["asdfasfsadfdsafasdf"];
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
                return;
            }
            Assert.IsTrue(false);
        }

        [Test]
        public void Priority()
        {
            DataMapper map = new DataMapper("..\\..\\artifacts\\DataMapping_Text_1.xml", "map-priority");
            map.Reload();
            Assert.AreEqual(map["P1"], "900");
            Assert.AreEqual(map["P2"], "700");
            Assert.AreEqual(map["P3"], "500");
            Assert.AreEqual(map["P4"], "300");
            Assert.AreEqual(map["P5"], "100");
        }
    }
}