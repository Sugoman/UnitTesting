﻿using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingLib.Library;

namespace UnitTesting
{
    public class LibraryTests
    {
        [Fact]
        public void BorrowBook_ShouldReturnTrue_WhenBookIsAvailable()
        {
            // Arrange
            var mockBookRepository = new Mock<IBookRepository>();
            var mockUserRepository = new Mock<IUserRepository>();

            var book = new Book { Id = 1, Title = "Test Book", Author = "Author", IsBorrowed = false };
            var user = new User { Id = 1, Name = "Test User" };

            mockBookRepository.Setup(repo => repo.GetBookById(1)).Returns(book);
            mockUserRepository.Setup(repo => repo.GetUserById(1)).Returns(user);

            var service = new LibraryService(mockBookRepository.Object, mockUserRepository.Object);

            // Act
            var result = service.BorrowBook(1, 1);

            // Assert
            Assert.True(result);
            mockBookRepository.Verify(repo => repo.UpdateBook(It.IsAny<Book>()), Times.Once);
            mockUserRepository.Verify(repo => repo.UpdateUser(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public void BorrowBook_ShouldReturnFalse_WhenBookIsAlreadyBorrowed()
        {
            // Arrange
            var mockBookRepository = new Mock<IBookRepository>();
            var mockUserRepository = new Mock<IUserRepository>();

            var book = new Book { Id = 1, Title = "Test Book", Author = "Author", IsBorrowed = true };
            var user = new User { Id = 1, Name = "Test User" };

            mockBookRepository.Setup(repo => repo.GetBookById(1)).Returns(book);
            mockUserRepository.Setup(repo => repo.GetUserById(1)).Returns(user);

            var service = new LibraryService(mockBookRepository.Object, mockUserRepository.Object);

            // Act
            var result = service.BorrowBook(1, 1);

            // Assert
            Assert.False(result);
            mockBookRepository.Verify(repo => repo.UpdateBook(It.IsAny<Book>()), Times.Never);
            mockUserRepository.Verify(repo => repo.UpdateUser(It.IsAny<User>()), Times.Never);
        }


    }
}