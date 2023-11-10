using School.Data.Entities;
using School.Infrastructure.IRepositories;
using School.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Service.Implementations
{
    public class StudentService: IStudentService
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
            return await _studentRepository.GetAllAsync();
        }

        #endregion


    }
}
