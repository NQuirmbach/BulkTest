using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulkTest.Model
{
    public class Student : Person
    {
        public string Class { get; set; }

        public Guid? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
