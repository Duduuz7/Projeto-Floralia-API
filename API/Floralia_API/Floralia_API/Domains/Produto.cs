using System;
using System.Collections.Generic;

namespace Floralia_API.Domains;

public partial class Produto
{
    public Guid Id { get; set; }

    public string? Nome { get; set; }

    public string? Descricao { get; set; }

    public string? Foto { get; set; }

    public decimal? Preco { get; set; }

    public virtual ICollection<Carrinho> Carrinhos { get; set; } = new List<Carrinho>();

    public virtual ICollection<Encomendum> Encomenda { get; set; } = new List<Encomendum>();

    public virtual ICollection<Favorito> Favoritos { get; set; } = new List<Favorito>();
}
