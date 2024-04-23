using System.ComponentModel.DataAnnotations.Schema;

namespace Bookshelf.Models
{
	public class Author
	{
		public int Id { get; set; }

		[Column(TypeName = "varchar(45)")]
		public string? FirstName { get; set; }

		[Column(TypeName = "varchar(45)")]
		public string? LastName { get; set; }


		// Relations
		public AuthorBook? AuthorBook { set; get; }
	}
}
