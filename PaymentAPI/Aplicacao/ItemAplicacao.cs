using PaymentAPI.Context;
using PaymentAPI.Models;

namespace PaymentAPI.Aplicacao
{
    public class ItemAplicacao
    {
        private readonly MeuContext _context;
        public ItemAplicacao(MeuContext context)
        {
            _context = context;
        }

        public Item CadastrarItem(Item item)
        {
            var grava = _context.Items.Add(item); 
            var salva = _context.SaveChanges(); 

            return item;
        }

        public Item RetornaItemPeloId(int idItem)
        {
            Item resultadoItem = _context.Items.Where(a => a.Id == idItem).FirstOrDefault();
            return resultadoItem;
        }

        public List<Item> RetornaItemPeloNome(string nome)
        {
            List<Item> resultadoItem = _context.Items.Where(a => a.Nome.Contains(nome)).ToList();
            return resultadoItem;
        }

    }
}
