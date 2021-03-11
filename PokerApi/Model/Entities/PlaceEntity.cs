using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokerApi.Model.Entities
{
    [Table("Place")]
    public class PlaceEntity
    {
        [Key]
        [Required]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("Name")]
        public string Name { get; set; }

        [Column("Created_At")]
        public DateTime? Created_At { get; set; }

        [Column("Updated_At")]
        public DateTime? Updated_At { get; set; }
    }
}
