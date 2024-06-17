using Floralia_API.Domains;
using Floralia_API.Interfaces;
using Floralia_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Floralia_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
      private IProdutoRepository produtoRepository {  get; set; }

      public ProdutoController()
       {
            produtoRepository = new ProdutoRepository();
       }

        [HttpGet("BuscarPorId")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(produtoRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListarTodos")]
        public IActionResult Get() 
        {
            try
            {
                return Ok(produtoRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Deletar")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                produtoRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Cadastrar")]
        public IActionResult Post(Produto produto)
        {
            try
            {
                produtoRepository.Cadastrar(produto);

                return Ok(produto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Atualizar")]
        public IActionResult Put(Guid idProduto, Produto produto) 
        {
            try
            {
                produtoRepository.Atualizar(idProduto, produto);

                return Ok(produto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("BuscaPorNome")]
        public IActionResult Get(string nome) 
        {
            try
            {
                return Ok(produtoRepository.BuscarPorNome(nome));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
