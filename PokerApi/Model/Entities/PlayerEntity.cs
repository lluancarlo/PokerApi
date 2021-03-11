using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokerApi.Model.Entities
{
    [Table("Player")]
    public class PlayerEntity
    {
        [Key]
        [Required]
        [Column("playerId")]
        public int Id { get; set; }

        [Required]
        [Column("Name")]
        public string Name { get; set; }

        [Required]
        [Column("Email")]
        public string Email { get; set; }

        [Required]
        [Column("User")]
        public string User { get; set; }

        [Required]
        [Column("Password")]
        public string Password { get; set; }

        [Column("Created_At")]
        public DateTime? Created_At { get; set; }

        [Column("Updated_At")]
        public DateTime? Updated_At { get; set; }
    }
}
