﻿using School.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastructure.IRepositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
    }
}