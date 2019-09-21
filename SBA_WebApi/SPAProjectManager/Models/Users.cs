using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPAProjectManager.Models
{
    public class Users
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeID { get; set; }
        public int Project_ID { get; set; }
        public int Task_ID { get; set; }
    }
}