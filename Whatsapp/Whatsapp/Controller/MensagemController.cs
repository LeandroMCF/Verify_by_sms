using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Whatsapp.Repositorie;

namespace Whatsapp.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MensagemController : ControllerBase
    {
        private IMensagem _mensagem { get; set; }

        public MensagemController()
        {
            _mensagem = new Mensagem();
        }

        [HttpPost("Enviar")]
        public IActionResult Enviar(string cel)
        {
            try
            {
                return Ok(_mensagem.Enviar(cel));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpPost("Verificar/{cripto}")]
        public IActionResult Verificar(string cod, string cripto)
        {
            try
            {
                return Ok(_mensagem.Verificar(cod, cripto));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}
