using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Localization;
using School.Core.Features.Students.Commands.Models;
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
        private readonly IStringLocalizer<Resource> _localizer;
        #endregion


        #region constractur
        public EditStudentValidator(IStudentService studentService, IStringLocalizer<Resource> localizer)
        { 

                   _studentService = studentService;
            _localizer = localizer;
            ApplyValidationsRule();
            ApplyCustomValidationRule();
     
        }
        #endregion


        #region functions
        public void ApplyValidationsRule()
        {
            RuleFor(x => x.NameAr)
                .NotNull().WithMessage("{PropertyName}" + $"{_localizer[ResourceKeys.MustNotBeNull]}")
                .NotEmpty().WithMessage("{PropertyName}" + $"{_localizer[ResourceKeys.MustNotBeEmpty]}")
                .MaximumLength(20).WithMessage("{PropertyName} " + $"{_localizer[ResourceKeys.MaxLength]} 20");
            RuleFor(x => x.NameEn)
               .NotNull().WithMessage("{PropertyName}" + $"{_localizer[ResourceKeys.MustNotBeNull]}")
               .NotEmpty().WithMessage("{PropertyName}" + $"{_localizer[ResourceKeys.MustNotBeEmpty]}")
               .MaximumLength(20).WithMessage("{PropertyName} " + $"{_localizer[ResourceKeys.MaxLength]} 20");


            RuleFor(x => x.Address)
               .NotNull().WithMessage("{PropertyName}" + $"{_localizer[ResourceKeys.MustNotBeNull]}")
                .NotEmpty().WithMessage("{PropertyName}" + $"{_localizer[ResourceKeys.MustNotBeEmpty]}")
                .MaximumLength(50).WithMessage("{PropertyName} " + $"{_localizer[ResourceKeys.MaxLength]} 50");
        }

        public void ApplyCustomValidationRule()
        {
            RuleFor(x => x.NameEn)
                .MustAsync(async (Model, key, CancellationToken) => !await _studentService.IsExistNameExpectYourNameAsync(Model.NameEn, Model.Id))

                .WithMessage(_localizer[ResourceKeys.NameExist]);

            RuleFor(x => x.NameAr)
                .MustAsync(async (Model, key, CancellationToken) => !await _studentService.IsExistNameExpectYourNameAsync(Model.NameAr, Model.Id))

                .WithMessage(_localizer[ResourceKeys.NameExist]);
        }
        #endregion
    }
}
