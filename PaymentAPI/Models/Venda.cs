using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PaymentAPI.Aplicacao;

namespace PaymentAPI.Models
{
    public class Venda
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public short Status { get; set; }


        [ForeignKey("FK_Item")]
        public int IdItem { get; set; }


        [ForeignKey("FK_Vendedor")]
        public int IdVendedor { get; set; }

        public Venda()
        {

        }

        public Venda CadastarUmaVenda(Venda venda)
        {
            venda.Data = DateTime.Now;
            venda.Status = 1;
            return venda;

        }

        public Venda AtualizaSituacaoParaAguardandoPagamento(Venda venda)
        {
            venda.Status = (short)SituacaoEnum.AguardandoPagamento;
            return venda;
        }


        public Venda AtualizaSituacaoParaAprovaPagamento(Venda venda)
        {
            venda.Status = (short)SituacaoEnum.PagamentoAprovado;
            return venda;
        }

        public Venda AtualizaSituacaoParaCancelaVenda(Venda venda)
        {
            venda.Status = (short)SituacaoEnum.Cancelada;
            return venda;
        }


        public Venda AtualizaSituacaoParaEnviadoParaTransportatora(Venda venda)
        {
            venda.Status = (short)SituacaoEnum.EnviadoParaTransportadora;
            return venda;
        }

        public Venda AtualizaSituacaoParaEnviadoParaEntrgue(Venda venda)
        {
            venda.Status = (short)SituacaoEnum.Entregue;
            return venda;
        }
    }
}
