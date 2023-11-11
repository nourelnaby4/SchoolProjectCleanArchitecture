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
            if (await _studentRepository.IsExist(x => x.Name == student.Name))
            {
                return new Response { IsSuccess = false, Message = "student is Exist",StatusCode=HttpStatusCode.BadRequest };
            }
            await _studentRepository.AddAsync(student);
            return new Response { IsSuccess = true, Message = "Added Successfully",StatusCode=HttpStatusCode.Created };
        }



        #endregion


    }
}
