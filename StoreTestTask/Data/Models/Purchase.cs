using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StoreTestTask.Data.Models
{
    public class Purchase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderNumber { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [NotMapped]
        public decimal TotalPrice => PurchaseDetails.Sum(pd => pd.Quantity * (pd.Product?.Price ?? 0));

        [Required]
        public int ClientId { get; set; }

        public Client Client { get; set; }

        public ICollection<PurchaseDetail> PurchaseDetails { get; set; }
    }
}
