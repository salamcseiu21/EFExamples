using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMvcCore.Models
{
    public class Department 
    {
        public Department()
        {
            
        }

        public Department(string deptName)
        {
          
            DeptName = deptName;
        }

        public int Id { get; set; }
        public string DeptName { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

    }
}
