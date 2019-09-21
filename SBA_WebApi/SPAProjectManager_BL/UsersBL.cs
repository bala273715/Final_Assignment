using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPAProjectManager.Entities;
using SPAProjectManager_DL;
using System.Collections.ObjectModel;
using System.Data.Entity;
using SPAProjectManager.InterfaceLayer;
namespace SPAProjectManager_BL
{
    public class UsersBL:IUsersBL
    {
        private readonly SPAProjectManagerEntities _projectManager;

        public UsersBL()
        {
            _projectManager = new SPAProjectManagerEntities();
        }

        public UsersBL(SPAProjectManagerEntities projectManager)
        {
            _projectManager = projectManager;
        }

        public Collection<SPAProjectManager.Entities.Users> GetUsers()
        {

            Collection<SPAProjectManager.Entities.Users> userCollection = new Collection<SPAProjectManager.Entities.Users>();
            _projectManager.Users
                .Select(u => new SPAProjectManager.Entities.Users()
                {
                    UserID = u.User_ID,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    EmployeeID = u.Employee_ID.ToString()
                }).ToList()
               .ForEach(y => userCollection.Add(y));

            return userCollection;
        }

        public void AddUser(SPAProjectManager.Entities.Users user)
        {
            User ur = new User
            {
               //User_ID = user.UserID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Employee_ID =(Convert.ToInt32( user.EmployeeID))
            };

            _projectManager.Users.Add(ur);
            _projectManager.SaveChanges();
        }

        public void UpdateUser(SPAProjectManager.Entities.Users user)
        {
            var ur = _projectManager.Users.Where(x => x.User_ID == user.UserID).FirstOrDefault();
            if (ur != null)
            {
                ur.User_ID = user.UserID;
                ur.FirstName = user.FirstName;
                ur.LastName = user.LastName;
                ur.Employee_ID = Convert.ToInt32(user.EmployeeID);
                _projectManager.SaveChanges();
            }
        }

        public void DeleteUser(SPAProjectManager.Entities.Users user)
        {
            User ur = new User
            {
                User_ID = user.UserID
            };
            _projectManager.Entry(ur).State = EntityState.Deleted;
            _projectManager.SaveChanges();
        }
    }
}