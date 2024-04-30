using Bookshelf.Models;
using Google.Apis.Books.v1.Data;

namespace Bookshelf
{
    public class Global
    {
        public static bool loggedIn = false;
        public static User loggedUser;
        public static IList<Volume> foundBooks = new List<Volume>();
    }
}
