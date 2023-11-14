using FluentValidation;
using School.Core.Features.Students.Commands.Models;
using School.Service.Abstracts;

namespace School.Core.Features.Students.Commands.Validations
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentCommand>
    {
        #region fields
        private readonly IStudentService _studentService;
        #endregion


        #region constractur
        public CreateStudentValidator(IStudentService studentService)
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
                .MustAsync(async (key, CancellationToken) =>! await _studentService.IsExistNameAsync(key))
                .WithMessage("Name Is Exist");
        }
        #endregion
    }
}
