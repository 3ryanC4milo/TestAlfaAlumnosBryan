using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIAlumnos.Models
{
    public class StudentReports
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public bool Culture { get; set; }
        public bool Sports { get; set; }
        public bool Educational { get; set; }
    }
}
