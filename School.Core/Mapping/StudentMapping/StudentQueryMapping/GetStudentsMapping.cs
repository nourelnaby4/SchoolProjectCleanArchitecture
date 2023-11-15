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
                .ForMember(des => des.DepartmentName, option => option.MapFrom(src => src.getLanguageData(src.Department.NameAr, src.Department.NameAr)))
                .ForMember(des => des.Name, option => option.MapFrom(src => src.getLanguageData(src.NameAr, src.NameEn)))
                .ReverseMap();
        }
    }
}
