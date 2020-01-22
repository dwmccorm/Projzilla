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
    public class CSVBugFactory_Test
    {
        private BugDictionary list;
        private CSVBugFactory bugFactory;
        private Bug bug;

        /// <summary>
        /// 
        /// </summary>
        [SetUp]
        public void Init()
        {
        }

        [Test]
        public void Id()
        {
            list = new BugDictionary();
            bugFactory = new CSVBugFactory();
            list = bugFactory.CreateBugs("..\\..\\artifacts\\SimpleCSV.csv");
            bug = list[3];
            Assert.AreEqual(bug.Id, 3);
        }

        [Test]
        public void Severity()
        {
            list = new BugDictionary();
            bugFactory = new CSVBugFactory();
            list = bugFactory.CreateBugs("..\\..\\artifacts\\SimpleCSV.csv");
            bug = list[3];
            Assert.AreEqual(bug.Severity, "trivial");
        }

        [Test]
        public void Priority()
        {
            list = new BugDictionary();
            bugFactory = new CSVBugFactory();
            list = bugFactory.CreateBugs("..\\..\\artifacts\\SimpleCSV.csv");
            bug = list[3];
            Assert.AreEqual(bug.Priority, "P5");
        }

        [Test]
        public void OS()
        {
            list = new BugDictionary();
            bugFactory = new CSVBugFactory();
            list = bugFactory.CreateBugs("..\\..\\artifacts\\SimpleCSV.csv");
            bug = list[3];
            Assert.AreEqual(bug.OS, "All");
        }

        [Test]
        public void Owner()
        {
            list = new BugDictionary();
            bugFactory = new CSVBugFactory();
            list = bugFactory.CreateBugs("..\\..\\artifacts\\SimpleCSV.csv");
            bug = list[3];
            Assert.AreEqual(bug.Owner, "Fred Brooks");
        }

        [Test]
        public void Status()
        {
            list = new BugDictionary();
            bugFactory = new CSVBugFactory();
            list = bugFactory.CreateBugs("..\\..\\artifacts\\SimpleCSV.csv");
            bug = list[3];
            Assert.AreEqual(bug.Status, "NEW");
        }

        [Test]
        public void Summary()
        {
            list = new BugDictionary();
            bugFactory = new CSVBugFactory();
            list = bugFactory.CreateBugs("..\\..\\artifacts\\SimpleCSV.csv");
            bug = list[3];
            Assert.AreEqual(bug.Summary, "Missing period in dialog.");
        }

        [Test]
        public void OriginalTimeEstimate()
        {
            list = new BugDictionary();
            bugFactory = new CSVBugFactory();
            list = bugFactory.CreateBugs("..\\..\\artifacts\\SimpleCSV.csv");
            bug = list[3];
            Assert.AreEqual(bug.OriginalTimeEstimate, 4.00);
        }

        [Test]
        public void RemainingTime()
        {
            list = new BugDictionary();
            bugFactory = new CSVBugFactory();
            list = bugFactory.CreateBugs("..\\..\\artifacts\\SimpleCSV.csv");
            bug = list[3];
            Assert.AreEqual(bug.RemainingTime, 3.00);
        }

        [Test]
        public void ActualTime()
        {
            list = new BugDictionary();
            bugFactory = new CSVBugFactory();
            list = bugFactory.CreateBugs("..\\..\\artifacts\\SimpleCSV.csv");
            bug = list[3];
            Assert.AreEqual(bug.ActualTime, 1.00);
        }

        [Test]
        public void Milestone()
        {
            list = new BugDictionary();
            bugFactory = new CSVBugFactory();
            list = bugFactory.CreateBugs("..\\..\\artifacts\\SimpleCSV.csv");
            bug = list[3];
            Assert.AreEqual(bug.Milestone, "M1");
        }

        [Test]
        public void CreationTime()
        {
            list = new BugDictionary();
            bugFactory = new CSVBugFactory();
            list = bugFactory.CreateBugs("..\\..\\artifacts\\SimpleCSV.csv");
            bug = list[3];
            Assert.AreEqual(bug.CreationDate, "2009-09-08 20:44:04");
        }

        [Test]
        public void Platform()
        {
            list = new BugDictionary();
            bugFactory = new CSVBugFactory();
            list = bugFactory.CreateBugs("..\\..\\artifacts\\SimpleCSV.csv");
            bug = list[3];
            Assert.AreEqual(bug.Platform, "All");
        }

        [Test]
        public void Reporter()
        {
            list = new BugDictionary();
            bugFactory = new CSVBugFactory();
            list = bugFactory.CreateBugs("..\\..\\artifacts\\SimpleCSV.csv");
            bug = list[3];
            Assert.AreEqual(bug.Reporter, "david.mccormack@projzilla.com");
        }

        [Test]
        public void Product()
        {
            list = new BugDictionary();
            bugFactory = new CSVBugFactory();
            list = bugFactory.CreateBugs("..\\..\\artifacts\\SimpleCSV.csv");
            bug = list[3];
            Assert.AreEqual(bug.Product, "MyProduct");
        }

        [Test]
        public void Component()
        {
            list = new BugDictionary();
            bugFactory = new CSVBugFactory();
            list = bugFactory.CreateBugs("..\\..\\artifacts\\SimpleCSV.csv");
            bug = list[3];
            Assert.AreEqual(bug.Component, "BComponent");
        }

        [Test]
        public void Version()
        {
            list = new BugDictionary();
            bugFactory = new CSVBugFactory();
            list = bugFactory.CreateBugs("..\\..\\artifacts\\SimpleCSV.csv");
            bug = list[3];
            Assert.AreEqual(bug.Version, "1.0.0");
        }

        [Test]
        public void Keywords()
        {
            list = new BugDictionary();
            bugFactory = new CSVBugFactory();
            list = bugFactory.CreateBugs("..\\..\\artifacts\\SimpleCSV.csv");
            bug = list[3];
            Assert.AreEqual(bug.Keywords, "Keyword1");
        }

        [Test]
        public void NullRows()
        {
            list = new BugDictionary();
            bugFactory = new CSVBugFactory();
            list = bugFactory.CreateBugs("..\\..\\artifacts\\nullrows.csv");
            bug = list[61908];
            Assert.AreEqual(bug.Summary, "One-off full sync requests from tsconsole submit request screen");
            Assert.AreEqual(bug.CreationDate, "10/21/2009 2:56");
            Assert.AreEqual(bug.Id, 61908);
            Assert.AreEqual(bug.Severity, "normal");
            Assert.AreEqual(bug.Priority, "P2");
            Assert.AreEqual(bug.Platform, "enhancement");
            Assert.AreEqual(bug.Owner, "praveen@efrontier.com");
            Assert.AreEqual(bug.Status, "NEW");
            Assert.AreEqual(bug.Product, "Engineering");
            Assert.AreEqual(bug.Component, "Symprod");
            Assert.AreEqual(bug.Milestone, "9.11.1");
            Assert.AreEqual(bug.ActualTime, 0);
            Assert.AreEqual(bug.RemainingTime, 0);
            Assert.AreEqual(bug.OriginalTimeEstimate, 0);
        }

        [Test]
        public void HardData()
        {
            list = new BugDictionary();
            bugFactory = new CSVBugFactory();
            list = bugFactory.CreateBugs("..\\..\\artifacts\\HardCSV.csv");
            bug = list[9];
            Assert.AreEqual(bug.Id, 9);
            Assert.AreEqual(bug.Version, "1.0.0");
            Assert.AreEqual(bug.Keywords, "Keyword1, Keyword2");
            Assert.AreEqual(bug.Component, "AComponent");
            Assert.AreEqual(bug.Product, "MyProduct");
            Assert.AreEqual(bug.Reporter, "david.mccormack@projzilla.com");
            Assert.AreEqual(bug.Platform, "Other");
            Assert.AreEqual(bug.CreationDate, "2009-10-26 10:32:22");
            Assert.AreEqual(bug.Milestone, "M1");
            Assert.AreEqual(bug.ActualTime, 0);
            Assert.AreEqual(bug.RemainingTime, 0);
            Assert.AreEqual(bug.OriginalTimeEstimate, 0);
            Assert.AreEqual(bug.Summary, "A bad summary, \"\" containing, \" \".");
            Assert.AreEqual(bug.Status, "NEW");
            Assert.AreEqual(bug.Owner, "Donald E. Knuth");
            Assert.AreEqual(bug.OS, "Mac OS");
            Assert.AreEqual(bug.Priority, "P2");
            Assert.AreEqual(bug.Severity, "normal");
        }

    }
}