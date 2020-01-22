using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace UnitTests
{
    using ProjectBugzilla;

    [TestFixture]
    public class Bug_Test
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
        public void Id()
        {
            Bug bug = new Bug();
            bug.Id = 32769;
            Assert.AreEqual(bug.Id, 32769, "Expected Failure.");
        }
    }
}