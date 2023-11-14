using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using School.Core.Features.Students.Commands.Models;
using School.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Features.Students.Commands.Validations
{
    public class EditStudentValidator :AbstractValidator<EditStudentCommand>
    {
        #region fields
        private readonly IStudentService _studentService;
        #endregion


        #region constractur
        public EditStudentValidator(IStudentService studentService)
        {
            ApplyValidationsRule();
            ApplyCustomValidationRule();
            _studentService = studentService;
        }
        #endregion


        #region functions
        public void ApplyValidationsRule()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("{PropertyName} Must Not be NULL")
                .NotEmpty().WithMessage("{PropertyName} Must Not be Empty")
                .MaximumLength(20).WithMessage("Max Length is 10");

         
            RuleFor(x => x.Address)
               .NotNull().WithMessage("{PropertyName} Must Not be NULL")
               .NotEmpty().WithMessage("{PropertyName} Must Not be Empty")
               .MaximumLength(50).WithMessage("Max Length is 10");
        }

        public void ApplyCustomValidationRule()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (Model,key, CancellationToken) => !await _studentService.IsExistNameExpectYourNameAsync(Model.Name,Model.Id))
                .WithMessage("Name Is Exist");
        }
        #endregion
    }
}
