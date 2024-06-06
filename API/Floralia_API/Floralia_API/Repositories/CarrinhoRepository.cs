using Floralia_API.Contexts;
using Floralia_API.Domains;
using Floralia_API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Floralia_API.Repositories
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly FloraliaContext ctx;

        public CarrinhoRepository()
        {
            ctx = new FloraliaContext();
        }


        public void Cadastrar(Carrinho carrinho)
        {
            try
            {
                ctx.Carrinho.Add(carrinho);

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
                Carrinho carrinhoBuscado = ctx.Carrinho.Find(id);

                if (carrinhoBuscado != null)
                {
                    ctx.Carrinho.Remove(carrinhoBuscado);
                }

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Carrinho> ListarPorUsuario(Guid idUsuario)
        {
            try
            {
                List<Carrinho> listaCarrinho = ctx.Carrinho
                    .Include(x => x.IdProdutoNavigation)
                    .Include(x => x.IdUsuarioNavigation)
                    .Where(x => x.IdUsuario != null & x.IdUsuario == idUsuario).ToList();
           
                return listaCarrinho;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
