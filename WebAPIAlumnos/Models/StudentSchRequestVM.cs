using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIAlumnos.Models
{
    public class StudentSchRequestVM
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public int Age { get; set; }
        public string Request { get; set; }
        public bool Culture { get; set; }
        public bool Sports { get; set; }
        public bool Educational { get; set; }
        public int RequestID { get; set; }
        public int ScholarShipID { get; set; }
    }
}
