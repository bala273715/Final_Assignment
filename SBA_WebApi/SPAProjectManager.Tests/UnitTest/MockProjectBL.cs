using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPAProjectManager_DL;
using SPAProjectManager.InterfaceLayer;
using  SPAProjectManager.Entities;
using SPAProjectManager_BL;
using System.Collections.ObjectModel;

namespace SPAProjectManager.Tests.UnitTest
{

    public class MockProjectBL:IProjectsBL
    {
        public Collection<SPAProjectManager.Entities.Projects> GetProjects()
        {
            SPAProjectManagerEntities mockContext = MockDataSetList();
            var projectBL = new ProjectBL(mockContext);
            Collection<SPAProjectManager.Entities.Projects> projects = projectBL.GetProjects();

            return projects;
        }

        public void AddProject(SPAProjectManager.Entities.Projects project)
        {
            SPAProjectManagerEntities mockContext = MockDataSetList();
            var projectBL = new ProjectBL(mockContext);
            projectBL.AddProject(project);
        }

        public void UpdateProject(SPAProjectManager.Entities.Projects project)
        {
            SPAProjectManagerEntities mockContext = MockDataSetList();
            var projectBL = new ProjectBL(mockContext);
            projectBL.UpdateProject(project);
        }

        public void SuspendProject(int projectID)
        {
            SPAProjectManagerEntities mockContext = MockDataSetList();
            var projectBL = new ProjectBL(mockContext);
            projectBL.SuspendProject(projectID);
        }

        private static SPAProjectManagerEntities MockDataSetList()
        {
            MockProjectManager mockProj = new MockProjectManager();
            SPAProjectManagerEntities mockContext = mockProj.MockDataSetList();

            return mockContext;
        }

    }
}