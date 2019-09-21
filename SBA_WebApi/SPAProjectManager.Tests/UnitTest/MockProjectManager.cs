using NSubstitute;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SPAProjectManager_DL;

namespace SPAProjectManager.Tests.UnitTest
{
    public class MockProjectManager
    {
        public SPAProjectManager_DL.SPAProjectManagerEntities MockDataSetList()
        {
            var dataProjects = new List<Project>()
            {
                new Project
                {
                    Project_ID=1,
                    Project1="Project 1",
                    Start_Date=DateTime.Now.Date,
                    End_Date=DateTime.Now.Date.AddDays(1)
                },
                new Project
                {
                    Project_ID=2,
                    Project1="Project 2",
                    Start_Date=DateTime.Now.Date,
                    End_Date=DateTime.Now.Date.AddDays(1)
                },
                new Project
                {
                    Project_ID=3,
                    Project1="Project 3",
                    Start_Date=DateTime.Now.Date,
                    End_Date=DateTime.Now.Date.AddDays(1)
                }
        }.AsQueryable();

            IDbSet<Project> mocksetProjects = Substitute.For<IDbSet<Project>>();
            mocksetProjects.Provider.Returns(dataProjects.Provider);
            mocksetProjects.Expression.Returns(dataProjects.Expression);
            mocksetProjects.ElementType.Returns(dataProjects.ElementType);
            mocksetProjects.GetEnumerator().Returns(dataProjects.GetEnumerator());

            var dataUsers = new List<User>()
            {
                new User
                {
                    User_ID=1,
                    Project_ID=1,
                    FirstName="Yagavi",
                    LastName="Babu",
                    Employee_ID=1100
                },
                new User
                {
                    User_ID=2,
                    Project_ID=1,
                    FirstName="Babu",
                    LastName="Yagavi",
                    Employee_ID=1100
                },
                new User
                {
                    User_ID =3,
                    Project_ID =2,
                    FirstName="Yagaavi",
                    LastName="Babu",
                    Employee_ID=11002
                }
        }.AsQueryable();

            IDbSet<User> mocksetUsers = Substitute.For<IDbSet<User>>();
            mocksetUsers.Provider.Returns(dataUsers.Provider);
            mocksetUsers.Expression.Returns(dataUsers.Expression);
            mocksetUsers.ElementType.Returns(dataUsers.ElementType);
            //var variable1 = ;
            mocksetUsers.GetEnumerator().Returns(dataUsers.GetEnumerator());

            var dataTasks = new List<SPAProjectManager_DL.Task>()
            {
                new SPAProjectManager_DL.Task
                {
                    Task_ID=1,
                    Task1="Task 1",
                    Project_ID=1,
                    Priority=10,
                    Start_Date=DateTime.Now.Date,
                    End_Date=DateTime.Now.Date.AddDays(1)
                },
                new SPAProjectManager_DL.Task
                {
                    Task_ID=2,
                    Task1="Task 2",
                    Project_ID=1,
                    Priority=20,
                    Start_Date=DateTime.Now.Date,
                    End_Date=DateTime.Now.Date.AddDays(1),
                    Status=true
                },
                new SPAProjectManager_DL.Task
                {
                   Task_ID=3,
                    Task1="Task 3",
                    Project_ID=2,
                    Priority=10,
                    Start_Date=DateTime.Now.Date,
                    End_Date=DateTime.Now.Date.AddDays(1)
                },
                new SPAProjectManager_DL.Task
                {
                   Task_ID=4,
                    Task1="Task 4",
                    Project_ID=2,
                    Priority=20,
                    Start_Date=DateTime.Now.Date,
                    End_Date=DateTime.Now.Date.AddDays(1),
                    Status=true
                }
        }.AsQueryable();

            IDbSet<SPAProjectManager_DL.Task> mocksetTasks = Substitute.For<IDbSet<SPAProjectManager_DL.Task>>();
            mocksetTasks.Provider.Returns(dataTasks.Provider);
            mocksetTasks.Expression.Returns(dataTasks.Expression);
            mocksetTasks.ElementType.Returns(dataTasks.ElementType);
     
            mocksetTasks.GetEnumerator().Returns(dataTasks.GetEnumerator());

            var dataPTasks = new List<Parent_Task>()
            {
                new Parent_Task
                {
                    Parent_ID=1,
                    ParentTask="Parent Task 1"
                },
                new Parent_Task
                {
                    Parent_ID=2,
                    ParentTask="Parent Task 2"
                }
        }.AsQueryable();

            IDbSet<Parent_Task> mocksetPTasks = Substitute.For<IDbSet<Parent_Task>>();
            mocksetPTasks.Provider.Returns(dataPTasks.Provider);
            mocksetPTasks.Expression.Returns(dataPTasks.Expression);
            mocksetPTasks.ElementType.Returns(dataPTasks.ElementType);
            mocksetPTasks.GetEnumerator().Returns(dataPTasks.GetEnumerator());

            SPAProjectManagerEntities mockContext = Substitute.For<SPAProjectManagerEntities>();
            mockContext.Projects.Returns(mocksetProjects);
            mockContext.Users.Returns(mocksetUsers);
            mockContext.Tasks.Returns(mocksetTasks);
            mockContext.Parent_Task.Returns(mocksetPTasks);

            return mockContext;
        }

    }
}
