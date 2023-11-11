using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Core.Bases;
using School.Core.Features.Students.Queries.Models;
using School.Core.Features.Students.Queries.Responses;
using School.Data.Entities;
using School.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler
                                 , IRequestHandler<GetStudentsQuery, Response<IEnumerable<GetStudentsResponse>>>
                                 ,IRequestHandler<GetStudentByIdQuery,Response<GetStudentByIdResponse>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentQueryHandler(IStudentService studentService,IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetStudentsResponse>>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var students= await _studentService.GetStudentsAsync();
            var studentsMapper = _mapper.Map<IEnumerable<GetStudentsResponse>>(students);
            return Success(studentsMapper);
        }


        public async Task<Response<GetStudentByIdResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.id);
            var studentMapping = _mapper.Map<GetStudentByIdResponse>(student);
            return Success(studentMapping);
        }
    }
}
