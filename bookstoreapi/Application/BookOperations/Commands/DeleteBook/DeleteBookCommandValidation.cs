using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace bookstoreapi.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandValidation: AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidation()
        {
            RuleFor(command  => command.bookId).GreaterThan(0);
        }
    }
}