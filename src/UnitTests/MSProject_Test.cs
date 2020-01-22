using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop.MSProject;
using NUnit.Framework;

namespace UnitTests
{
    using ProjectBugzilla;
    using System.IO;
    using System.Collections;

    [TestFixture]
    public class MSProject_Test
    {
        private MSProject simpleProj;

        #region Init
        /// <summary>
        /// 
        /// </summary>
        [SetUp]
        public void Init()
        {
            System.IO.Directory.SetCurrentDirectory("..\\..\\..\\ProjectBugzilla");            
        }
        #endregion

        #region SimpleProjectInit
        /// <summary>
        /// INits the project for simple testing.
        /// </summary>
        private void SimpleProjectInit()
        {
            simpleProj = new MSProject();
            simpleProj.SaveProjectFilePath = "..\\UnitTests\\artifacts\\MSProject_Test_0.mpp";
            // We need to start with a blank file to begin with
            string path = Config.GetUser("BlankProjectFile");
            if (false == System.IO.Path.IsPathRooted(path))
                path = System.IO.Directory.GetCurrentDirectory() + "\\" + path;
            simpleProj.LoadProjectFilePath = path;
            simpleProj.InputPath = "..\\UnitTests\\artifacts\\single_bug.xml";
            simpleProj.InputType = InputDataFormat.BugzillaXML;
        }
        #endregion

        #region SimpleProjectClose
        /// <summary>
        /// Stops the simple project
        /// </summary>
        private void SimpleProjectClose()
        {
            simpleProj.Close();
        }
        #endregion

        #region CheckToSeeIfProjectIsAlreadyRunning
        /// <summary>
        /// This will check to see if project is already running.
        /// </summary>
        [Test]
        public void CheckToSeeIfProjectIsAlreadyRunning()
        {
            Assert.IsFalse(MSProject.IsProjectAlreadyRunning());

            SimpleProjectInit();
            simpleProj.LoadMPP();
            Assert.IsTrue(MSProject.IsProjectAlreadyRunning());

            SimpleProjectClose();
            simpleProj = null;
            Assert.IsFalse(MSProject.IsProjectAlreadyRunning());
        }
        #endregion

        #region CreateSingleProjectTaskFromXML
        /// <summary>
        /// 
        /// </summary>
        ///
        [Test]
        public void CreateSingleProjectTaskFromXML()
        {
            SimpleProjectInit();
            simpleProj.LoadMPP();
            simpleProj.Update();

            foreach (Task task in simpleProj.Project.Tasks)
            {
                if (task.Number1 == 71)
                {
                    Assert.AreEqual(String.Compare(task.Name, "Program crashes"), 0);
                    Assert.AreEqual(task.Number1, 71);
                    Assert.AreEqual(task.Priority, 500);
                    Assert.AreEqual(String.Compare(task.Text1, "FUTURE"), 0);
                    Assert.AreEqual(String.Compare(task.ResourceNames, "David McCormack"), 0);
                }
            }
            SimpleProjectClose();
            simpleProj = null;
        }
        #endregion

        #region TestReflectionMagic
        /// <summary>
        /// 
        /// </summary>
        ///
        [Test]
        public void TestReflectionMagic()
        {
            simpleProj = new MSProject("..\\UnitTests\\artifacts\\DataMapping_Text_1.xml");
            simpleProj.LoadProjectFilePath = "..\\UnitTests\\artifacts\\MSProject_Test_0.mpp";
            simpleProj.InputPath = "..\\UnitTests\\artifacts\\single_bug.xml";
            simpleProj.InputType = InputDataFormat.BugzillaXML;
            simpleProj.SaveProjectFilePath = "..\\UnitTests\\artifacts\\MSProject_Test_0.mpp";
            simpleProj.LoadMPP();
            simpleProj.Update();

            foreach (Task task in simpleProj.Project.Tasks)
            {
                if (task.Number1 == 71)
                {
                    Assert.AreEqual(String.Compare(task.ResourceNames, "David McCormack"), 0);
                    Assert.AreEqual(String.Compare(task.Text1, "FUTURE"), 0);
                    Assert.AreEqual(String.Compare(task.Name, "Program crashes"), 0);
                    Assert.AreEqual(task.Number1, 71);
                    Assert.AreEqual(String.Compare(task.Text2, "NEW"), 0);
                    Assert.AreEqual(String.Compare(task.Text4, "normal"), 0);
                    Assert.AreEqual(task.Priority, 500);
                    Assert.AreEqual(String.Compare(task.Text1, "FUTURE"), 0);
                }
            }
            SimpleProjectClose();
            simpleProj = null;
        }
        #endregion

        #region TestDependsOn
        /// <summary>
        /// 
        /// </summary>
        ///
        [Test]
        public void TestDependsOn()
        {
            simpleProj = new MSProject("..\\UnitTests\\artifacts\\DataMapping_Text_1.xml");
            simpleProj.LoadProjectFilePath = "..\\UnitTests\\artifacts\\MSProject_Test_0.mpp";
            simpleProj.SaveProjectFilePath = "..\\UnitTests\\artifacts\\MSProject_Test_0.mpp";
            simpleProj.InputPath = "..\\UnitTests\\artifacts\\two_bugs.xml";
            simpleProj.InputType = InputDataFormat.BugzillaXML;
            simpleProj.LoadMPP();
            simpleProj.Update();

            foreach (Task task in simpleProj.Project.Tasks)
            {
                if (task.Number1 == 14963)
                {
                    Console.WriteLine(task.Predecessors);
                    Assert.IsTrue(task.Predecessors.Contains("6"));
                    Assert.IsTrue(task.Predecessors.Contains("4"));
                    Assert.IsTrue(task.Predecessors.Contains("3"));
                    break;
                }
            }
            SimpleProjectClose();
            simpleProj = null;
        }
        #endregion

        #region SimpleSave
        [Test]
        public void SimpleSave()
        {
            System.Console.WriteLine(System.IO.Directory.GetCurrentDirectory());
            System.Console.WriteLine(System.IO.Path.GetFullPath(System.IO.Directory.GetCurrentDirectory() + "..\\..\\UnitTests\\artifacts\\MSProject_Test_Save.mpp"));

            String fileName = System.IO.Path.GetFullPath(System.IO.Directory.GetCurrentDirectory() + "..\\..\\UnitTests\\artifacts\\MSProject_Test_Save.mpp");
            SimpleProjectInit();
            simpleProj.LoadMPP();
            simpleProj.SaveProjectFilePath = fileName;

            // Delete the file which we will try to write to
            File.Delete(simpleProj.SaveProjectFilePath);
            simpleProj.SaveMPP();
            Assert.IsTrue(File.Exists(simpleProj.SaveProjectFilePath));
            SimpleProjectClose();
            File.Delete(fileName);
            simpleProj = null;
        }
        #endregion

        #region Done
        [TearDown]
        public void Done()
        {

        }
        #endregion
    }
}