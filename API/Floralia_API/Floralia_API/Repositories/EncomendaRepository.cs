using Floralia_API.Contexts;
using Floralia_API.Domains;
using Floralia_API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Floralia_API.Repositories
{
    public class EncomendaRepository : IEncomendaRepository
    {
        private readonly FloraliaContext ctx;

        public EncomendaRepository()
        {
            ctx = new FloraliaContext();
        }

        public void AlterarStatus(Guid idEncomenda, string status)
        {
            try
            {
                //Encomenda statusEncomenda = ctx.Encomenda.FirstOrDefault(x => x.StatusEncomanda == status)!;

                Encomenda encomendaBuscada = ctx.Encomenda.Find(idEncomenda)!;

                encomendaBuscada.StatusEncomanda = status;
                ctx.Update(encomendaBuscada);
                ctx.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Encomenda encomenda)
        {
            try
            {
                ctx.Encomenda.Add(encomenda);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Encomenda> ListarPorUsuario(Guid idUsuario)
        {
            List<Encomenda> listaEncomenda = ctx.Encomenda.Include(x => x.IdProdutoNavigation).Where(x => x.IdUsuario != null & x.IdUsuario == idUsuario).ToList();
            return listaEncomenda;
        }
    }
}
