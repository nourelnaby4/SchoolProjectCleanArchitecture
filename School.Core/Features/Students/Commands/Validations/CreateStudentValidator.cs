using FluentValidation;
using School.Core.Features.Students.Commands.Models;

namespace School.Core.Features.Students.Commands.Validations
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentCommand>
    {
        #region fields

        #endregion


        #region constractur
        public CreateStudentValidator()
        {
            ApplyValidationsRule();
        }
        #endregion


        #region functions
        public void ApplyValidationsRule()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("{PropertyName} Must Not be NULL")
                .NotEmpty().WithMessage("{PropertyName} Must Not be Empty")
                .MaximumLength(10).WithMessage("Max Length is 10");


            RuleFor(x => x.Name)
               .NotNull().WithMessage("{PropertyName} Must Not be NULL")
               .NotEmpty().WithMessage("{PropertyName} Must Not be Empty")
               .MaximumLength(10).WithMessage("Max Length is 10");
        }
        #endregion
    }
}
