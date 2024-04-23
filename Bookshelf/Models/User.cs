using System.ComponentModel.DataAnnotations.Schema;

namespace Bookshelf.Models
{
    public class User
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string? Name { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string? Surname { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string? Login { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string? Password { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string? Email { get; set; }

        public DateTime CreateDate { get; set; }


        // Relations
        public UserBook? UserBook { set; get; }
    }
}
