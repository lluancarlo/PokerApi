using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokerApi.Model.Entities
{
    [Table("Financial")]
    public class FinancialEntity
    {
        [Key]
        [Required]
        [Column("PlayerId")]
        public int PlayerId { get; set; }

        [Key]
        [Required]
        [Column("PlaceId")]
        public int PlaceId { get; set; }

        [Required]
        [Column("Balance")]
        public float Balance { get; set; }

        [Column("Created_At")]
        public DateTime? Created_At { get; set; }

        [Column("Updated_At")]
        public DateTime? Updated_At { get; set; }
    }
}
