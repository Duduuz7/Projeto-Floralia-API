using Floralia_API.Domains;

namespace Floralia_API.Interfaces
{
    public interface IUsuarioRepository 
    {
        void Cadastrar(Usuario usuario);

        Usuario BuscarPorId(Guid id);

        Usuario BuscarPorEmailESenha(string email, string senha);

        bool AlterarSenha(string email, string novaSenha);

        public void AtualizarFoto(Guid id, string novaUrlFoto);
    }
}
