using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ProjectBugzilla;
using Microsoft.Win32;

namespace UnitTests
{
    using ProjectBugzilla;

    [TestFixture]
    public class License_Test
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
        public void Load()
        {
            Flex lic = new Flex("..\\..\\artifacts\\testlic.xml");
            Assert.AreEqual(lic.Company, "Projzilla");
            Assert.AreEqual(lic.Name, "David McCormack");
            Assert.AreEqual(lic.Email, "david.mccormack@projzilla.com");
        }

        [Test]
        public void ValidTrial()
        {
            Flex lic = new Flex();
            RegistryKey myKey;

            myKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\f7a6c899-2eef-4d98-9191-6af69f5990ed", true);

            if (null != myKey)
            {
                myKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
                myKey.DeleteSubKey("f7a6c899-2eef-4d98-9191-6af69f5990ed");
            }

            myKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\f7a6c899-2eef-4d98-9191-6af69f5990ed");
            DateTime exp = System.DateTime.Now;
            exp = exp.AddDays(3);
            myKey.SetValue("Install", exp.ToString());

            Assert.IsTrue(lic.IsTrialLicense());
        }

        [Test]
        public void ValidFreshTrial()
        {
            Flex lic = new Flex();
            RegistryKey myKey;

            myKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\f7a6c899-2eef-4d98-9191-6af69f5990ed", true);

            if (null != myKey)
            {
                myKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
                myKey.DeleteSubKey("f7a6c899-2eef-4d98-9191-6af69f5990ed");
            }

            Assert.IsTrue(lic.IsTrialLicense());
        }

        [Test]
        public void InvalidTrial()
        {
            Flex lic = new Flex();
            RegistryKey myKey;

            myKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\f7a6c899-2eef-4d98-9191-6af69f5990ed", true);

            if (null != myKey)
            {
                myKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
                myKey.DeleteSubKey("f7a6c899-2eef-4d98-9191-6af69f5990ed");
            }

            myKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\f7a6c899-2eef-4d98-9191-6af69f5990ed");
            DateTime exp = System.DateTime.Now;
            exp.Subtract(new TimeSpan(2,0,0,0));
            myKey.SetValue("Install", exp.ToString());

            Assert.IsFalse(lic.IsTrialLicense());
        }

        [Test]
        public void ValidPerm()
        {
            Flex lic = new Flex("..\\..\\artifacts\\validperm.xml");
            Assert.IsTrue(lic.IsPermanentLicense());
        }

        [Test]
        public void InvalidPerm()
        {
            Flex lic = new Flex("..\\..\\artifacts\\invalidperm.xml");
            Assert.IsFalse(lic.IsPermanentLicense());
        }

    }
}