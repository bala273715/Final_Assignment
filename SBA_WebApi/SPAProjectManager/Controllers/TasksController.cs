using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SPAProjectManager.Entities;
using SPAProjectManager_DL;
using SPAProjectManager.InterfaceLayer;
using System.Collections.ObjectModel;


namespace SPAProjectManager.Controllers
{
    /// <summary>
    /// TasksController
    /// </summary>

    [RoutePrefix("api/Tasks")]
    public class TasksController : ApiController
    {
        private readonly ITasksBL _taskBL = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public TasksController()
        {
            _taskBL = new SPAProjectManager_BL.TaskBL();
        }
        /// <summary>
        /// Parameterized Constructorr
        /// </summary>
        /// <param name="taskBL"></param>
        public TasksController(ITasksBL taskBL)
        {
            _taskBL = taskBL;
        }
        /// <summary>
        /// Add Task 
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddTask")]
        public IHttpActionResult AddTask([FromBody]SPAProjectManager.Models.Tasks task)
        {
            try
            {
                SPAProjectManager.Entities.Tasks tk = new SPAProjectManager.Entities.Tasks
                {
                    TaskID=task.TaskID,
                    Task = task.Task,
                    ProjectID = task.ProjectID,
                    Priority = task.Priority,
                    ParentTaskID = task.ParentTaskID,
                    StartDate = task.StartDate,
                    EndDate = task.EndDate,
                    UserID = task.UserID
                };

                _taskBL.AddTask(tk);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
        /// <summary>
        /// Update Task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateTask")]
        public IHttpActionResult UpdateTask([FromBody]SPAProjectManager.Models.Tasks task)
        {
            try
            {
                SPAProjectManager.Entities.Tasks tk = new SPAProjectManager.Entities.Tasks
                {
                    TaskID = task.TaskID,
                    Task = task.Task,
                    ProjectID = task.ProjectID,
                    Priority = task.Priority,
                    ParentTaskID = task.ParentTaskID,
                    StartDate = task.StartDate,
                    EndDate = task.EndDate,
                    UserID = task.UserID
                };

                _taskBL.UpdateTask(tk);
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        /// <summary>
        /// Add Parent Task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddParentTask")]
        public IHttpActionResult AddParentTask([FromBody]SPAProjectManager.Models.ParentTasks task)
        {
            try
            {
                SPAProjectManager.Entities.ParentTasks tk = new SPAProjectManager.Entities.ParentTasks
                {
                    //ParentTaskID=task.ParentTaskID,
                    Parent_Task = task.ParentTask
                };

                _taskBL.AddParentTask(tk);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        /// <summary>
        /// Get Parent Tasks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetParentTasks")]
        public IHttpActionResult GetParentTasks()
        {
            Collection<SPAProjectManager.Models.ParentTasks> parentTasks = new Collection<SPAProjectManager.Models.ParentTasks>();

            var blTasks = _taskBL.GetParentTasks();
            blTasks.ToList()
                .ForEach(t => parentTasks.Add(
                   new SPAProjectManager.Models.ParentTasks
                   {
                       ParentTaskID = t.ParentTaskID,
                       ParentTask = t.Parent_Task
                   }));
            return Ok(parentTasks);
        }
        /// <summary>
        /// Get Task by Project ID
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTasks/{projectID}")]
        public IHttpActionResult GetTasks(int projectID)
        {
            Collection<SPAProjectManager.Models.Tasks> tasks = new Collection<SPAProjectManager.Models.Tasks>();

            var blTasks = _taskBL.GetTasks(projectID);
            blTasks.ToList()
                .ForEach(s => tasks.Add(
                   new SPAProjectManager.Models.Tasks
                   {
                       Task = s.Task,
                       ProjectID = s.ProjectID,
                       Project = s.Project,
                       ParentTask = s.ParentTask,
                       Priority = s.Priority,
                       StartDate = s.StartDate,
                       EndDate = s.EndDate,
                       TaskID = s.TaskID,
                       Status = s.Status,
                       UserID = s.UserID,
                       UserName = s.UserName,
                       ParentTaskID=s.ParentTaskID
                   }));

            return Ok(tasks);
        }

        /// <summary>
        /// End Task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("EndTask")]
        public IHttpActionResult EndTask([FromBody]SPAProjectManager.Models.Tasks task)
        {
            try
            {
                SPAProjectManager.Entities.Tasks tk = new SPAProjectManager.Entities.Tasks
                {
                    TaskID = task.TaskID
                };
                _taskBL.EndTask(tk);
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}