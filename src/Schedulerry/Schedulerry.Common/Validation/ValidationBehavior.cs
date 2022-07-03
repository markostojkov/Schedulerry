using FluentValidation;
using MediatR;
using Schedulerry.Common.Errors.Exceptions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Schedulerry.Common.Validation
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var errors = new Dictionary<string, List<string>>();
            var context = new ValidationContext<TRequest>(request);

            foreach (var validation in _validators)
            {
                var validationResponse = await validation.ValidateAsync(context);

                foreach (var error in validationResponse.Errors)
                {
                    var errorProperty = errors.GetValueOrDefault(error.PropertyName);
                    if (errorProperty != null)
                    {
                        errorProperty.Add(error.ErrorMessage);
                    }
                    else
                    {
                        errors.Add(error.PropertyName, new List<string>() { error.ErrorMessage });
                    }
                }
            }

            if (errors.Count > 0)
            {
                throw new BadRequestException(errors);
            }

            return await next();
        }
    }
}
