using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SPAProjectManager.InterfaceLayer
{
    public interface ITasksBL
    {
        void AddTask(SPAProjectManager.Entities.Tasks task);
        void AddParentTask(SPAProjectManager.Entities.ParentTasks pTask);
        void EndTask(SPAProjectManager.Entities.Tasks task);
        void UpdateTask(SPAProjectManager.Entities.Tasks task);
        Collection<SPAProjectManager.Entities.ParentTasks> GetParentTasks();
        Collection<SPAProjectManager.Entities.Tasks> GetTasks(int ProjectID);
    }
}
