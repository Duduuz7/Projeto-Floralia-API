using Floralia_API.Domains;

namespace Floralia_API.Interfaces
{
    public interface IProdutoRepository
    {
        public void Cadastrar(Produto produto);

        public List<Produto> Listar();

        public Produto BuscarPorId(Guid id);

        public void Deletar(Guid id);

        public Produto Atualizar(Guid idProduto, Produto produto);
<<<<<<< HEAD

=======
>>>>>>> ec1d00b39f767c9e1b11738d95388c6f412f1765
    }
}
