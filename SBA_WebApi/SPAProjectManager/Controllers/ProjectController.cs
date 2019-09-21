using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SPAProjectManager.Entities;
using SPAProjectManager.InterfaceLayer;
using SPAProjectManager_BL;
using SPAProjectManager_DL;
using System.Collections.ObjectModel;

namespace SPAProjectManager.Controllers
{
    /// <summary>
    /// Projects 
    /// </summary>
    [RoutePrefix("api/Projects")]
    public class ProjectController : ApiController
    {
        private readonly IProjectsBL _projectBL = null;

        /// <summary>
        /// Project Controller Constructor
        /// </summary>
        public ProjectController()
        {
            _projectBL = new ProjectBL();
        }

        /// <summary>
        /// Parameterized COnstructor
        /// </summary>
        /// <param name="projectBL"></param>
        public ProjectController(IProjectsBL projectBL)
        {
            _projectBL = projectBL;
        }
        /// <summary>
        /// Get Projects
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetProjects")]
        public IHttpActionResult GetProjects()
        {
            Collection<SPAProjectManager.Models.Projects> projects = new Collection<SPAProjectManager.Models.Projects>();

            var blProjects = _projectBL.GetProjects();
            blProjects.ToList()
                .ForEach(project => projects.Add(
                   new SPAProjectManager.Models.Projects
                   {
                       ProjectID = project.ProjectID,
                       Project = project.Project,
                       StartDate = project.StartDate,
                       EndDate = project.EndDate,
                       Priority = project.Priority,
                       ManagerID = project.ManagerID,
                       ManagerName = project.ManagerName,
                       NoofTasks = project.NoofTasks,
                       NoofCompletedTasks = project.NoofCompletedTasks
                   }));

            return Ok(projects);
        }

        /// <summary>
        /// Add Project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddProject")]
        public IHttpActionResult AddProject([FromBody]SPAProjectManager.Models.Projects project)
        {
            try
            {
                SPAProjectManager.Entities.Projects proj = new SPAProjectManager.Entities.Projects
                {
                   // ProjectID=project.ProjectID,
                    Project = project.Project,
                    StartDate = project.StartDate,
                    EndDate = project.EndDate,
                    Priority = project.Priority,
                    ManagerID = project.ManagerID
                };

                _projectBL.AddProject(proj);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        /// <summary>
        /// Update Project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateProject")]
        public IHttpActionResult UpdateProject([FromBody]SPAProjectManager.Models.Projects project)
        {
            try
            {
                SPAProjectManager.Entities.Projects proj = new SPAProjectManager.Entities.Projects
                {
                    ProjectID = project.ProjectID,
                    Project = project.Project,
                    StartDate = project.StartDate,
                    EndDate = project.EndDate,
                    Priority = project.Priority,
                    ManagerID = project.ManagerID
                };

                _projectBL.UpdateProject(proj);
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        /// <summary>
        /// Suspend Project
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("SuspendProject")]
        public IHttpActionResult SuspendProject([FromBody]int projectID)
        {
            try
            {
                _projectBL.SuspendProject(projectID);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}
