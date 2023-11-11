using School.Data.Entities;
using School.Infrastructure.IRepositories;
using School.Service.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Service.Abstracts
{
    public interface IStudentService 
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task<Response> AddStudentAsync(Student student);
    }
}
