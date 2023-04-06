using PaymentAPI.Context;
using PaymentAPI.Dto;
using PaymentAPI.Models;

namespace PaymentAPI.Aplicacao
{
    public class VendaAplicacao
    {
        private readonly MeuContext _context;
        public VendaAplicacao(MeuContext context)
        {
            _context = context;
        }
 
        public VendedorAplicacao aplicacaoVendedor()
        {
            VendedorAplicacao aplicacaoVendedor = new VendedorAplicacao(_context);
            return aplicacaoVendedor;
        }

        public ItemAplicacao aplicacaoItem()
        {
            ItemAplicacao aplicacaoItem = new ItemAplicacao(_context);
            return aplicacaoItem;
        }


        public VendaDto RetornaDadosDaVenda(short idVenda)
        {
            VendaDto dto = new VendaDto();
            List<Venda> resultadoVenda = _context.Vendas.Where(a => a.Id == idVenda).ToList();
            foreach (var venda in resultadoVenda)
            {
                dto.Data = venda.Data;
                dto.Id = venda.Id;

 
                dto.SituacaoValor = venda.Status;
                string descricao = Enum.GetName(typeof(SituacaoEnum), venda.Status);
                dto.SituacaoNome = descricao;
                dto.IdVendedor = venda.IdVendedor;
                dto.IdItem= venda.IdItem;

                Item resultadoItem = RetornaObjetoDeItem(venda.IdItem); 
                Vendedor resultadoVendedor = RetornaObjetoVendedor(venda.IdVendedor);

                dto.VendedorVenda = resultadoVendedor;
                dto.ItemVendido = resultadoItem;

            }
            
            return dto;
        }

        public Item RetornaObjetoDeItem(int idItem)
        {
            var aplicacao = aplicacaoItem();
            Item resultadoItem = aplicacao.RetornaItemPeloId(idItem);
            return resultadoItem;
        }

        public Vendedor RetornaObjetoVendedor(int idVendedor)
        {
            var aplicacao = aplicacaoVendedor();
            Vendedor resultadoVendedor = aplicacao.RetornoVendedorPorId(idVendedor);
            return resultadoVendedor;
        }



        public Venda AtualizaStatusParaPagamentoAprovado(int id)
        {
            Venda tarefaBanco = _context.Vendas.Find(id);
            tarefaBanco.AtualizaSituacaoParaAprovaPagamento(tarefaBanco);
            var alteracao = _context.Update(tarefaBanco);
            var gravacao = _context.SaveChanges();
            return tarefaBanco;
        }


        public Venda AtualizarStatusParaCancelado(int id)
        {
            Venda tarefaBanco = _context.Vendas.Find(id);
            tarefaBanco.AtualizaSituacaoParaCancelaVenda(tarefaBanco);
            var alteracao = _context.Update(tarefaBanco);
            var gravacao = _context.SaveChanges();
            return tarefaBanco;
        }

        public Venda AtualizaStatusParaEnviadoTransportadora(int id)
        {
            Venda tarefaBanco = _context.Vendas.Find(id);
            tarefaBanco.AtualizaSituacaoParaEnviadoParaTransportatora(tarefaBanco);
            var alteracao = _context.Update(tarefaBanco);
            var gravacao = _context.SaveChanges();
            return tarefaBanco;
        }


        public Venda AtualizaStatusParaEntregue(int id)
        {
            Venda tarefaBanco = _context.Vendas.Find(id);
            tarefaBanco.AtualizaSituacaoParaEnviadoParaTransportatora(tarefaBanco);
            var alteracao = _context.Update(tarefaBanco);
            var gravacao = _context.SaveChanges();
            return tarefaBanco;
        }


        public Venda AtualizaStatusAguardandoPagamento(int id)
        {
            Venda tarefaBanco = _context.Vendas.Find(id);
            tarefaBanco.AtualizaSituacaoParaAguardandoPagamento(tarefaBanco);
            var alteracao = _context.Update(tarefaBanco);
            var gravacao = _context.SaveChanges();
            return tarefaBanco;
        }

    }
}
