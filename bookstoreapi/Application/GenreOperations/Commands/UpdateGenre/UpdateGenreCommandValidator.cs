using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace bookstoreapi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(comamnd => comamnd.GenreId).GreaterThan(0);
            RuleFor(command=> command.model.Name).NotEmpty().MinimumLength(3);
        }
    }
}