using System;
using System.Collections.Generic;

namespace PlumaWeb.Models;

public partial class UsuarioPortal
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int PersonaId { get; set; }

    public int? GrupoFamiliarId { get; set; }

    public int IntentoLogin { get; set; }

    public bool Blocked { get; set; }

    public int CreatedBy { get; set; }

    public DateOnly CreatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public DateOnly UpdatedAt { get; set; }

    public int? DeletedBy { get; set; }

    public DateOnly? DeletedAt { get; set; }

    public bool BorradoLogico { get; set; }

    public virtual Persona Persona { get; set; } = null!;
}
