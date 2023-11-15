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
        public void GetStudentByIdMapping() {

            CreateMap<Student, GetStudentByIdResponse>()
                 .ForMember(des => des.Name, option => option.MapFrom(src => src.getLanguageData(src.NameAr, src.NameEn)))
                 .ForMember(des => des.DepartmentName, options => options.MapFrom(src => src.getLanguageData(src.Department.NameAr,src.Department.NameEn)))
                 .ReverseMap();
        }
    }
}
