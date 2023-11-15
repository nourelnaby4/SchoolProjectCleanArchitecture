using FluentValidation;
using Microsoft.Extensions.Localization;
using School.Core.Features.Students.Commands.Models;
using School.Core.SharedResources;
using School.Service.Abstracts;

namespace School.Core.Features.Students.Commands.Validations
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentCommand>
    {
        #region fields
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<Resource> _localizer;
        #endregion


        #region constractur
        public CreateStudentValidator(IStudentService studentService,IStringLocalizer<Resource> localizer)
        {
            _localizer = localizer;
            _studentService = studentService;

            ApplyValidationsRule();
            ApplyCustomValidationRule();
        }
        #endregion


        #region functions
        public void ApplyValidationsRule()
        {
            RuleFor(x => x.NameEn)
                .NotNull().WithMessage(" {PropertyName} "+$"{_localizer[ ResourceKeys.MustNotBeNull]}")
                .NotEmpty().WithMessage("{PropertyName} " + $"{_localizer[ ResourceKeys.MustNotBeEmpty]}")
                .MaximumLength(20).WithMessage(" {PropertyName} "+ $"{_localizer[ ResourceKeys.MaxLength]} 20");

            RuleFor(x => x.NameAr)
               .NotNull().WithMessage(" {PropertyName} " + $"{_localizer[ResourceKeys.MustNotBeNull]}")
               .NotEmpty().WithMessage("{PropertyName} " + $"{_localizer[ResourceKeys.MustNotBeEmpty]}")
               .MaximumLength(20).WithMessage(" {PropertyName} " + $"{_localizer[ResourceKeys.MaxLength]} 20");


            RuleFor(x => x.Address)
               .NotNull().WithMessage("{PropertyName} " + $"{_localizer[ResourceKeys.MustNotBeNull]}")
                .NotEmpty().WithMessage("{PropertyName} " + $"{_localizer[ResourceKeys.MustNotBeEmpty]}")
                .MaximumLength(50).WithMessage(" {PropertyName} " + $"{_localizer[ResourceKeys.MaxLength]} 50");
        }

        public void ApplyCustomValidationRule()
        {
            RuleFor(x => x.NameEn)
                .MustAsync(async (key, CancellationToken) =>! await _studentService.IsExistNameAsync(key))
                .WithMessage(_localizer[ResourceKeys.NameExist]);
            RuleFor(x => x.NameAr)
                .MustAsync(async (key, CancellationToken) =>! await _studentService.IsExistNameAsync(key))
                .WithMessage(_localizer[ResourceKeys.NameExist]);
        }
        #endregion
    }
}
