using Floralia_API.Domains;
using Floralia_API.Interfaces;
using Floralia_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Floralia_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private ICarrinhoRepository carrinhoRepository;
        public CarrinhoController()
        {
            carrinhoRepository = new CarrinhoRepository();
        }

        [HttpGet("BuscarPorUsuario")]
        public IActionResult GetByIdUsuario(Guid idUsuario)
        {
            try
            {
                return Ok(carrinhoRepository.ListarPorUsuario(idUsuario));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Deletar")]
        public IActionResult Delete(Guid id) 
        {
            try
            {
                carrinhoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpPost("Cadastrar")]
        public IActionResult Post(Carrinho carrinho)
        {
            try
            {
                carrinhoRepository.Cadastrar(carrinho);
                return Ok(carrinho);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AtualizarStatus")]

        public IActionResult Put(Guid idUsuario, string status)
        {
            try
            {
                carrinhoRepository.AtualizarStatus(idUsuario, status);

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPatch("AtualizarStatusCarrinnho")]

        public IActionResult Patch(Guid idCarrinho, string status)
        {
            try
            {
                carrinhoRepository.AtualizarStatusCarrinho(idCarrinho, status);

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
