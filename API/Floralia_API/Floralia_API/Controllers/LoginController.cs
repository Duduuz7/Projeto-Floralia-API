using Floralia_API.Domains;
using Floralia_API.Interfaces;
using Floralia_API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        //post
        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                //busca usuário por email e senha 
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(usuario.Email!, usuario.Senha!);

                //caso não encontre
                if (usuarioBuscado == null)
                {
                    //retorna 401 - sem autorização
                    return StatusCode(401, "Email ou senha inválidos!");
                }


                //caso encontre, prossegue para a criação do token

                //informações que serão fornecidas no token
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email!),
                    new Claim(JwtRegisteredClaimNames.Name,usuarioBuscado.Nome!),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString())
                };

                //chave de segurança
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("floralia-webapi-chave-symmetricsecuritykey"));

                //credenciais
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //token
                var meuToken = new JwtSecurityToken(
                        issuer: "Floralia_API",
                        audience: "Floralia_API",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                });
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
