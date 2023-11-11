using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.Students.Commands.Models;
using School.Data.Entities;
using School.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler
                                , IRequestHandler<CreateStudentCommand, Response< Student>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentCommandHandler(IStudentService studentService,IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        public async Task<Response<Student>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var StudentAddDTOMapping=_mapper.Map<Student>(request);
           var result=  await _studentService.AddStudentAsync(StudentAddDTOMapping);

            if (!result.IsSuccess)
                return UnprocessableEntity<Student>(result.Message);

            return Created(StudentAddDTOMapping);


            
        }
    }
}
