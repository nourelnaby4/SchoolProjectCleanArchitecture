using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using School.Data.Entities;
using School.Data.Helper;
using School.Infrastructure.IRepositories;
using School.Service.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School.Service.Abstracts
{
    public interface IStudentService 
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task<Response> AddStudentAsync(Student student);
        Task<Response> EditStudentAsync(Student student);
        Task<bool> IsExistNameAsync(string name);
        Task<bool> IsExistIdAsync(int id);
        Task<bool> IsExistNameExpectYourNameAsync(string name, int id);
        IQueryable<Student> IQueryableStudents();
        IQueryable<Student> GetQueryableStudentPaginated( string search, StudentOrderingEnum orderingEnum);

    }
}
