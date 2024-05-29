using System;
using System.Collections.Generic;

namespace Floralia_API.Domains;

public partial class Encomenda
{
    public Guid Id { get; set; }

    public Guid? IdProduto { get; set; }

    public Guid? IdUsuario { get; set; }

    public string? StatusEncomenda { get; set; }

    public DateOnly? DataEncomenda { get; set; }

    public virtual Produto? IdProdutoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
