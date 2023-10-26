using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace bookstoreapi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQueryValidator:AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreDetailQueryValidator()
        {
            RuleFor(command => command.GenreId).GreaterThan(0);
        }
    }
}