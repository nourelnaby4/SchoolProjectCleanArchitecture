using AutoMapper;
using MediatR;
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
    public class StudentHandler : IRequestHandler<GetStudentsQuery, IEnumerable<GetStudentsReponse>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentHandler(IStudentService studentService,IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetStudentsReponse>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var students= await _studentService.GetStudentsAsync();
            var studentsMapper = _mapper.Map<IEnumerable<GetStudentsReponse>>(students);

            return studentsMapper;
        }
    }
}
