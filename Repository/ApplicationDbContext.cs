using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<StudentDTO> Students { get; set; }
        public DbSet<ScholarshipDTO> ScholarShips { get; set; }
        public DbSet<StudentScholShipRequestDTO> StudentsRequests { get; set; }
    }
}
