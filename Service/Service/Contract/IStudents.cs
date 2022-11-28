using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Contract
{
    public interface IStudents
    {
        //Get All Records
        Task<List<StudentDTO>> GetAll();
        //Get Single Record
        Task<StudentDTO> GetById(int id);
        //Add Record
        Task<string> AddStudent(StudentDTO objecto);
        //Update or Edit Record
        Task<string> UpdateStudent(StudentDTO objecto);
        //Delete or Remove
        Task<string> RemoveStudent(int id);
    }
}
