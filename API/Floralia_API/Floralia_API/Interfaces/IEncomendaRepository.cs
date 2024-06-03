using Floralia_API.Domains;

namespace Floralia_API.Interfaces
{
    public interface IEncomendaRepository
    {
        public void Cadastrar(Encomenda encomenda);

        public List<Encomenda> ListarPorUsuario(Guid idUsuario);

        public void AlterarStatus(Guid idEncomenda, string status);

    }
}
