using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using School.Core.Bases;
using School.Core.Features.Students.Commands.Models;
using School.Core.SharedResources;
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
                                , IRequestHandler<EditStudentCommand, Response<Student>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer _localizer;
        public StudentCommandHandler(IStudentService studentService,IMapper mapper,IStringLocalizer<Resource> localizer):base(localizer)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        public async Task<Response<Student>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
           var studentMapping=_mapper.Map<Student>(request);
           var result=  await _studentService.AddStudentAsync(studentMapping);
            if (!result.IsSuccess)
                return UnprocessableEntity<Student>();

            return Success(studentMapping);
            
        }

        public async Task<Response<Student>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var student =await _studentService.GetStudentByIdAsync(request.Id);
            if(student is null)
            {
                return NotFound<Student>();
            }
            var studentMapping= _mapper.Map(request,student);
            var result = await _studentService.EditStudentAsync(studentMapping);
            if (!result.IsSuccess)
                return UnprocessableEntity<Student>();

            return EditSuccess(studentMapping);
        }
    }
}
