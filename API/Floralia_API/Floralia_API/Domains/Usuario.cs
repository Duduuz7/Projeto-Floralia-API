using System;
using System.Collections.Generic;

namespace Floralia_API.Domains;

public partial class Usuario
{
    public Guid Id { get; set; }

    public string? Nome { get; set; }

    public string? Email { get; set; }

    public string? Senha { get; set; }

    public string? Foto { get; set; }

    public int? CodRecupSenha { get; set; }

    public virtual ICollection<Carrinho> Carrinho { get; set; } = new List<Carrinho>();

    public virtual ICollection<Encomenda> Encomenda { get; set; } = new List<Encomenda>();

    public virtual ICollection<Favorito> Favorito { get; set; } = new List<Favorito>();
}
