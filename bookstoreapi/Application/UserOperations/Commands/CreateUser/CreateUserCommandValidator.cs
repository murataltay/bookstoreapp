using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace bookstoreapi.Application.UserOperations.Commands.CreateUser
{
    public class CreateUserCommandValidator: AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(command=> command.model.Email).NotEmpty().EmailAddress();
            RuleFor(command => command.model.Name).NotEmpty().MinimumLength(3);
            RuleFor(command => command.model.Surname).NotEmpty().MinimumLength(3);
            RuleFor(command => command.model.Password).NotEmpty().MinimumLength(6);    
        }
    }
}