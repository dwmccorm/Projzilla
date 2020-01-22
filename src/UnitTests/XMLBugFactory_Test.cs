using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace UnitTests
{
    using ProjectBugzilla;
    using System.IO;
    using System.Collections;
    using System.Windows.Forms;

    [TestFixture]
    public class XMLBugFactory_Test
    {
        private BugDictionary list;
        private XMLBugFactory bugFactory;
        private Bug bug;

        /// <summary>
        /// 
        /// </summary>
        [SetUp]
        public void Init()
        {
            list = new BugDictionary();
            bugFactory = new XMLBugFactory();
            list = bugFactory.CreateBugs("..\\..\\artifacts\\BugFactoryBugs.xml");
            bug = list[71];
        }

        [Test]
        public void ActualTime()
        {
            Assert.AreEqual(bug.ActualTime, 3.33);
        }

        [Test]
        public void CreationTime()
        {
            Assert.AreEqual(bug.CreationDate, "2008-06-10 16:23");
        }

        [Test]
        public void Id()
        {
            Assert.AreEqual(bug.Id, 71);
        }

        [Test]
        public void Milestone()
        {
            Assert.AreEqual(bug.Milestone, "FUTURE");
        }

        [Test]
        public void OriginalTimeEstimate()
        {
            Assert.AreEqual(bug.OriginalTimeEstimate, 9.99);
        }

        [Test]
        public void Owner()
        {
            Assert.AreEqual(bug.Owner, "David McCormack");
        }

        [Test]
        public void Priority()
        {
            Assert.AreEqual(bug.Priority, "P3");
        }

        [Test]
        public void RemainingTime()
        {
            Assert.AreEqual(bug.RemainingTime, 6.66);
        }

        [Test]
        public void Severity()
        {
            Assert.AreEqual(bug.Severity, "normal");
        }

        [Test]
        public void Status()
        {
            Assert.AreEqual(bug.Status, "NEW");
        }

        [Test]
        public void Sumary()
        {
            Assert.AreEqual(bug.Summary, "Program crashes");
        }

        [Test]
        public void DependsOn()
        {
            Assert.AreEqual(bug.DependsOn.Count, 2);
            Assert.IsTrue(bug.DependsOn.Contains(72));
            Assert.IsTrue(bug.DependsOn.Contains(75));
        }

        [Test]
        public void Blocks()
        {
            Assert.AreEqual(bug.Blocks.Count, 2);
            Assert.IsTrue(bug.Blocks.Contains(73));
            Assert.IsTrue(bug.Blocks.Contains(74));
        }

        [Test]
        public void DependsOnAsString()
        {
            Assert.AreEqual(bug.DependsOnAsString(), "72, 75");
        }

        [Test]
        public void BlocksAsString()
        {
            Assert.AreEqual(bug.BlocksAsString(), "73, 74");
        }

        [Test]
        public void Product()
        {
            Assert.AreEqual(bug.Product, "MyProduct");
        }

        [Test]
        public void Component()
        {
            Assert.AreEqual(bug.Component, "MyComponent");
        }

        [Test]
        public void Version()
        {
            Assert.AreEqual(bug.Version, "0.7.1");
        }

        [Test]
        public void Reporter()
        {
            Assert.AreEqual(bug.Reporter, "david.mccormack@slpv2.org");
        }

        [Test]
        public void Platform()
        {
            Assert.AreEqual(bug.Platform, "All");
        }

        [Test]
        public void Keywords()
        {
            Assert.AreEqual(bug.Keywords, "MyKeywords");
        }

        [Test]
        public void OS()
        {
            Assert.AreEqual(bug.OS, "All");
        }

        [Test]
        public void QAContact()
        {
            Assert.AreEqual(bug.QAContact, "qa@slpv2.org");
        }
    }
}