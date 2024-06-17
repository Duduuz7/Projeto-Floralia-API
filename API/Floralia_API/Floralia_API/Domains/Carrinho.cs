using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Floralia_API.Domains;

public partial class Carrinho
{
    public Guid Id { get; set; }

    public Guid? IdProduto { get; set; }

    public Guid? IdUsuario { get; set; }

    public string? Status { get; set; }

    public virtual Produto? IdProdutoNavigation { get; set; } = null;

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
