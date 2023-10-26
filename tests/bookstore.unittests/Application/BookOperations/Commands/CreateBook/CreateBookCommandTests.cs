using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bookstore.unittests.TestsSetup;
using bookstoreapi.Application.BookOperations.Commands.CreateBook;
using bookstoreapi.Entities;
using bookstoreapp.Models;
using FluentAssertions;

namespace bookstore.unittests.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper= testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExitBookTitleGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var book = new Book(){Title="WhenAlreadyExitBookTitleGiven_InvalidOperationException_ShouldBeReturn",PageCount=100, PublishDate= new System.DateTime(1990,10,01),GenreId=1};
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            command.model= new CreateBookCommand.CreateBookModel(){Title=book.Title};
            //act
            //assert

            FluentActions
                .Invoking(() => command.Handlle()) 
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut");
        }
    }
}