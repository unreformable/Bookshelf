using Bookshelf.Models;

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

        /// <summary>
        /// Stores user data after loggin in.
        /// </summary>
        public static User? loggedUser = null;
    }
}
