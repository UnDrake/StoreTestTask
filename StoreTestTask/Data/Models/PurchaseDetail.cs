using System.ComponentModel.DataAnnotations;


namespace StoreTestTask.Data.Models
{
    public class PurchaseDetail
    {
        [Required]
        public int PurchaseId { get; set; }

        public Purchase Purchase { get; set; }

        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
