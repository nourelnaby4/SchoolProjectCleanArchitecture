using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using School.Core.Bases;
using School.Core.Features.Students.Queries.Models;
using School.Core.Features.Students.Queries.Responses;
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
        public StudentQueryHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetStudentsResponse>>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentService.GetStudentsAsync();
            var studentsMapper = _mapper.Map<IEnumerable<GetStudentsResponse>>(students);
            return Success(studentsMapper, string.Empty);
        }


        public async Task<Response<GetStudentByIdResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.id);
            var studentMapping = _mapper.Map<GetStudentByIdResponse>(student);
            return Success(studentMapping, string.Empty);
        }

        public async Task<PaginatedResult<GetStudentsPaginatedResponse>> Handle(GetStudentsPaginatedQuery request, CancellationToken cancellationToken)
        {
            var queryableStudent = _studentService.GetQueryableStudentPaginated(request.Search,request.OrderBy);

            Expression<Func<Student, GetStudentsPaginatedResponse>> selectExpression = e => new GetStudentsPaginatedResponse
            {
                Id = e.Id,
                Name = e.Name,
                Address = e.Address,
                Phone = e.Phone,
                DepartmentName = e.Department.Name
            };
            var SelectQueryableStudent = queryableStudent.Select(selectExpression);
            var paginatedStudents =await SelectQueryableStudent.ToPaginatedListAsync(request.PageNumber,request.PageSize);
            return paginatedStudents;


        }
    }
}
