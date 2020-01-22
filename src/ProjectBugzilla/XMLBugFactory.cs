using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml;
using System.Diagnostics;
using System.Windows.Forms;

namespace ProjectBugzilla
{
    /// <summary>
    /// Creates an Array of bugs from the Bugzilla XML
    /// </summary>
    public class XMLBugFactory : BugFactory
    {
        #region CreateBugs
        public override BugDictionary CreateBugs(string xmlfile, Progress progress)
        {
            #region Pre Condition
            Debug.Assert(xmlfile != null);
            #if DEBUG
            System.Console.WriteLine("CreateBugs(" + xmlfile + ")");
            #endif
            #endregion

            BugDictionary bugs = new BugDictionary();
            XmlDocument doc = new XmlDocument();
            doc.XmlResolver = null; // Prevents it from searching for the bugzilla dtd (incase it is not accessible.
            doc.Load(xmlfile);
            foreach (XmlNode node in doc.SelectNodes("/bugzilla/bug"))
            {
                Bug bug = new Bug();
                bug.Id = int.Parse(node.SelectNodes("bug_id")[0].InnerText);
                bug.Status = node.SelectNodes("bug_status")[0].InnerText;
                if (null != node.SelectNodes("resolution")[0])
                {
                    bug.Resolution = node.SelectNodes("resolution")[0].InnerText;
                }
                if (null != node.SelectNodes("target_milestone")[0])
                {
                    bug.Milestone = node.SelectNodes("target_milestone")[0].InnerText;
                }
                if (null != node.SelectNodes("rep_platform")[0])
                {
                    bug.Platform = node.SelectNodes("rep_platform")[0].InnerText;
                }
                if (null != node.SelectNodes("keywords")[0])
                {
                    bug.Keywords = node.SelectNodes("keywords")[0].InnerText;
                }
                if (null != node.SelectNodes("op_sys")[0])
                {
                    bug.OS = node.SelectNodes("op_sys")[0].InnerText;
                }
                if (null != node.SelectNodes("qa_contact")[0])
                {
                    bug.QAContact = node.SelectNodes("qa_contact")[0].InnerText;
                }
                bug.Summary = node.SelectNodes("short_desc")[0].InnerText;
                bug.Owner = node.SelectNodes("assigned_to")[0].Attributes[0].InnerText;
                bug.Priority = node.SelectNodes("priority")[0].InnerText;
                bug.CreationDate = node.SelectNodes("creation_ts")[0].InnerText;
                bug.Severity = node.SelectNodes("bug_severity")[0].InnerText;

                bug.Product = node.SelectNodes("product")[0].InnerText;
                bug.Component = node.SelectNodes("component")[0].InnerText;
                bug.Version = node.SelectNodes("version")[0].InnerText;
                bug.Reporter= node.SelectNodes("reporter")[0].InnerText;

                #region Actual Time, Estimated Time, Remaining Time
                if (node.SelectNodes("actual_time").Count > 0)
                {
                    bug.ActualTime = Convert.ToDouble(node.SelectNodes("actual_time")[0].InnerText);
                }
                else
                {
                    bug.ActualTime = Convert.ToDouble(Config.GetSystem("DefaultBugDuration"));
                }
                if (node.SelectNodes("estimated_time").Count > 0)
                {
                    bug.OriginalTimeEstimate = Convert.ToDouble(node.SelectNodes("estimated_time")[0].InnerText);
                }
                else
                {
                    bug.OriginalTimeEstimate = Convert.ToDouble(Config.GetSystem("DefaultBugDuration"));
                }
                if (node.SelectNodes("remaining_time").Count > 0)
                {
                    bug.RemainingTime = Convert.ToDouble(node.SelectNodes("remaining_time")[0].InnerText);
                }
                else
                {
                    bug.RemainingTime = Convert.ToDouble(Config.GetSystem("DefaultBugDuration"));
                }
                #endregion

                foreach (XmlNode depNode in node.SelectNodes("dependson"))
                {
                    bug.DependsOn.Add(Convert.ToInt32(depNode.InnerText));
                }
                foreach (XmlNode depNode in node.SelectNodes("blocked"))
                {
                    bug.Blocks.Add(Convert.ToInt32(depNode.InnerText));
                }
                bugs.Add(bug.Id, bug);
                if (null != progress)
                    progress.UpdateProgress(1, "Reading " + bug.Id + " from " + xmlfile + ".");
            }

            #region Post Condition
            Debug.Assert(bugs != null);
            #endregion

            return (bugs);
        }
        #endregion

        #region Length
        /// <summary>
        /// Number of bugs in the file
        /// </summary>
        /// <returns></returns>
        public override int Length()
        {
            XmlDocument doc = new XmlDocument();
            doc.XmlResolver = null; // Prevents it from searching for the bugzilla dtd (incase it is not accessible.
            doc.Load(InputPath);
            XmlNodeList list = doc.SelectNodes("/bugzilla/bug");
            doc = null;

            return (list.Count);
        }
        #endregion
    }
}
