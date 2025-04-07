namespace Library.Data
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public bool IsBorrowed { get; set; } = false;
    }
}
