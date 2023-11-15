using FluentValidation;
using MediatR;
using Microsoft.Extensions.Localization;
using School.Core.SharedResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Behavior
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
       where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly IStringLocalizer<Resource> _localizer;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators,IStringLocalizer<Resource> localizer)
        {
            _validators = validators;
            _localizer = localizer;
        }

     

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                {
                    var message = failures.Select(x =>  x.PropertyName + ": " + x.ErrorMessage).FirstOrDefault();

                    throw new ValidationException(message);

                }
            }
            return await next();
        }
    }


}
