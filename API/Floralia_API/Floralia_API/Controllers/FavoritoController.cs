using Floralia_API.Domains;
using Floralia_API.Interfaces;
using Floralia_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Floralia_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritoController : ControllerBase
    {
        private IFavoritoRepository favoritoRepository;
        public FavoritoController()
        {
            favoritoRepository = new FavoritoRepository();
        }

        [HttpGet("BuscaPorIdUsuario")]
        public IActionResult GetByIdUsuario(Guid idUsuario)
        {
            try
            {
                return Ok(favoritoRepository.ListarPorUsuario(idUsuario));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("BuscaPorIdProduto")]
        public IActionResult GetById(Guid idUsuario, Guid idProduto)
        {
            try
            {
                return Ok(favoritoRepository.BuscarPorId(idUsuario, idProduto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                favoritoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public IActionResult Post(Favorito favorito)
        {
            try
            {
                favoritoRepository.Cadastrar(favorito);
                return Ok(favorito);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
