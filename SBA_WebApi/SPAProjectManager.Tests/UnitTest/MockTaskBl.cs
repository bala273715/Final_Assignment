using SPAProjectManager_DL;
using SPAProjectManager.InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SPAProjectManager.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPAProjectManager_BL;

namespace SPAProjectManager.Tests.UnitTest
{
    public class MockTaskBl:ITasksBL
    {
        public Collection<SPAProjectManager.Entities.Tasks> GetTasks(int projectID)
        {
            SPAProjectManagerEntities mockContext = MockDataSetList();
            var taskBL = new TaskBL(mockContext);
            Collection<SPAProjectManager.Entities.Tasks> tasks = taskBL.GetTasks(projectID);

            return tasks;
        }

        public Collection<SPAProjectManager.Entities.ParentTasks> GetParentTasks()
        {
            SPAProjectManagerEntities mockContext = MockDataSetList();
            var taskBL = new TaskBL(mockContext);
            Collection<SPAProjectManager.Entities.ParentTasks> tasks = taskBL.GetParentTasks();

            return tasks;
        }

        public void AddTask(SPAProjectManager.Entities.Tasks task)
        {
            SPAProjectManagerEntities mockContext = MockDataSetList();
            var taskBL = new TaskBL(mockContext);
            taskBL.AddTask(task);
        }

        public void AddParentTask(SPAProjectManager.Entities.ParentTasks task)
        {
            SPAProjectManagerEntities mockContext = MockDataSetList();
            var taskBL = new TaskBL(mockContext);
            taskBL.AddParentTask(task);
        }

        public void UpdateTask(SPAProjectManager.Entities.Tasks task)
        {
            SPAProjectManagerEntities mockContext = MockDataSetList();
            var taskBL = new TaskBL(mockContext);
            taskBL.UpdateTask(task);
        }

        public void EndTask(SPAProjectManager.Entities.Tasks task)
        {
           SPAProjectManagerEntities mockContext = MockDataSetList();
            var taskBL = new TaskBL(mockContext);
            taskBL.EndTask(task);
        }

        private static SPAProjectManagerEntities MockDataSetList()
        {
            MockProjectManager mockProj = new MockProjectManager();
            SPAProjectManagerEntities mockContext = mockProj.MockDataSetList();

            return mockContext;
        }
    }
}
