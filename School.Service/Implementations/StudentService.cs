using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Infrastructure.IRepositories;
using School.Infrastructure.Repositories;
using School.Service.Abstracts;
using School.Service.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Linq.Expressions;
using School.Data.Helper;

namespace School.Service.Implementations
{
    public class StudentService : IStudentService
    {
        #region fields
        private readonly IStudentRepository _studentRepository;

        #endregion


        #region
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        #endregion



        #region functions

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _studentRepository.GetTableNoTracking().ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task<Response> AddStudentAsync(Student student)
        {

            await _studentRepository.AddAsync(student);
            return new Response { IsSuccess = true, Message = "Added Successfully", StatusCode = HttpStatusCode.Created };
        }
        public async Task<Response> EditStudentAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return new Response { IsSuccess = true, Message = "Edit Successfully", StatusCode = HttpStatusCode.OK };

        }
        public async Task<bool> IsExistNameAsync(string name)
        {
            return await _studentRepository.IsExistAsync(x => x.Name == name);
        }
        public async Task<bool> IsExistIdAsync(int id)
        {
            return await _studentRepository.IsExistAsync(x => x.Id == id);
        }
        public IQueryable<Student> IQueryableStudents()
        {
            return _studentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
        }
        public IQueryable<Student> GetQueryableStudentPaginated(string search, StudentOrderingEnum orderingEnum)
        {
            var queryable = _studentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                queryable = queryable.Where(x =>
                    x.Name.Contains(search)    ||
                    x.Address.Contains(search) ||
                    x.Phone.Contains(search)   ||
                    x.Department.Name.Contains(search));
            }
            switch (orderingEnum)
            {
                case StudentOrderingEnum.Name:
                    queryable=queryable.OrderBy(x=>x.Name); 
                    break;
                case StudentOrderingEnum.Address:
                    queryable = queryable.OrderBy(x => x.Address);
                    break;
                case StudentOrderingEnum.Phone:
                    queryable = queryable.OrderBy(x => x.Phone);
                    break;
                case StudentOrderingEnum.DepartmentName:
                    queryable = queryable.OrderBy(x => x.Department.Name);
                    break;
                default:
                    queryable = queryable.OrderBy(x => x.Id);
                    break;
            }

            return queryable;
        }

        public async Task<bool> IsExistNameExpectYourNameAsync(string name, int id)
        {
            return await _studentRepository.IsExistAsync(x => x.Name == name && x.Id != id);
        }


        #endregion


    }
}
