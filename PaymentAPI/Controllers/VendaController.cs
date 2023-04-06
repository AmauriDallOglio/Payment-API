using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Aplicacao;
using PaymentAPI.Context;
using PaymentAPI.Dto;
using PaymentAPI.Models;

namespace PaymentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly MeuContext _context;
        public VendaController(MeuContext context)
        {
            _context = context;
        }

        [HttpPost("CadastrarVenda")]
        public IActionResult Cadastrar(Venda venda)
        {
            venda.CadastarUmaVenda(venda);

            if (venda == null)
                return BadRequest(new { Erro = "Venda não pode ser vazio" });

            if (venda.IdVendedor == 0)
                return BadRequest(new { Erro = "Vendedor não pode ser vazio" });

            if (venda.IdItem == 0)
                return BadRequest(new { Erro = "Itens não pode ser vazio" });

            if (ModelState.IsValid) //Valida
            {
                _context.Vendas.Add(venda); //Grava
                _context.SaveChanges(); //Salva no banco
            }
            return CreatedAtAction(nameof(ObterPorId), new { id = venda.Id }, venda);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(short id)
        {
            VendaAplicacao aplicacao = new VendaAplicacao(_context);
            VendaDto resultado = aplicacao.RetornaDadosDaVenda(id);
            
            if (resultado == null)
            {
                return NotFound("Sistema não possuí venda cadastrada!");

            }
            return Ok(resultado);
        }

        [HttpPut("AtualizaStatusParaPagamentoAprovado")]
        public IActionResult AtualizaStatusParaPagamentoAprovado(int id, Venda venda)
        {
            VendaAplicacao aplicacao = new VendaAplicacao(_context);
            Venda resultado = aplicacao.AtualizaStatusParaPagamentoAprovado(id);
            if (resultado == null)
            {
                return NotFound("Sistema não possuí venda cadastrada!");
            }
            return Ok(resultado);
        }


        [HttpPut("AtualizaStatusParaCancelado")]
        public IActionResult AtualizaStatusParaCancelado(int id, Venda venda)
        {

            VendaAplicacao aplicacao = new VendaAplicacao(_context);
            Venda resultado = aplicacao.AtualizarStatusParaCancelado(id);
            if (resultado == null)
            {
                return NotFound("Sistema não possuí venda cadastrada!");
            }
            return Ok(resultado);
        }

        [HttpPut("AtualizaStatusParaEnviadoTransportadora")]
        public IActionResult AtualizaStatusParaEnviadoTransportadora(int id, Venda venda)
        {

            VendaAplicacao aplicacao = new VendaAplicacao(_context);
            Venda resultado = aplicacao.AtualizaStatusParaEnviadoTransportadora(id);
            if (resultado == null)
            {
                return NotFound("Sistema não possuí venda cadastrada!");
            }
            return Ok(resultado);
        }

        [HttpPut("AtualizaStatusParaEntregue")]
        public IActionResult AtualizaStatusParaEntregue(int id, Venda venda)
        {

            VendaAplicacao aplicacao = new VendaAplicacao(_context);
            Venda resultado = aplicacao.AtualizaStatusParaEntregue(id);
            if (resultado == null)
            {
                return NotFound("Sistema não possuí venda cadastrada!");
            }
            return Ok(resultado);
        }


        [HttpPut("AtualizaStatusAguardandoPagamento")]
        public IActionResult AtualizaStatusAguardandoPagamento(int id, Venda venda)
        {

            VendaAplicacao aplicacao = new VendaAplicacao(_context);
            Venda resultado = aplicacao.AtualizaStatusAguardandoPagamento(id);
            if (resultado == null)
            {
                return NotFound("Sistema não possuí venda cadastrada!");
            }
            return Ok(resultado);
        }


    }
}
