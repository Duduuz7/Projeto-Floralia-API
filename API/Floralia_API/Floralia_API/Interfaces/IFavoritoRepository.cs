using Floralia_API.Domains;

namespace Floralia_API.Interfaces
{
    public interface IFavoritoRepository
    {
        public void Cadastrar(Favorito favorito);

        public List<Favorito> ListarPorUsuario(Guid idUsuario);

        public void Deletar(Guid id);
    }
}
