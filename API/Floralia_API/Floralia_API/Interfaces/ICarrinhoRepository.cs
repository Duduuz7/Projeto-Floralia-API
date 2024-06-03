using Floralia_API.Domains;

namespace Floralia_API.Interfaces
{
    public interface ICarrinhoRepository
    {
        public void Cadastrar(Carrinho carrinho);

        public List<Carrinho> ListarPorUsuario(Guid idUsuario);

        public void Deletar(Guid id);
    }
}
