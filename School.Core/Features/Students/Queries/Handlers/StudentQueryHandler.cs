using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Localization;
using School.Core.Bases;
using School.Core.Features.Students.Queries.Models;
using School.Core.Features.Students.Queries.Responses;
using School.Core.SharedResources;
using School.Core.Wrapper;
using School.Data.Entities;
using School.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler
                                 , IRequestHandler<GetStudentsQuery, Response<IEnumerable<GetStudentsResponse>>>
                                 , IRequestHandler<GetStudentByIdQuery, Response<GetStudentByIdResponse>>
                                 , IRequestHandler<GetStudentsPaginatedQuery, PaginatedResult<GetStudentsPaginatedResponse>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<Resource> _localizer;
        public StudentQueryHandler(IStudentService studentService, IMapper mapper,IStringLocalizer<Resource> localizer) :base(localizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _localizer =  localizer;
        }

        public async Task<Response<IEnumerable<GetStudentsResponse>>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentService.GetStudentsAsync();
            var studentsMapper = _mapper.Map<IEnumerable<GetStudentsResponse>>(students);
            var meta=new {Count= studentsMapper.Count()};
            return Success(studentsMapper, string.Empty,meta);
        }


        public async Task<Response<GetStudentByIdResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.id);
            var studentsMapper = _mapper.Map<GetStudentByIdResponse>(student);
           

            return Success(studentsMapper, string.Empty);
        }

        public async Task<PaginatedResult<GetStudentsPaginatedResponse>> Handle(GetStudentsPaginatedQuery request, CancellationToken cancellationToken)
        {
            var queryableStudent = _studentService.GetQueryableStudentPaginated(request.Search,request.OrderBy);

            Expression<Func<Student, GetStudentsPaginatedResponse>> selectExpression = e => new GetStudentsPaginatedResponse
            {
                Id = e.Id,
                Name = e.NameEn,
                Address = e.Address,
                Phone = e.Phone,
                DepartmentName = e.Department.NameEn
            };
            var SelectQueryableStudent = queryableStudent.Select(selectExpression);
            var paginatedStudents =await SelectQueryableStudent.ToPaginatedListAsync(request.PageNumber,request.PageSize);
            paginatedStudents.Meta=new {Count= paginatedStudents.Data.Count()};
            return paginatedStudents;


        }
    }
}
