using Floralia_API.Domains;
using Floralia_API.Interfaces;
using Floralia_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Floralia_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncomendaController : ControllerBase
    {
        private IEncomendaRepository encomendaRepository;

        public EncomendaController()
        {
            encomendaRepository = new EncomendaRepository();
        }

        [HttpGet("GetByIdUsuario")]
        public IActionResult Get(Guid idUsuario)
        {
            try
            {
                return Ok(encomendaRepository.ListarPorUsuario(idUsuario));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        public IActionResult Post(Encomenda encomenda)
        {
            try
            {
                encomendaRepository.Cadastrar(encomenda);
                return Ok(encomenda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Guid id, string status)
        {
            try
            {
                encomendaRepository.AlterarStatus(id, status);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
