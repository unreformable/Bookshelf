using System.ComponentModel.DataAnnotations.Schema;

namespace Bookshelf.Models
{
	public class Book
	{
		public int Id { get; set; }

		[Column(TypeName = "varchar(255)")]
		public string? Title { get; set; }

		[Column(TypeName = "varchar(2200)")]
		public string? Description { get; set; }

		public int Pages { get; set; }

		public DateTime ReleaseDate { get; set; }


		// Relations
		public AuthorBook? AuthorBook { set; get; }

		public UserBook? UserBook { set; get; }
	}
}
