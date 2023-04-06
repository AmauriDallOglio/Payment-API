using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Models
{
    public class Vendedor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefone { get; set; }

 
 
    }
}
