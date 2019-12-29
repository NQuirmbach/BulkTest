using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulkTest.Model
{
    public class Teacher : Person
    {
        public string Subjects { get; set; }
        public IList<Student> Students { get; set; }

        public Teacher()
        {
            Students = new List<Student>();
        }
    }
}
