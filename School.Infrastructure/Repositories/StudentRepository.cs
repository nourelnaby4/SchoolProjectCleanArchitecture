﻿using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Infrastructure.Data;
using School.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastructure.Repositories
{
   
    public class StudentRepository:GenericRepositoryAsync<Student>,IStudentRepository
    {
        #region fields
        private readonly ApplicationDbContext _context;
        #endregion




        #region contructors
        public StudentRepository(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }
        #endregion


    }
}
