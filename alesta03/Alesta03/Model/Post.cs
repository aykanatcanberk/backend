using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Alesta03.Model
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ?UserId { get; set; }

        public DateTime PostDate { get; set; }
        public string? Content { get; set; }
        public bool IsDeleted { get; set; }

        //
        public User User { get; set; }
    }
}
