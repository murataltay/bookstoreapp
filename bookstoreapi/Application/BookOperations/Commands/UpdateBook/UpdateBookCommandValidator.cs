using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace bookstoreapi.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidator: AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command=>command.BookId).GreaterThan(0);
            RuleFor(command=>command.model.Title).NotEmpty().MinimumLength(3);
            RuleFor(command => command.model.PageCount).NotEmpty().GreaterThan(0);
        }
    }
}