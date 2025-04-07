using System.Collections.Generic;

namespace Library.Data
{
    public class User
    {
        public string Name { get; set; }
        public List<string> BorrowedIsbns { get; set; } = new List<string>();
    }
}
