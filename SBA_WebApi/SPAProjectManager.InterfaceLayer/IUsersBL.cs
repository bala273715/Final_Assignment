using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SPAProjectManager.InterfaceLayer
{
   public interface IUsersBL
    {
        void AddUser(SPAProjectManager.Entities.Users user);
        void UpdateUser(SPAProjectManager.Entities.Users user);
        void DeleteUser(SPAProjectManager.Entities.Users user);
        Collection<SPAProjectManager.Entities.Users> GetUsers();

    }
}
