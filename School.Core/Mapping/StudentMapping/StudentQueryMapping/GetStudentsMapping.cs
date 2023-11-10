using School.Core.Features.Students.Queries.Responses;
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
        public void GetStudentsMapping()
        {
            CreateMap<Student, GetStudentsResponse>()
                .ForMember(des => des.DepartmentName, option => option.MapFrom(src => src.Department.Name))
                .ReverseMap();
        }
    }
}
