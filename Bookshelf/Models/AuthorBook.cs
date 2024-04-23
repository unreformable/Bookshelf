namespace Bookshelf.Models
{
	public class AuthorBook
	{
		public int Id { set; get; }


		// Relations
		public List<Author> Authors { get; set; } = new List<Author>();

		public List<Book> Books { get; set; } = new List<Book>();
	}
}
