using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookstore.unittests.TestsSetup;
using bookstoreapi.Application.BookOperations.Commands.CreateBook;
using FluentAssertions;

namespace bookstore.unittests.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("den", 1, 1)]
        [InlineData("", 1, 0)]
        [InlineData("deneme", 0, 0)]
        [InlineData("den", 0, 1)]
        [InlineData("den", 0, 0)]
        [InlineData("deneeme", 1, 1)]
        [InlineData("", 0, 1)]
        [InlineData("", 0, 0)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, int pagecount, int genreid)
        {
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.model = new CreateBookCommand.CreateBookModel
            {
                Title = "",
                PageCount = 0,
                GenreId = 0,
                PublishDate = DateTime.Now.Date
            };
            CreateBookCommandValidator validations = new CreateBookCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}