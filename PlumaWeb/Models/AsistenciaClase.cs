using System;
using System.Collections.Generic;

namespace PlumaWeb.Models;

public partial class AsistenciaClase
{
    public int Id { get; set; }

    public int ClaseId { get; set; }

    public int PersonaId { get; set; }

    public int EstadoId { get; set; }

    public string? MotivoFalta { get; set; }

    public int CreatedBy { get; set; }

    public DateOnly CreatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public DateOnly UpdatedAt { get; set; }

    public int? DeletedBy { get; set; }

    public DateOnly? DeletedAt { get; set; }

    public bool BorradoLogico { get; set; }

    public virtual Clase Clase { get; set; } = null!;

    public virtual AsistenciaEstado Estado { get; set; } = null!;

    public virtual Persona Persona { get; set; } = null!;
}
