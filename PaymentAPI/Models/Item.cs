using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Quantidade { get; set; }
        [Required]
        public decimal Valor { get; set; }

  
    }
}
