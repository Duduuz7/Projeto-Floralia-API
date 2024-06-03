using Floralia_API.Domains;

namespace Floralia_API.Interfaces
{
    public interface IProdutoRepository
    {
        public void Cadastrar(Produto produto);

        public List<Produto> Listar();

        public Produto BuscarPorId(Guid id);

        public void Deletar(Guid id);

        public void Atualizar(Guid idProduto, Produto produto);

    }
}
