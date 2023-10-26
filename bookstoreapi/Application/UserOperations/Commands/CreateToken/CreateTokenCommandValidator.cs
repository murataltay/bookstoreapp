using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace bookstoreapi.Application.UserOperations.Commands.CreateToken
{
    public class CreateTokenCommandValidator:AbstractValidator<CreateTokenCommand>
    {
        public CreateTokenCommandValidator()
        {
            RuleFor(command=>  command.model.Email).NotEmpty().EmailAddress();
            RuleFor(command=>command.model.Password).NotEmpty().MinimumLength(6);
        }
    }
}