using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PaymentAPI.Models;
using PaymentAPI.Aplicacao;
using System;

namespace PaymentAPI.Dto
{
    public class VendaDto
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public short SituacaoValor { get; set; }
        public string SituacaoNome { get; set; }
        public int IdItem { get; set; }
        public virtual Item? ItemVendido { get; set; }
        public int IdVendedor { get; set; }
        public virtual Vendedor? VendedorVenda { get; set; }

 
    }
}
