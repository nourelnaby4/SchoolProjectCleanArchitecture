﻿using AutoMapper;
using School.Core.Features.Students.Queries.Responses;
using School.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Mapping.StudentMapping
{
    public partial class StudentProfile :Profile
    {
        public StudentProfile()
        {
            GetStudentsMapping();
            GetStudentByIdMapping();
            CreateStudentMapping();
            EditStudentMapping();
        }
    }
}
