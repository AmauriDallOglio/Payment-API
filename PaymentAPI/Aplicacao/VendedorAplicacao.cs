using PaymentAPI.Context;
using PaymentAPI.Models;

namespace PaymentAPI.Aplicacao
{
    public class VendedorAplicacao
    {
        private readonly MeuContext _context;
        public VendedorAplicacao(MeuContext context)
        {
            _context = context;
        }


        public Vendedor CadastrarVendedor(Vendedor vendedor)
        {
            var grava = _context.Vendedores.Add(vendedor);
            var salva = _context.SaveChanges();

            return vendedor;
        }

        public Vendedor RetornoVendedorPorId(int idVendedor)
        {
            Vendedor resultadoVendedor = _context.Vendedores.Where(a => a.Id == idVendedor).FirstOrDefault();
            return resultadoVendedor;
        }

    }
}
