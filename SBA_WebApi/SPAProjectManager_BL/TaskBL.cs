using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPAProjectManager.InterfaceLayer;
using SPAProjectManager_DL;
using System.Collections.ObjectModel;
using SPAProjectManager.Entities;


namespace SPAProjectManager_BL
{
    public class TaskBL : ITasksBL
    {
        private readonly SPAProjectManagerEntities _spaprojectManager;
        public TaskBL()
        {
            _spaprojectManager = new SPAProjectManagerEntities();
        }

        public TaskBL(SPAProjectManagerEntities projectManager)
        {
            _spaprojectManager = projectManager;
        }

        public Collection<SPAProjectManager.Entities.ParentTasks> GetParentTasks()
        {

            Collection<SPAProjectManager.Entities.ParentTasks> taskCollection = new Collection<SPAProjectManager.Entities.ParentTasks>();
            _spaprojectManager.Parent_Task
                .Select(u => new SPAProjectManager.Entities.ParentTasks()
                {
                    ParentTaskID = u.Parent_ID,
                    Parent_Task = u.ParentTask
                }).ToList()
               .ForEach(y => taskCollection.Add(y));

            return taskCollection;
        }

        public Collection<SPAProjectManager.Entities.Tasks> GetTasks(int projectID)
        {

            Collection< SPAProjectManager.Entities.Tasks> taskCollection = new Collection<SPAProjectManager.Entities.Tasks>();

            _spaprojectManager.Tasks.Where(c => c.Parent_ID == null && c.Project_ID == projectID)
                .Select(s => new SPAProjectManager.Entities.Tasks
                {
                    Task = s.Task1,
                    ProjectID = s.Project_ID,
                    Project = _spaprojectManager.Projects.Where(u => u.Project_ID == s.Project_ID)
                    .Select(u => u.Project1).FirstOrDefault(),
                    ParentTask = "",
                    Priority = s.Priority ?? 0,
                    StartDate = s.Start_Date,
                    EndDate = s.End_Date,
                    TaskID = s.Task_ID,
                    Status = s.Status,
                    UserID = _spaprojectManager.Users.Where(u => u.Task_ID == s.Task_ID)
                    .Select(u => u.User_ID).FirstOrDefault(),
                    UserName = _spaprojectManager.Users.Where(u => u.Task_ID == s.Task_ID)
                    .Select(u => u.FirstName + " " + u.LastName).FirstOrDefault()
                }).ToList()
                    .ForEach(x => taskCollection.Add(x));

            _spaprojectManager.Tasks.Where(c => c.Parent_ID != null && c.Project_ID == projectID)
                .Join(_spaprojectManager.Parent_Task, f => f.Parent_ID, s => s.Parent_ID,
                (f, s) => new SPAProjectManager.Entities.Tasks
                {
                    Task = f.Task1,
                    ProjectID = f.Project_ID,
                    Project = _spaprojectManager.Projects.Where(u => u.Project_ID == f.Project_ID)
                    .Select(u => u.Project1).FirstOrDefault(),
                    ParentTask = s.ParentTask,
                    Priority = f.Priority ?? 0,
                    StartDate = f.Start_Date,
                    EndDate = f.End_Date,
                    ParentTaskID = s.Parent_ID,
                    TaskID = f.Task_ID,
                    Status = f.Status,
                    UserID = _spaprojectManager.Users.Where(u => u.Task_ID == f.Task_ID)
                    .Select(u => u.User_ID).FirstOrDefault(),
                    UserName = _spaprojectManager.Users.Where(u => u.Task_ID == f.Task_ID)
                    .Select(u => u.FirstName + " " + u.LastName).FirstOrDefault()
                }).ToList()
                 .ForEach(x => taskCollection.Add(x));

            return taskCollection;
        }


        public void AddTask(SPAProjectManager.Entities.Tasks task)
        {

            SPAProjectManager_DL.Task tk = new SPAProjectManager_DL.Task
            {
                Task_ID=task.TaskID,
                Task1 = task.Task,
                Project_ID = task.ProjectID,
                Priority = task.Priority,
                Start_Date = task.StartDate,
                End_Date = task.EndDate,
                Status = false
            };
            if (task.ParentTaskID == 0)
            {
                tk.Parent_ID = null;
            }
            else
            {
                tk.Parent_ID = task.ParentTaskID;
            }


            _spaprojectManager.Tasks.Add(tk);
            _spaprojectManager.SaveChanges();
            var taskId = tk.Task_ID;
            var ur = _spaprojectManager.Users.Where(x => x.User_ID == task.UserID).FirstOrDefault();
            if (ur != null)
            {
                ur.Task_ID = taskId;
                _spaprojectManager.SaveChanges();
            }
        }

        public void UpdateTask(SPAProjectManager.Entities.Tasks task)
        {
            var tk = _spaprojectManager.Tasks.Where(x => x.Task_ID == task.TaskID).FirstOrDefault();

            if (tk != null)
            {
                tk.Task1 = task.Task;
                tk.Project_ID = task.ProjectID;
                tk.Priority = task.Priority;
                tk.Start_Date = task.StartDate;
                tk.End_Date = task.EndDate;
                if (task.ParentTaskID == 0)
                {
                    tk.Parent_ID = null;
                }
                else
                {
                    tk.Parent_ID = task.ParentTaskID;
                }

                _spaprojectManager.SaveChanges();
                var ur = _spaprojectManager.Users.Where(x => x.User_ID == task.UserID).FirstOrDefault();
                if (ur != null)
                {
                    ur.Task_ID = tk.Task_ID;
                    _spaprojectManager.SaveChanges();
                }
            }
        }

        public void EndTask(SPAProjectManager.Entities.Tasks task)
        {
            var tk = _spaprojectManager.Tasks.Where(x => x.Task_ID == task.TaskID).FirstOrDefault();

            if (tk != null)
            {
                tk.Status = true;
                _spaprojectManager.SaveChanges();
            }
        }

        public void AddParentTask(SPAProjectManager.Entities.ParentTasks pTask)
        {
            SPAProjectManager_DL.Parent_Task tk = new SPAProjectManager_DL.Parent_Task
            {
                //Parent_ID=pTask.ParentTaskID,
                ParentTask = pTask.Parent_Task
            };

            _spaprojectManager.Parent_Task.Add(tk);
            _spaprojectManager.SaveChanges();
        }

    }
}
