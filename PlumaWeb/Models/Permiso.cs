using System;
using System.Collections.Generic;

namespace PlumaWeb.Models;

public partial class Permiso
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Codigo { get; set; }

    public string? Descripcion { get; set; }

    public int CreatedBy { get; set; }

    public DateOnly CreatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public DateOnly UpdatedAt { get; set; }

    public int? DeletedBy { get; set; }

    public DateOnly? DeletedAt { get; set; }

    public bool BorradoLogico { get; set; }

    public virtual ICollection<Perfil> Perfils { get; set; } = new List<Perfil>();
}
