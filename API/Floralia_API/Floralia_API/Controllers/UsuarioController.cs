using Floralia_API.Domains;
using Floralia_API.Interfaces;
using Floralia_API.Repositories;
using Floralia_API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Utils.BlobStorage;
using WebAPI.ViewModels;

namespace Floralia_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository usuarioRepository;

        public UsuarioController()
        {
            usuarioRepository = new UsuarioRepository();
        }

        [HttpPut("AlterarSenha")]
        public IActionResult UpdatePassword(string email, AlterarSenhaViewModel senha)
        {
            try
            {
                usuarioRepository.AlterarSenha(email, senha.SenhaNova!);

                return Ok("Senha alterada com sucesso !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] UsuarioViewModel usuarioViewModel) 
        {
            try
            {
                Usuario user = new Usuario();

                //Recebimento dos valores e preenchimento das proprieddades
                user.Nome = usuarioViewModel.Nome;
                user.Email = usuarioViewModel.Email;
                user.Senha = usuarioViewModel.Senha;

                //Define o nome a partir do seu container no blob
                var containerName = "containervitalhubmatheusd";

                //Definindo a string de conexão
                var connectionString = "DefaultEndpointsProtocol=https;AccountName=blobvitalhubmatheusd;AccountKey=U+R/WL4jO+90TLOXcykF18666979z4yqxY0BGj+qNRDD2yW4aTC2JnQT6Z/dgbhraqNziHtYZ+zC+AStdUsGfA==;EndpointSuffix=core.windows.net";

                //A chamada da função de upload de imagem
                user.Foto = await AzureBlobStorageHelper.UploadImageBlobAsync(usuarioViewModel.File!, connectionString, containerName);

                usuarioRepository.Cadastrar(user);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("BuscarPorId")]
        public IActionResult GetById(Guid idUsuario)
        {
            try
            {
                return Ok(usuarioRepository.BuscarPorId(idUsuario));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AlterarFotoPerfil")]

        //UsuarioViewModel é um arquivo por isso fromform 
        //Funcionalidade para atualizar a foto de perfil do usuário
        public async Task<IActionResult> UploadProfileImage(Guid id, [FromForm] UsuarioViewModel user)
        {
            try
            {
                //Buscar usuario
                Usuario usuarioBuscado = usuarioRepository.BuscarPorId(id);

                if (usuarioBuscado == null)
                {
                    return NotFound("Usuário não encontrado");
                }

                //Lógica para o upload da imagem

                //Define o nome a partir do seu container no blob
                var containerName = "containervitalhubmatheusd";

                //Definindo a string de conexão
                var connectionString = "DefaultEndpointsProtocol=https;AccountName=blobvitalhubmatheusd;AccountKey=U+R/WL4jO+90TLOXcykF18666979z4yqxY0BGj+qNRDD2yW4aTC2JnQT6Z/dgbhraqNziHtYZ+zC+AStdUsGfA==;EndpointSuffix=core.windows.net";

                //A chamada da função de upload de imagem
                string fotoUrl = await AzureBlobStorageHelper.UploadImageBlobAsync(user.File!, connectionString, containerName);

                //Fim da lógica para upload de imagem

                usuarioRepository.AtualizarFoto(id, fotoUrl);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
