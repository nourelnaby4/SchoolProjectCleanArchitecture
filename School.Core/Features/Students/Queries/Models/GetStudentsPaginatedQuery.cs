using MediatR;
using School.Core.Features.Students.Queries.Responses;
using School.Core.Wrapper;
using School.Data.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Features.Students.Queries.Models
{
    public class GetStudentsPaginatedQuery : IRequest<PaginatedResult<GetStudentsPaginatedResponse>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public StudentOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
