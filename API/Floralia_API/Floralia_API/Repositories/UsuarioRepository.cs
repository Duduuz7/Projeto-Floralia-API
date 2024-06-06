using Floralia_API.Contexts;
using Floralia_API.Domains;
using Floralia_API.Interfaces;
using Floralia_API.Utils;

namespace Floralia_API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        FloraliaContext ctx = new FloraliaContext();


        public bool AlterarSenha(string email, string novaSenha)
        {
            try
            {
                var user = ctx.Usuario.FirstOrDefault(x => x.Email == email);

                if (user == null) return false;

                user.Senha = Criptografia.GerarHash(novaSenha);

                ctx.Update(user);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AtualizarFoto(Guid id, string novaUrlFoto)
        {
            try
            {
                Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(x => x.Id == id)!;
                  
                if (usuarioBuscado != null)
                {
                    usuarioBuscado.Foto = novaUrlFoto;
                }

                ctx.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                var user = ctx.Usuario.Select(u => new Usuario
                {
                    Id = u.Id,
                    Email = u.Email,
                    Senha = u.Senha,
                    Nome = u.Nome

                }).FirstOrDefault(x => x.Email == email);

                if (user == null) return null!;

                if (!Criptografia.CompararHash(senha, user.Senha!)) return null!;
                
                return user;
             
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                return ctx.Usuario.FirstOrDefault(x => x.Id == id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                ctx.Add(usuario);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
