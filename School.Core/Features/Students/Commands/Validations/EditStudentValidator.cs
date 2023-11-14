using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Localization;
using School.Core.Features.Students.Commands.Models;
using School.Core.Resources;
using School.Core.SharedResources;
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
        private readonly IStringLocalizer<Resource> _stringLocalizer;
        #endregion


        #region constractur
        public EditStudentValidator(IStudentService studentService, IStringLocalizer<Resource> stringLocalizer)
        { 

                   _studentService = studentService;
            _stringLocalizer = stringLocalizer;
            ApplyValidationsRule();
            ApplyCustomValidationRule();
     
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
                .MustAsync(async (Model, key, CancellationToken) => !await _studentService.IsExistNameExpectYourNameAsync(Model.Name, Model.Id))

                .WithMessage(_stringLocalizer[ResourceKeys.NameExist]);
        }
        #endregion
    }
}
