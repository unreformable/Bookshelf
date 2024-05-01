using System.ComponentModel.DataAnnotations.Schema;

namespace Bookshelf.Models
{
    public class UserBook
    {
        public int Id { set; get; }

        public int PagesRead { get; set; }

        public string Book_title { get; set; }

        public string User_Login { get; set; }

        // Relations
        public List<User> Users { get; set; } = new List<User>();

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
