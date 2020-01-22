using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop.MSProject;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace ProjectBugzilla
{
    public class MSProject
    {
        #region MSProject
        public MSProject()
        {
            Init(Config.GetSystem("DataMapperFile"));
        }

        public MSProject(string dataMapperFile)
        {
            Init(dataMapperFile);
        }
        #endregion

        #region Init
        /// <summary>
        /// Object intialization routine.
        /// </summary>
        /// <param name="dataMapperFile"></param>
        private void Init(string dataMapperFile)
        {
            _genNewProject = true;
            InputType = InputDataFormat.None;

            _dataMap = new DataMapper(dataMapperFile, "map");
            _dataMap.Reload();

            _priorityDataMap = new DataMapper(dataMapperFile, "map-priority");
            _priorityDataMap.Reload();
        }
        #endregion

        #region Progress
        /// <summary>
        /// Progress bar to show on working...
        /// </summary>
        private Progress _progress;
        #endregion

        #region Project
        private Project _project;
        /// <summary>
        /// The actual project object.
        /// </summary>
        public Project Project
        {
            get
            {
                return _project;
            }
            set
            {
                _project = value;
            }
        }
        #endregion

        private int startHolderId = 0;

        #region InputType
        private InputDataFormat _inputType;
        /// <summary>
        /// Type of input that the input is coming in as.
        /// </summary>
        public InputDataFormat InputType
        {
            get
            {
                return _inputType;
            }
            set
            {
                _inputType = value;
                switch (_inputType)
                {
                    case InputDataFormat.BugzillaCSV:
                        BugFact = new CSVBugFactory();
                        break;
                    case InputDataFormat.BugzillaXML:
                        BugFact = (BugFactory) new XMLBugFactory();
                        break;
                }
            }
        }
        #endregion

        #region BugFact
        private BugFactory _bugFactory;
        public BugFactory BugFact
        {
            get
            {
                return (_bugFactory);
            }
            set
            {
                _bugFactory = value;
            }
        }
        #endregion

        #region InputPath
        /// <summary>
        /// File to use as the XML for bugzilla input
        /// </summary>
        private string _inputPath;
        public string InputPath
        {
            get
            {
                return _inputPath;
            }
            set
            {
                _inputPath = value;

                if (_inputPath.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                {
                    InputType = InputDataFormat.BugzillaXML;
                }
                if (_inputPath.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                {
                    InputType = InputDataFormat.BugzillaCSV;
                }
            }
        }
        #endregion 

        #region DataMapper
        /// <summary>
        /// The object which maps the bugzilla fields to project fields.
        /// </summary>
        private DataMapper _dataMap;
        #endregion

        #region PriorityMap
        private DataMapper _priorityDataMap;
        #endregion

        #region ShowAllBugzillaFieldsInProject
        bool _showAllBugzillaFieldsInProject = true;
        public bool ShowAllBugzillaFieldsInProject
        {
            get
            {
                return (_showAllBugzillaFieldsInProject);
            }
            set
            {
                _showAllBugzillaFieldsInProject = value;
            }
        }
        #endregion

        private ApplicationClass _projectApp;

        #region GenerateNewProject
        private bool _genNewProject;
        /// <summary>
        /// Determines if we are to generate a new project.
        /// </summary>
        public bool GenerateNewProject
        {
            get
            {
                return (_genNewProject);
            }
            set
            {
                _genNewProject = value;
            }
        }
        #endregion

        #region UseExistingProject
        /// <summary>
        /// Tells if we are to reuse an existing project.
        /// </summary>
        public bool UseExistingProject
        {
            get
            {
                return (!_genNewProject);
            }
            set
            {
                _genNewProject = !value;
            }
        }
        #endregion

        #region SaveProjectFilePath
        private string _saveProjectFilePath;
        /// <summary>
        /// Location of project file (mpp) to use.
        /// </summary>
        public string SaveProjectFilePath
        {
            get
            {
                return _saveProjectFilePath;
            }
            set
            {
                _saveProjectFilePath = value;
            }
        }
        #endregion

        #region LoadProjectFilePath
        private string _loadProjectFilePath;
        /// <summary>
        /// Location of project file (mpp) to use.
        /// </summary>
        public string LoadProjectFilePath
        {
            get
            {
                return _loadProjectFilePath;
            }
            set
            {
                _loadProjectFilePath = System.IO.Path.GetFullPath(value);
            }
        }
        #endregion

        #region TempProjectFilePath
        private string _tempProjectFilePath;
        /// <summary>
        /// Location where we put the project file while working on it.
        /// </summary>
        public string TempProjectFilePath
        {
            get
            {
                return (_tempProjectFilePath);
            }
            set
            {
                _tempProjectFilePath = value;
            }
        }
        #endregion

        #region LoadMPP
        /// <summary>
        /// Load the project file for usage
        /// </summary>
        /// <param name="fileName">File to open</param>
        public void LoadMPP()
        {
            Debug.Assert(System.IO.Path.IsPathRooted(LoadProjectFilePath));
            Debug.Assert(System.IO.File.Exists(LoadProjectFilePath));

            if (false == System.IO.File.Exists(LoadProjectFilePath))
            {
                //System.Windows.Forms.MessageBox.Show("Unable to find project file \"" + LoadProjectFilePath + "\".", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                throw new ProjzillaException("Unable to write to existing project file \"" + LoadProjectFilePath + "\" because it does not exist.", new FileNotFoundException("Unable to write to existing project file \"" + LoadProjectFilePath + "\" because it does not exist.", LoadProjectFilePath));
            }

            #region Do the Temp File Thing
            // Ensure that temp directory exists
            if (!Directory.Exists(Path.GetTempPath() + "\\Projzilla"))
            {
                Directory.CreateDirectory(Path.GetTempPath() + "Projzilla");
            }

            // Delete the old temp file if there is one.
            string loadProjectFileName = Path.GetFileName(LoadProjectFilePath);
            TempProjectFilePath = Path.GetTempPath() + "Projzilla\\" + loadProjectFileName;
            if (File.Exists(TempProjectFilePath))
            {
                try
                {
                    File.Delete(TempProjectFilePath);
                }
                catch (IOException ioe)
                {
                    throw new ProjzillaException("Unable to create temporary project file.  This typically occurs when project already has the file open.  Please close project and run the program again.", ioe, ProjzillaExceptionSeverity.Warn);
                }
            }

            // Copy the Load File to the temp location.
            File.Copy(LoadProjectFilePath, TempProjectFilePath);

            #endregion

            _projectApp = new ApplicationClass();

            // When doing a save, this prevents the do you want to overwrite dialog coming up.
            _projectApp.DisplayAlerts = false;
            _projectApp.AppMinimize();
            _projectApp.FileOpen(TempProjectFilePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, PjPoolOpen.pjPoolReadWrite, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            _projectApp.WindowState = PjWindowState.pjMinimized;
            _projectApp.Visible = false;

        }
        #endregion

        #region SaveMPP
        /// <summary>
        /// Does a File Save As for the currently active project.
        /// </summary>
        public void SaveMPP()
        {
            _projectApp.FileSaveAs(SaveProjectFilePath, PjFileFormat.pjMPP, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
        }
        #endregion

        #region Update
        /// <summary>
        /// Uses the bugzilla XML file and updates the project file with that information.
        /// </summary>
        public void Update()
        {
            this.Update(InputPath);
        }

        /// <summary>
        /// Uses the bugzilla XML file and updates the project file with that information.  
        /// This also has the interesting side affect of setting the bugzilla file variables 
        /// for this class.
        /// </summary>
        /// <param name="bugzilla_xml"></param>
        public void Update(string fileName)
        {
            #region Pre Condition
            Debug.Assert(null != fileName);
            Debug.Assert(fileName == InputPath);
            #endregion

            #region Create Bug Factory
            InputPath = fileName;
            switch (this.InputType)
            {
                case InputDataFormat.BugzillaXML:
                    BugFact = new XMLBugFactory();
                    break;
                case InputDataFormat.BugzillaCSV:
                    BugFact = new CSVBugFactory();
                    break;
            }
            BugFact.InputPath = fileName;
            #endregion

            #region Progress
            _progress = new Progress();
            _progress.Range = NumberOfTicksForGeneration(fileName);
            _progress.Show();
            System.Threading.Thread.Sleep(500);
            _progress.Refresh();
            #endregion

            BugDictionary bugs = BugFact.CreateBugs(InputPath, _progress);
            CreateProjectTasks(bugs, _progress);

            _progress.Refresh();

            _progress.UpdateProgressDone();
            System.Threading.Thread.Sleep(2000);
            _progress.Close();
            _progress = null;

            #region Post Condition
            #endregion
        }
        #endregion

        #region IsProjectAlreadyRunning
        /// <summary>
        /// Will check to see if project is already running or not.
        /// </summary>
        /// <returns>true if project is running, false otherwise</returns>
        public static bool IsProjectAlreadyRunning()
        {
            Process[] procs = Process.GetProcesses();
            foreach (Process proc in procs)
            {
                if ("WINPROJ" == proc.ProcessName)
                    return (true);
            }
            return (false);
        }
        #endregion

        #region CreateProjectTasks
        /// <summary>
        /// Takes a listing of bugs delegates the creation of project tasks.
        /// </summary>
        /// <param name="bugs"></param>
        /// <remarks>This makes the assumption that the Task.Number1 field is always avaible for us to use.  This is our bug key.</remarks>
        public void CreateProjectTasks(BugDictionary bugs, Progress progress)
        {
            ArrayList orphanTasks = new ArrayList();
            Dictionary<int,Task> bugzillaTasks = new Dictionary<int, Task>();
            Dictionary<int,Bug> deepCopyBugs = new Dictionary<int, Bug>();
            bool foundStartHolder = false;

            #region Create Bugs Deep Copy
            // We need to make a deep copy of the bugs since we need to remove
            // them from the list as we add them to the list, and doing this 
            // to the active dictionary would be bad, and adding another 
            // variable to the dictionary to indicate what has been removed 
            // was going to be a pain.
            foreach (KeyValuePair<int, Bug> kvp in bugs)
            {
                deepCopyBugs.Add(kvp.Key, kvp.Value);
            }
            #endregion

            #region Set Microsoft Project Configuration
            _project = _projectApp.ActiveProject;
            _project.DefaultWorkUnits = PjUnit.pjHour;
            _project.DefaultDurationUnits = PjUnit.pjHour;

            #region Show Fields in table
            if (ShowAllBugzillaFieldsInProject)
            {
                // THIS IS HARD CODED, it should be made reflective.
                foreach (KeyValuePair<string, string> de in _dataMap.GetEnumerator())
                {
                    if (de.Key != "Owner")
                    {
                        // BUG: Don't just eat the exception.  Figure out how to update the column properly.
                        try
                        {
                            _project.Application.SelectTaskColumn(de.Value, Missing.Value, Missing.Value, Missing.Value);
                            _project.Application.ColumnDelete();
                        }
                        catch (Exception) { }

                        try
                        {
                            _project.Application.TableEdit("&Entry", true, Missing.Value, true, Missing.Value, Missing.Value, de.Value, de.Key, Missing.Value, 0, true, true, 255, Missing.Value, Missing.Value, 1, Missing.Value, Missing.Value);
                            _project.Application.TableApply("&Entry");
                        }
                        catch (Exception) { }
                    }
                }
                try
                {
                    _project.Application.TableEdit("&Entry", true, Missing.Value, true, Missing.Value, Missing.Value, "Remaining Work", "Remaining Work", Missing.Value, 0, true, true, 255, Missing.Value, Missing.Value, 1, Missing.Value, Missing.Value);
                    _project.Application.TableApply("&Entry");
                }
                catch (Exception) { }
                try
                {
                    _project.Application.TableEdit("&Entry", true, Missing.Value, true, Missing.Value, Missing.Value, "Actual Work", "Actual Work", Missing.Value, 0, true, true, 255, Missing.Value, Missing.Value, 1, Missing.Value, Missing.Value);
                    _project.Application.TableApply("&Entry");
                }
                catch (Exception) { }
                try
                {
                    _project.Application.TableEdit("&Entry", true, Missing.Value, true, Missing.Value, Missing.Value, "Priority", "Priority", Missing.Value, 0, true, true, 255, Missing.Value, Missing.Value, 1, Missing.Value, Missing.Value);
                    _project.Application.TableApply("&Entry");
                }
                catch (Exception) { }
            }
            #endregion

            #endregion

            #region Start Task
            foreach (Task task in _project.Tasks)
            {
                if (task.Name == "Today")
                {
                    startHolderId = task.ID;
                    foundStartHolder = true;
                    break;
                }
            }
            if (false == foundStartHolder)
            {
                Task task = _project.Tasks.Add("Today", 1);
                task.PercentComplete = "100%";
                task.ActualWork = 0;
                task.Milestone = true;
                task.RemainingWork = 0;
                startHolderId = task.ID;
                foundStartHolder = true;
                task.Start = DateTime.Now;
            }
            #endregion

            #region Update Existing Tasks
            Debug.Assert(startHolderId != 0);
            Debug.Assert(foundStartHolder);

            foreach (Task task in _project.Tasks)
            {
                if (deepCopyBugs.ContainsKey((int)task.Number1))
                {
                    Debug.Assert(Program.ASSUMPTION_Task_Number1_to_BugID);
                    Bug bug = deepCopyBugs[(int)task.Number1];
                    deepCopyBugs.Remove(bug.Id);
                    bug.ProjectTaskId = task.ID;
                    if ((null == task.Predecessors) || ("" == task.Predecessors))
                    {
                        task.Predecessors = startHolderId.ToString();
                    }
                    else
                    {
                        task.Predecessors += ", " + startHolderId.ToString();
                    }
                    UpdateProjectTask(bug, task);
                    bugzillaTasks.Add(bug.Id, task);
                }
                else
                {
            
                    // Probably shoudl do something here...
                    // Debug.Assert(false, "Task \"" + task.Summary + "\" exists in project but not in bugzilla.");
                }
                progress.UpdateProgress(1, "Scanning project task " + task.Name + ".");
            }
            #endregion

            #region Create New Tasks
            foreach (Bug bug in deepCopyBugs.Values)
            {
                Task task = _project.Tasks.Add(bug.Summary, 2);

                Debug.Assert(null != bug);
                Debug.Assert(bug.Id != 0);
                Debug.Assert(null != task);

                UpdateProjectTask(bug, task);
                bug.ProjectTaskId = task.ID;
                bugzillaTasks.Add(bug.Id, task);
                progress.UpdateProgress(1, "Created task from bug " + bug.Id + ".");
            }
            #endregion

            #region Debug Verification
            Debug.Assert(bugs.Count == bugzillaTasks.Count);
            #endregion

            #region Set any Dependencies as defined in bugzilla
            foreach (KeyValuePair<int, Task> obj in bugzillaTasks)
            {
                Task task = (Task) (obj).Value;

                // Set dependency to today.
                if (("" == task.Predecessors) || (null == task.Predecessors))
                {
                    task.Predecessors += startHolderId.ToString();
                }
                else
                {
                    task.Predecessors = task.Predecessors + ", " + startHolderId.ToString();
                }

                // Get the bug for the task
                Debug.Assert(Program.ASSUMPTION_Task_Number1_to_BugID);
                Debug.Assert(bugs.ContainsKey((int) task.Number1));

                Bug bug = bugs[(int) task.Number1];
                Debug.Assert(null != bug);

                // Search for any depends on in the bug
                foreach (int depNum in bug.Blocks)
                {
                    Debug.Assert(0 != bug.ProjectTaskId);
                    if (false == bugzillaTasks.ContainsKey(depNum))
                    {
                        System.Windows.Forms.MessageBox.Show("There is a dependency reference to a bug which is not contained in your search.  Please re-define your search.", "Projzilla Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return;
                    }

                    Task myTask = bugzillaTasks[depNum];
                    if (("" == myTask.Predecessors) || (null == myTask.Predecessors))
                    {
                        myTask.Predecessors = task.ID.ToString();
                    }
                    else
                    {
                        string preds;
                        preds = myTask.Predecessors + ", " + task.ID.ToString();
                        myTask.Predecessors = preds;
                    }
                }
                progress.UpdateProgress(1, "Scanning and updating dependencies.");
            }
            #endregion
        }
        #endregion

        #region UpdateProjectTask
        /// <summary>
        /// Takes a bug and places the data from the bug into the Project Task.
        /// </summary>
        /// <param name="bug">Bug with Info</param>
        /// <param name="task">Task to get the Info</param>
        public void UpdateProjectTask(Bug bug, Task task)
        {
            #region Pre Condition
            Debug.Assert(null != _dataMap);
            #endregion

            bool found = false;

            #region Crazy Reflection Code
            _project.DefaultWorkUnits = PjUnit.pjHour;
            Type myTaskType = typeof(Microsoft.Office.Interop.MSProject.Task);
            System.Reflection.PropertyInfo[] taskPropInfo = myTaskType.GetProperties();

            Debug.Assert(Program.ASSUMPTION_Task_Number1_to_BugID, "Need to do some majic with the mapping here");
            foreach (System.Reflection.PropertyInfo taskInfo in taskPropInfo)
            {
                found = false;
                foreach (object obj in _dataMap.GetEnumerator())
                {
                    KeyValuePair<string, string> de = (KeyValuePair<string, string>)obj;
                    if (taskInfo.Name == (string) de.Value)
                    {
                        if (!found)
                        {
                            // Take care of the users property mapping from the XML
                            Type myBugType = typeof(Bug);
                            System.Reflection.PropertyInfo[] bugPropInfo = myBugType.GetProperties();

                            foreach (System.Reflection.PropertyInfo bugInfo in bugPropInfo)
                            {
                                if (bugInfo.Name == (string)de.Key)
                                {
                                    if ((String.Compare("blocks", de.Key, true) == 0) && (!found))
                                    {
                                        string s = bug.BlocksAsString();
                                        taskInfo.SetValue(task, bug.BlocksAsString(), null);
                                        found = true;
                                    }
                                    else if ((String.Compare("dependson", de.Key, true) == 0) && (!found))
                                    {
                                        string s = bug.BlocksAsString();
                                        taskInfo.SetValue(task, bug.DependsOnAsString(), null);
                                        found = true;
                                    }
                                    else
                                    {
                                        // Stupid unit conversion.  If we are doing a duration field, we need to fiddle with units.
                                        if (taskInfo.Name.StartsWith("Duration", StringComparison.OrdinalIgnoreCase))
                                        {
                                            taskInfo.SetValue(task, Convert.ToString((double)bugInfo.GetValue(bug, null)) + " hrs", null);
                                        }
                                        else
                                        {
                                            taskInfo.SetValue(task, bugInfo.GetValue(bug, null), null);
                                        }
                                        found = true;
                                    }
                                }
                                if (found)
                                {
                                    break;
                                }
                            }
                        }
                        // TODO: If not found in foreach, try custom fields
                    }
                    if (found)
                    {
                        break;
                    }
                }
            }
            #endregion

            Debug.Assert(null != _priorityDataMap);
            if (_priorityDataMap.ContainsKey(bug.Priority))
            {
                task.Priority = Convert.ToInt16(_priorityDataMap[bug.Priority]);
            }
            else
            {
                if (_priorityDataMap.ContainsKey("undefined"))
                {
                    task.Priority = Convert.ToInt16(_priorityDataMap["undefined"]);
                }
                else
                {
                    task.Priority = 501;
                }
            }
            
            // Don't reverse these lines.  Project re-calculates fields as you set 
            // the values, and changing the order breaks things.
            task.ActualWork = bug.ActualTime.ToString() + " hrs";
            task.RemainingWork = bug.RemainingTime.ToString() + " hrs";

            // Bug has no more work to be done.
            if (bug.Status.Contains("FIXED") || bug.Status.Contains("INVALID") || bug.Status.Contains("WONTFIX") || bug.Status.Contains("WORKSFORME") || bug.Status.Contains("LATER") || bug.Status.Contains("REMIND"))
            {
                task.PercentComplete = "100%";
                task.ActualWork = bug.ActualTime + " hrs";
                task.ActualDuration = bug.ActualTime + " hrs";
                task.RemainingWork = bug.RemainingTime + " hrs";
            }
            else
            {
                // Ensure that the tasks are placed to the current date.

                // task.ConstraintType = (short)Microsoft.Office.Project.Server.Library.Task.ConstraintType.StartNoEarlierThan;
                task.ConstraintType = 4;
                task.ConstraintDate = DateTime.Now;
            }
        }
        #endregion 

        #region NumberofTicksForGeneration
        public int NumberOfTicksForGeneration(string bugFile)
        {
            int ticks = 0;
            int numBugs = 0;

            BugFact.InputPath = bugFile;

            #region Number of Ops in Create Bug
            numBugs = BugFact.Length();
            ticks += numBugs;
            #endregion

            #region Update Tasks
            _project = _projectApp.ActiveProject;
            ticks += _project.Tasks.Count;
            #endregion

            #region Create New Tasks
            // This one is off by a lot since we can't cacluate the number of tasks which exist already.
            ticks += numBugs;
            #endregion

            #region Deps
            ticks += numBugs * 2;
            #endregion

            return ticks;
        }
        #endregion

        #region CommandLineInterface
        /// <summary>
        /// This will parse the command line arguements then do the requested work.
        /// </summary>
        /// <param name="args"></param>
        public void CommandLineInterface(string[] args)
        {
            bool generate_bugzillaXMLFilePath = false;
            bool generate_newmppFilePath = false;
            bool generate_existingmppFilePath = false;
            bool show_help = false;

            #region Parse Arguments
            for (int i = 0; i < args.Length; i++)
            {
                if (0 == String.Compare(args[i], "-help", true))
                {
                    show_help = true;
                }
                if (0 == String.Compare(args[i], "-bugzillaxml", true))
                {
                    InputPath = args[i + 1];
                    generate_bugzillaXMLFilePath = true;
                    InputType = InputDataFormat.BugzillaXML;
                }
                if (0 == String.Compare(args[i], "-newproject", true))
                {
                    GenerateNewProject = true;
                    LoadProjectFilePath = Config.GetUser("BlankProjectFile");
                    SaveProjectFilePath = System.IO.Path.GetFullPath(args[i + 1]);
                    generate_newmppFilePath = true;
                }
                if (0 == String.Compare(args[i], "-existingproject", true))
                {
                    GenerateNewProject = false;
                    LoadProjectFilePath = args[i + 1];
                    SaveProjectFilePath = System.IO.Path.GetFullPath(args[i + 1]);
                    generate_existingmppFilePath = true;
                }
            }
            #endregion

            if (generate_existingmppFilePath && generate_bugzillaXMLFilePath)
            {
                LoadMPP();
                Update();
                SaveMPP();
                Close();
            }
            else if (generate_newmppFilePath && generate_bugzillaXMLFilePath)
            {
                LoadMPP();
                Update();
                SaveMPP();
                Close();
            }

            else if (show_help)
            {
                MessageBox.Show("Creates Microsoft Project file from Bugzilla.\n\nUsage:\nprojzilla.exe -BugzillaXML <bugzilla.xml> -NewProject <msproj.mpp>\nprojzilla.exe -BugzillaXML <bugzilla.xml> -ExistingProject <msproj.mpp>", "Projzilla.exe", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Creates Microsoft Project file from Bugzilla.\n\nUsage:\nprojzilla.exe -BugzillaXML <bugzilla.xml> -NewProject <msproj.mpp>\nprojzilla.exe -BugzillaXML <bugzilla.xml> -ExistingProject <msproj.mpp>", "Projzilla.exe", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Close
        /// <summary>
        /// Closes the project
        /// </summary>
        public void Close()
        {
            _projectApp.FileCloseAll(PjSaveType.pjDoNotSave);
            _projectApp.Quit(PjSaveType.pjDoNotSave);
            _projectApp = null;

            // Wait 3 second for the application to quit and clean itself up.
            System.Threading.Thread.Sleep(3000);
        }
        #endregion
    }
}