using System;
using System.Collections.Generic;

namespace PlumaWeb.Models;

public partial class Persona
{
    public int Id { get; set; }

    public string Documento { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string? Email { get; set; }

    public string? NroTelefono { get; set; }

    public int CreatedBy { get; set; }

    public DateOnly CreatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public DateOnly UpdatedAt { get; set; }

    public int? DeletedBy { get; set; }

    public DateOnly? DeletedAt { get; set; }

    public bool BorradoLogico { get; set; }

    public virtual ICollection<AsistenciaClase> AsistenciaClases { get; set; } = new List<AsistenciaClase>();

    public virtual ICollection<UsuarioPortal> UsuarioPortals { get; set; } = new List<UsuarioPortal>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
