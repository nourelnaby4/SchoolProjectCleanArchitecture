using School.Core.Features.Students.Commands.Models;
using School.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void CreateStudentMapping()
        {
            CreateMap<CreateStudentCommand,Student>().ReverseMap();
        }
    }
}
