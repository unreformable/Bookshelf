using System.ComponentModel.DataAnnotations.Schema;

namespace Bookshelf.Models
{
	public class UserBook
	{
		public int Id { set; get; }

		public int PagesRead { get; set; }

		public int Rating { get; set; }

		[Column(TypeName = "varchar(2048)")]
		public string? Review { get; set; }


		// Relations
		public List<User> Users { get; set; } = new List<User>();

		public List<Book> Books { get; set; } = new List<Book>();
	}
}
