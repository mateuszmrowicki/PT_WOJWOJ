using Library.Data;
using System.Linq;

namespace Library.Logic
{
    public class LibraryService
    {
        private readonly LibraryState _state;

        public LibraryService(LibraryState state)
        {
            _state = state;
        }

        public void AddBook(Book book)
        {
            _state.Books.Add(book);
        }

        public void AddUser(User user)
        {
            _state.Users.Add(user);
        }

        public bool BorrowBook(string isbn, string userName)
        {
            var user = _state.Users.FirstOrDefault(u => u.Name == userName);
            if (user == null) return false;

            var book = _state.Books.FirstOrDefault(b => b.ISBN == isbn && !b.IsBorrowed);
            if (book == null) return false;

            book.IsBorrowed = true;
            user.BorrowedIsbns.Add(isbn);
            return true;
        }

        public bool ReturnBook(string isbn)
        {
            var book = _state.Books.FirstOrDefault(b => b.ISBN == isbn);
            if (book == null || !book.IsBorrowed)
                return false;

            book.IsBorrowed = false;

            var user = _state.Users.FirstOrDefault(u => u.BorrowedIsbns.Contains(isbn));
            user?.BorrowedIsbns.Remove(isbn);

            return true;
        }

        public bool IsBookAvailable(string isbn)
        {
            return _state.Books.Any(b => b.ISBN == isbn && !b.IsBorrowed);
        }
    }
}
