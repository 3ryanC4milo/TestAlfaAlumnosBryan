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
    public class StudentService : IStudents
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> AddStudent(StudentDTO objecto)
        {

            try
            {
                await _dbContext.Students.AddAsync(objecto);
                await _dbContext.SaveChangesAsync();
                return "Success";

            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<StudentDTO>> GetAll()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<StudentDTO> GetById(int id)
        {
            return await _dbContext.Students.FindAsync(id);
        }

        public async Task<string> RemoveStudent(int id)
        {
            try
            {
                var obj = await _dbContext.Students.FindAsync(id);
                if(obj != null)
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

        public async Task<string> UpdateStudent(StudentDTO objecto)
        {
            try
            {
                _dbContext.Students.Update(objecto);
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
