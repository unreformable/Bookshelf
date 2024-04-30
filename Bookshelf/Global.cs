using Bookshelf.Models;
using Google.Apis.Books.v1.Data;

namespace Bookshelf
{
    /// <summary>
    /// Stores global state of application.
    /// </summary>
    public class Global
    {
        /// <summary>
        /// Signals whether user is logged in or not.
        /// </summary>
        public static bool loggedIn = false;
        public static User loggedUser;

        /// <summary>
        /// Stores user data after loggin in.
        /// </summary>
        public static User? loggedUser = null;

        /// <summary>
        /// Stores data recieved from API
        /// </summary>
        public static IList<Volume> foundBooks = new List<Volume>();
    }
}
