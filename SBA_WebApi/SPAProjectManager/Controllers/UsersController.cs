using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SPAProjectManager.Entities;
using SPAProjectManager_DL;
using SPAProjectManager.InterfaceLayer;
using SPAProjectManager_BL;
using System.Collections.ObjectModel;

namespace SPAProjectManager.Controllers
{
    /// <summary>
    /// Users Controller
    /// </summary>
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        private readonly IUsersBL _userBL = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public UsersController()
        {
            _userBL = new UsersBL();
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="userBL"></param>
        public UsersController(IUsersBL userBL)
        {
            _userBL = userBL;
        }
        /// <summary>
        /// Get Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUsers")]
        public IHttpActionResult GetUsers()
        {
            Collection<SPAProjectManager.Models.Users> users = new Collection<SPAProjectManager.Models.Users>();

            var blProjects = _userBL.GetUsers();
            blProjects.ToList()
                .ForEach(ur => users.Add(
                   new SPAProjectManager.Models.Users
                   {
                       UserID = ur.UserID,
                       FirstName = ur.FirstName,
                       LastName = ur.LastName,
                       EmployeeID = ur.EmployeeID
                   }));

            return Ok(users);
        }
        /// <summary>
        /// Add Users
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddUser")]
        public IHttpActionResult AddUser([FromBody]SPAProjectManager.Models.Users user)
        {
            try
            {
                SPAProjectManager.Entities.Users usr = new SPAProjectManager.Entities.Users
                {
                   // UserID = user.UserID,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    EmployeeID = user.EmployeeID
                };

                _userBL.AddUser(usr);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateUser")]
        public IHttpActionResult UpdateUser([FromBody]SPAProjectManager.Models.Users user)
        {
            try
            {
                SPAProjectManager.Entities.Users usr = new SPAProjectManager.Entities.Users
                {
                    UserID = user.UserID,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    EmployeeID = user.EmployeeID
                };

                _userBL.UpdateUser(usr);
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteUser")]
        public IHttpActionResult DeleteUser([FromBody]SPAProjectManager.Models.Users user)
        {
            try
            {
                SPAProjectManager.Entities.Users usr = new SPAProjectManager.Entities.Users
                {
                    UserID = user.UserID,
                    //FirstName = user.FirstName,
                    //LastName = user.LastName,
                    //EmployeeID = user.EmployeeID
                };
                _userBL.DeleteUser(usr);
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}