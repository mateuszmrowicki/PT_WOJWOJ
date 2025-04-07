using Library.Data;
using Library.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.Tests
{
    [TestClass]
    public class LibraryServiceTests
    {
        private LibraryState state;
        private LibraryService service;

        [TestInitialize]
        public void Setup()
        {
            state = new LibraryState();
            service = new LibraryService(state);
        }

        [TestMethod]
        public void AddUser_ShouldAddUserToList()
        {
            var user = new User { Name = "Anna" };
            service.AddUser(user);

            Assert.AreEqual(1, state.Users.Count);
            Assert.AreEqual("Anna", state.Users[0].Name);
        }

        [TestMethod]
        public void BorrowBook_WithValidUser_ShouldMarkBookAsBorrowed()
        {
            var book = new Book { ISBN = "123", Title = "Test Book" };
            var user = new User { Name = "Anna" };
            service.AddBook(book);
            service.AddUser(user);

            var result = service.BorrowBook("123", "Anna");

            Assert.IsTrue(result);
            Assert.IsTrue(book.IsBorrowed);
            Assert.IsTrue(user.BorrowedIsbns.Contains("123"));
        }

        [TestMethod]
        public void BorrowBook_InvalidUser_ShouldFail()
        {
            var book = new Book { ISBN = "123", Title = "Test Book" };
            service.AddBook(book);

            var result = service.BorrowBook("123", "Ghost");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReturnBook_ShouldMarkBookAsAvailable()
        {
            var book = new Book { ISBN = "123", Title = "Test Book", IsBorrowed = true };
            var user = new User { Name = "Anna" };
            user.BorrowedIsbns.Add("123");

            service.AddBook(book);
            service.AddUser(user);

            var result = service.ReturnBook("123");

            Assert.IsTrue(result);
            Assert.IsFalse(book.IsBorrowed);
            Assert.IsFalse(user.BorrowedIsbns.Contains("123"));
        }

        [TestMethod]
        public void ReturnBook_NotBorrowed_ShouldFail()
        {
            var book = new Book { ISBN = "123", Title = "Test Book", IsBorrowed = false };
            service.AddBook(book);

            var result = service.ReturnBook("123");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsBookAvailable_ShouldReturnTrueIfNotBorrowed()
        {
            var book = new Book { ISBN = "123", Title = "Test Book", IsBorrowed = false };
            service.AddBook(book);

            var result = service.IsBookAvailable("123");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsBookAvailable_ShouldReturnFalseIfBorrowed()
        {
            var book = new Book { ISBN = "123", Title = "Test Book", IsBorrowed = true };
            service.AddBook(book);

            var result = service.IsBookAvailable("123");

            Assert.IsFalse(result);
        }
    }
}
