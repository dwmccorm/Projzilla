using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace UnitTests
{
    using ProjectBugzilla;

    [TestFixture]
    public class CLI_Test
    {
        /// <summary>
        /// 
        /// </summary>
        [SetUp]
        public void Init()
        {
            System.IO.Directory.SetCurrentDirectory("..\\..\\..\\ProjectBugzilla");
        }

        /// <summary>
        /// 
        /// </summary>
        ///
        [Test]
        public void NewProjectFromCommandLineInterface()
        {
            string[] args = { "-bugzillaxml", "..\\UnitTests\\artifacts\\single_bug.xml", "-newproject", "..\\UnitTests\\artifacts\\new_cli_Test_0.mpp" };

            MSProject simpleProj = new MSProject();
            simpleProj.CommandLineInterface(args);
            simpleProj = null;

            Assert.IsTrue(System.IO.File.Exists("..\\UnitTests\\artifacts\\new_cli_Test_0.mpp"));

            System.IO.File.Delete("..\\UnitTests\\artifacts\\new_cli_Test_0.mpp");
        }

        /// <summary>
        /// Need to put in a real test for this
        /// </summary>
        [Test]
        public void ExistingProjectFromCommandLineInterface()
        {
            string[] args = { "-bugzillaxml", "..\\UnitTests\\artifacts\\single_bug.xml", "-ExistingProject", "..\\UnitTests\\artifacts\\ExistingFileCLI_Test_0.mpp" };

            if (System.IO.File.Exists("..\\UnitTests\\artifacts\\ExistingFileCLI_Test_0.mpp"))
            {
                System.IO.File.Delete("..\\UnitTests\\artifacts\\ExistingFileCLI_Test_0.mpp");
            }
            System.IO.File.Copy("..\\UnitTests\\artifacts\\MSProject_Test_0.mpp", "..\\UnitTests\\artifacts\\ExistingFileCLI_Test_0.mpp");
            MSProject simpleProj = new MSProject();
            simpleProj.CommandLineInterface(args);
            simpleProj = null;

            Assert.IsTrue(System.IO.File.Exists("..\\UnitTests\\artifacts\\ExistingFileCLI_Test_0.mpp"));

            System.IO.File.Delete("..\\UnitTests\\artifacts\\ExistingFileCLI_Test_0.mpp");
        }
    }
}