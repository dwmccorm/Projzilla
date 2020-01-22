using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ProjectBugzilla
{
    /// <summary>
    /// Use XML when possible, not this one.
    /// This has not bug dependencies or QA contact, ...
    /// XML is complete, this is a small subset which should only be used 
    /// with older version of bugzilla which do not support it
    /// 
    /// BUGS:
    ///   Put default duration for bugs that have no value.
    ///   Check to see what happens for bugs have zero hours left, what does project say?
    ///   MAJOR BUG, if Summary has ", or ," in it, things get really buggy.
    /// </summary>
    public class CSVBugFactory : BugFactory
    {
        #region CreateBugs
        public override BugDictionary CreateBugs(string csvfile, Progress progress)
        {
            Dictionary<int, string> Headers;
            DataTable csvTable;
            BugDictionary bugs;
            Bug bug;

            #region Pre Condition
            Debug.Assert("" != csvfile);
            #endregion

            Headers = new Dictionary<int, string>();
            csvTable = CSVParse(csvfile);
            bugs = new BugDictionary();

            #region Header
            // Use the header row to make a map of where stuff goes
            //string[] csvHeaders = csvTable[0];
            int index = 0;
            foreach (string header in csvTable.Rows[0].ItemArray)
            {
                Headers.Add(index, header);
                index++;
            }
            #endregion

            #region Verification
            // Write code to ensure that we have enough of the fields
            #endregion

            #region Data Row Parse
            DataRow row;

            for (int i = 1; i < csvTable.Rows.Count; i++)
            {
                row = csvTable.Rows[i];
                bug = new Bug();
                for (int j = 0; j < row.ItemArray.Length; j++)
                {
                    if (Headers.ContainsKey(j) && (null != row.ItemArray[j]) && (false == (row.ItemArray[j] is System.DBNull)) && (null != row.ItemArray[j]) && ("" != (string) row.ItemArray[j]))
                    {
                        CSVBugPopulate(bug, Headers[j], (string) row.ItemArray[j]);
                    }
                }

                // This deals with the case of null rows at the end.
                if (0 != bug.Id)
                {
                    bugs.Add(bug.Id, bug);
                }
                if (null != progress)
                    progress.UpdateProgress(1, "Reading " + bug.Id + " from " + csvfile + ".");
            }
            #endregion

            #region Post Condition
            foreach (KeyValuePair<int, Bug> kvp in bugs)
            {
                bug = ((Bug)kvp.Value);
                Debug.Assert(0 != bug.Id);
                Debug.Assert((null != bug.Summary) && ("" != bug.Summary));
            }
            #endregion

            return (bugs);
        }
        #endregion

        #region CSVParse
        /// <summary>
        /// Takes a CSV file and makes an array of arrays from the data
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private DataTable CSVParse(string path)
        {
            DataTable dataTable;

            dataTable = CSVReader.ReadCSVFile(path, false);
            return dataTable;
        }
        #endregion

        #region CleanCSVDataField
        /// <summary>
        /// Cleans the data in the field, escaped chars, ....
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string CleanCSVDataField(string input)
        {
            return (CSVTrim(input));
        }
        #endregion

        #region CSVTrim
        /// <summary>
        /// Gets rid of the quotes at the end of the field.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string CSVTrim(string input)
        {
            string output = "";
            output = input.TrimStart('\"');
            output = output.TrimEnd('\"');
            return (output);
        }
        #endregion

        #region CSVBugPopulate
        /// <summary>
        /// Given the CSV key, this will place it into the bug.
        /// We should really revisit this code since it is hacky.
        /// </summary>
        /// <param name="bug"></param>
        /// <param name="csvKey"></param>
        /// <param name="value"></param>
        private void CSVBugPopulate(Bug bug, string csvKey, string value)
        {
            #region Pre Condition
            Debug.Assert("" != csvKey);
            Debug.Assert(null != bug);
            #endregion

            if ("" == value)
                return;

            switch (csvKey)
            {
                case "bug_id":
                    bug.Id = int.Parse(value);
                    break;
                case "bug_severity":
                    bug.Severity = CleanCSVDataField(value);
                    break;
                case "priority":
                    bug.Priority = CleanCSVDataField(value);
                    break;
                case "op_sys":
                    bug.OS = CleanCSVDataField(value);
                    break;
                case "assigned_to":
                    bug.Owner = CleanCSVDataField(value);
                    break;
                case "bug_status":
                    bug.Status = CleanCSVDataField(value);
                    break;
                case "resolution":
                    bug.Resolution = CleanCSVDataField(value);
                    break;
                case "short_short_desc":
                case "short_desc":
                    bug.Summary = CleanCSVDataField(value);
                    break;
                case "estimated_time":
                    bug.OriginalTimeEstimate=Convert.ToDouble(value);
                    break;
                case "remaining_time":
                    bug.RemainingTime = Convert.ToDouble(value);
                    break;
                case "actual_time":
                    bug.ActualTime = Convert.ToDouble(value);
                    break;
                case "target_milestone":
                    bug.Milestone = CleanCSVDataField(value);
                    break;
                case "assigned_to_realname":
                    bug.Owner = CleanCSVDataField(value);
                    break;
                case "rep_platform":
                    bug.Platform = CleanCSVDataField(value);
                    break;
                case "reporter":
                    bug.Reporter = CleanCSVDataField(value);
                    break;
                case "product":
                    bug.Product = CleanCSVDataField(value);
                    break;
                case "component":
                    bug.Component = CleanCSVDataField(value);
                    break;
                case "version":
                    bug.Version = CleanCSVDataField(value);
                    break;
                case "keywords":
                    bug.Keywords = CleanCSVDataField(value);
                    break;
                case "opendate":
                    bug.CreationDate = CleanCSVDataField(value);
                    break;

                // These ones have no mapping because CSV doesn't give them
                // or we don't use them.
                case "reporter_realname":
                case "changeddate":
                case "percentage_complete":
                    break;

                default:
                    break;
            }

            #region Post Condition
            #endregion
        }
        #endregion

        #region Length
        /// <summary>
        /// Returns bad answer when there are null rows/
        /// </summary>
        /// <returns></returns>
        public override int Length()
        {
            return (File.ReadAllLines(InputPath).Length - 1);
        }
        #endregion
    }
}