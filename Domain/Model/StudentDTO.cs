using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class StudentDTO
    {
        [Key]
        public int StudentID { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public int Age { get; set; }
    }
}
