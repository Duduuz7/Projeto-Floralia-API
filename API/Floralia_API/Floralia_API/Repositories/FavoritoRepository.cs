using Floralia_API.Contexts;
using Floralia_API.Domains;
using Floralia_API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Floralia_API.Repositories
{
    public class FavoritoRepository : IFavoritoRepository
    {
        private readonly FloraliaContext ctx;
        public FavoritoRepository()
        {
            ctx = new FloraliaContext();
        }

        public Favorito BuscarPorId(Guid idUsuario, Guid idProduto)
        {
            try
            {
               return ctx.Favorito.Include(x => x.IdProdutoNavigation).FirstOrDefault(x => x.IdUsuario != null & x.IdUsuario == idUsuario & x.IdProduto != null & x.IdProduto == idProduto)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Favorito favorito)
        {
            try
            {
                ctx.Favorito.Add(favorito);
                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Favorito favoritoBuscado = ctx.Favorito.Find(id)!;

                if (favoritoBuscado != null)
                {
                    ctx.Favorito.Remove(favoritoBuscado);
                }

                ctx.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Favorito> ListarPorUsuario(Guid idUsuario)
        {
            List<Favorito> listaFavorito = ctx.Favorito.Include(x => x.IdProdutoNavigation).Where( x => x.IdUsuario != null & x.IdUsuario == idUsuario).ToList();
            return listaFavorito;
        }
    }
}
