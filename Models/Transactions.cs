using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStoreTry.Models
{
    public class Transactions
    {
        [Key]
        public int TransactionId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public Books Book { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }
    }
}
