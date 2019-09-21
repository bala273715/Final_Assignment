using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using SPAProjectManager.Entities;


namespace SPAProjectManager.InterfaceLayer
{
    public interface IProjectsBL
    {
        Collection<SPAProjectManager.Entities.Projects> GetProjects();
        void AddProject(SPAProjectManager.Entities.Projects Project);
        void UpdateProject(SPAProjectManager.Entities.Projects Project);
        void SuspendProject(int ProjectID);
    }
}
