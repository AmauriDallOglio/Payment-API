using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PaymentAPI.Aplicacao;
using PaymentAPI.Context;
using PaymentAPI.Models;

namespace PaymentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly MeuContext _context;
        public VendedorController(MeuContext context)
        {
            _context = context;
        }

        [HttpPost("CadastrarVendedor")]
        public IActionResult Cadastrar(Vendedor vendedor)
        {
            if (vendedor.Cpf.IsNullOrEmpty() )
                return BadRequest(new { Erro = "CPF não pode ser vazio" });

            if (vendedor.Nome.IsNullOrEmpty() )
                return BadRequest(new { Erro = "Nome não pode ser vazio" });

            VendedorAplicacao aplicacao = new VendedorAplicacao(_context);
            Vendedor resultado = aplicacao.CadastrarVendedor(vendedor);
            if (resultado == null)
            {
                return NotFound("Erro ao gravar o cadastro!");
            }

            return CreatedAtAction(nameof(ObterVendedorNome), new { id = vendedor.Id }, vendedor);
        }

        [HttpGet("ObterTodos")]
        public IActionResult ObterTodosVendedores()
        {
            var resultado = _context.Vendedores.ToList();
            if (resultado.Count == 0)
            {
                return NotFound("Sistema não possuí vendedores cadastrados!");

            }
            return Ok(resultado);
        }

        [HttpGet("ObterPorNome")]
        public IActionResult ObterVendedorNome(string nome)
        {
            var resultado = _context.Vendedores.Where(a => a.Nome.Contains(nome)).ToList();
            if (resultado.Count == 0)
            {
                return NotFound("Sistema não possuí vendedores cadastrados!");

            }
            return Ok(resultado);
        }
 

    }
}
