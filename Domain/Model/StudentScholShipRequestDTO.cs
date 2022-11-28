using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class StudentScholShipRequestDTO
    {
        [Key]
        public int RequestID { get; set; }
        public string Request { get; set; }
        public bool Culture { get; set; }
        public bool Sports { get; set; }
        public bool Educational { get; set; }
        public DateTime CreateDate { get; set; }
        public int StudentID { get; set; }
        public int ScholarShipID { get; set; }
    }
}
