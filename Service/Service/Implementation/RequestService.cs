using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Implementation
{
    public class RequestService : IStudentSchoolShipRequest
    {
        private readonly ApplicationDbContext _dbContext;
        public RequestService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<string> AddRequest(StudentScholShipRequestDTO objecto)
        {
            try
            {
                objecto.CreateDate = DateTime.Now;
                await _dbContext.StudentsRequests.AddAsync(objecto);
                await _dbContext.SaveChangesAsync();
                return "Success";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<StudentScholShipRequestDTO>> GetAll()
        {
            return await _dbContext.StudentsRequests.ToListAsync();
        }

        public async Task<StudentScholShipRequestDTO> GetById(int id)
        {
            return await _dbContext.StudentsRequests.FindAsync(id);
        }

        public async Task<string> RemoveRequest(int id)
        {
            try
            {
                var obj = await _dbContext.StudentsRequests.FindAsync(id);
                if (obj != null)
                {
                    _dbContext.Remove(obj);
                    await _dbContext.SaveChangesAsync();
                    return "Removed";
                }

                return "NotFound";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> RemoveRequestbyStudent(int id)
        {
            try
            {
                var lst = await _dbContext.StudentsRequests.Where(x=> x.StudentID == id).ToListAsync();
                if (lst.Count > 0)
                {
                    _dbContext.RemoveRange(lst);
                    await _dbContext.SaveChangesAsync();
                    return "Removed";
                }

                return "NotFound";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> UpdateRequest(StudentScholShipRequestDTO objecto)
        {
            try
            {
                _dbContext.StudentsRequests.Update(objecto);
                await _dbContext.SaveChangesAsync();
                return "Updated";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
