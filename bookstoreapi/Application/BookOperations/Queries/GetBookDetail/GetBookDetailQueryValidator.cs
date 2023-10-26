using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace bookstoreapi.Application.BookOperations.Queries.GetBookDetail
{
    public class GetBookDetailQueryValidator: AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailQueryValidator()
        {
            RuleFor(command=>command.id).GreaterThan(0);
        }
    }
}