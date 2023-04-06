using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PaymentAPI.Aplicacao;
using PaymentAPI.Context;
using PaymentAPI.Models;

namespace PaymentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {

        private readonly MeuContext _context;
        public ItemController(MeuContext context)
        {
            _context = context;
        }

        [HttpPost("CadastrarItem")]
        public IActionResult CadastrarItem(Item item)
        {
            if (item.Quantidade <= 0)
                return BadRequest(new { Erro = "Quantidade tem que ser positivo" });

            if (item.Nome.IsNullOrEmpty())
                return BadRequest(new { Erro = "Nome não pode ser vazio" });

            if (item.Valor <= 0)
                return BadRequest(new { Erro = "Valor não pode estar em branco" });


            ItemAplicacao aplicacao = new ItemAplicacao(_context);
            Item resultado = aplicacao.CadastrarItem(item);
            if (resultado == null)
            {
                return NotFound("Erro ao gravar o cadastro!");
            }
            return CreatedAtAction(nameof(ObterPorNome), new { id = resultado.Nome }, item);
        }

        [HttpGet("ObterPorId")]
        public IActionResult ObterPorId(short id)
        {
            ItemAplicacao aplicacao = new ItemAplicacao(_context);
            Item resultado = aplicacao.RetornaItemPeloId(id);
            if (resultado == null)
            {
                return NotFound("Sistema não possuí item cadastrados!");
            }
            return Ok(resultado);
        }


        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome(string nome)
        {
            ItemAplicacao aplicacao = new ItemAplicacao(_context);
            List<Item> resultado = aplicacao.RetornaItemPeloNome(nome);
            if (resultado.Count == 0)
            {
                return NotFound("Sistema não possuí item cadastrados!");
            }
            return Ok(resultado);
        }
    }
}
