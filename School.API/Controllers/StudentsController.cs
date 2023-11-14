using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Core.Bases;
using School.Core.Features.Students.Commands.Models;
using School.Core.Features.Students.Commands.Validations;
using School.Core.Features.Students.Queries.Models;
using School.Data.MetaData;
using System.Net;

namespace School.API.Controllers
{
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ControllerResponse _response;
        public StudentsController(IMediator mediator,ControllerResponse response) 
        {
            _mediator = mediator;
            _response = response;
        }

        [HttpGet(StudentRouting.Prefix)]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetStudentsQuery());
            return Ok(result);
        }

        [HttpGet(StudentRouting.GetById)]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var result = await _mediator.Send(new GetStudentByIdQuery(id));
            return Ok(result);
        }
        [HttpGet(StudentRouting.Paginated)]
        public async Task<IActionResult> PaginatedStudents([FromQuery] GetStudentsPaginatedQuery getStudentsPaginatedQuery)
        {
            var result = await _mediator.Send(getStudentsPaginatedQuery);
            return Ok(result);
        }

        [HttpPost(StudentRouting.Prefix)]
        public async Task<IActionResult> Create([FromBody] CreateStudentCommand createStudentCommand)
        {
            
            var result = await _mediator.Send(createStudentCommand);
            return _response.NewResult(result);
        }

        [HttpPut(StudentRouting.Prefix)]
        public async Task<IActionResult> Edit([FromBody] EditStudentCommand editStudentCommand)
        {
            var result = await _mediator.Send(editStudentCommand);
            return _response.NewResult(result);
        }

      

    }


}
