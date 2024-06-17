using Floralia_API.Contexts;
using Floralia_API.Domains;
using Floralia_API.Interfaces;
using System.Text;

namespace Floralia_API.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        public FloraliaContext ctx = new FloraliaContext();

        public Produto Atualizar(Guid idProduto, Produto produto)
        {

            try
            {

                Produto produtoBuscado = ctx.Produto.FirstOrDefault(x => x.Id == idProduto)!;

                if (produto.Nome != null)
                    produtoBuscado!.Nome = produto.Nome;

                if (produto.Descricao != null)
                    produtoBuscado!.Descricao = produto.Descricao;

                if (produto.Foto != null)
                    produtoBuscado!.Foto = produto.Foto;

                if (produto.Preco != null)
                    produtoBuscado!.Preco = produto.Preco;

                ctx.Produto.Update(produtoBuscado);
                ctx.SaveChanges();

                return produtoBuscado;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public Produto BuscarPorId(Guid id)
        {
            try
            {
                return ctx.Produto.FirstOrDefault(x => x.Id == id)!;
            }
            catch (Exception)
            {

                throw;
            };
        }

        public List<Produto> BuscarPorNome(string nome)
        {
            try
            {
                string termoPesquisaNormalizado = nome.Normalize(NormalizationForm.FormD)
                                                           .ToLower()
                                                           .Replace("\\p{M}", "");

                var produtosNormalizados = ctx.Produto.ToList().Select(p => new Produto
                {
                    Id = p.Id,
                    Nome = p.Nome.Normalize(NormalizationForm.FormD)
                                 .ToLower()
                                 .Replace("\\p{M}", ""),
                    Foto = p.Foto,
                    Preco = p.Preco
                });

                return produtosNormalizados.Where(p => p.Nome.Contains(termoPesquisaNormalizado)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Produto produto)  
        {
            try
            {
                ctx.Produto.Add(produto);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Produto produtoBuscado = ctx.Produto.Find(id)!;

            try
            {

                if (produtoBuscado != null)
                {
                    ctx.Produto.Remove(produtoBuscado);
                }

                ctx.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Produto> Listar()
        {
            try
            {
                return ctx.Produto.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
