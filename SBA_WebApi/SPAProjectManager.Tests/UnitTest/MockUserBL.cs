using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPAProjectManager.Entities;
using SPAProjectManager.InterfaceLayer;
using SPAProjectManager_BL;
using SPAProjectManager_DL;
using System.Collections.ObjectModel;

namespace SPAProjectManager.Tests.UnitTest
{
    public class MockUserBL : IUsersBL
    {
        SPAProjectManagerEntities mockContext = MockDataSetList();

        public Collection<SPAProjectManager.Entities.Users> GetUsers()
        {
            var userBL = new UsersBL(mockContext);
            Collection<SPAProjectManager.Entities.Users> users = userBL.GetUsers();

            return users;
        }

        public void AddUser(SPAProjectManager.Entities.Users user)
        {
            var userBL = new UsersBL(mockContext);
            userBL.AddUser(user);
        }

        public void UpdateUser(SPAProjectManager.Entities.Users user)
        {
            var userBL = new UsersBL(mockContext);
            userBL.UpdateUser(user);
        }

        public void DeleteUser(SPAProjectManager.Entities.Users user)
        {
            var userBL = new UsersBL(mockContext);
            userBL.DeleteUser(user);
        }

        private static SPAProjectManagerEntities MockDataSetList()
        {
            MockProjectManager mockProj = new MockProjectManager();
            SPAProjectManagerEntities mockContext = mockProj.MockDataSetList();

            return mockContext;
        }
    }
}


