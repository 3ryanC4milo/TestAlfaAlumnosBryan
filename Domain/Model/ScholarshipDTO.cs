using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ScholarshipDTO
    {
        [Key]
        public int ScholarShipID { get; set; }
        public string ScholarShipName { get; set; }
        public bool Active { get; set; }
    }
}
