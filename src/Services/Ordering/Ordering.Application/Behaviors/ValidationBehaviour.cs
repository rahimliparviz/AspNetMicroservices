using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace Ordering.Application.Behaviors
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            //Sistemde olan IValidator objectlerini list seklinde inject edir 
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            //Yoxlayirki sistemde IValidaro obyekti varmi 
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                    
                //Request zamani butun validation islerini gorur ve eger fail olanlar var throw edir yoxsa next() le davam edir
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                    throw new ValidationException(failures);
            }

            Console.WriteLine("Before");
            return await next();
            Console.WriteLine("Later");
            
        }
    }
}