using System;
using System.Collections.Generic;

namespace PlumaWeb.Models;

public partial class Materium
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateOnly CreatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public DateOnly UpdatedAt { get; set; }

    public int? DeletedBy { get; set; }

    public DateOnly? DeletedAt { get; set; }

    public bool BorradoLogico { get; set; }

    public virtual ICollection<Clase> Clases { get; set; } = new List<Clase>();
}
