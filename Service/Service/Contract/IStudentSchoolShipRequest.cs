using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Contract
{
    public interface IStudentSchoolShipRequest
    {
        //Get All Records
        Task<List<StudentScholShipRequestDTO>> GetAll();
        //Get Single Record
        Task<StudentScholShipRequestDTO> GetById(int id);
        //Add Record
        Task<string> AddRequest(StudentScholShipRequestDTO objecto);
        //Update or Edit Record
        Task<string> UpdateRequest(StudentScholShipRequestDTO objecto);
        //Delete or Remove
        Task<string> RemoveRequest(int id);
        //Delete by Student Id
        Task<string> RemoveRequestbyStudent(int id);



    }
}
