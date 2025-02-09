using System;
using System.Collections.Generic;

namespace PlumaWeb.Models;

public partial class Clase
{
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public int MateriaId { get; set; }

    public int CreatedBy { get; set; }

    public DateOnly CreatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public DateOnly UpdatedAt { get; set; }

    public int? DeletedBy { get; set; }

    public DateOnly? DeletedAt { get; set; }

    public bool BorradoLogico { get; set; }

    public virtual ICollection<AsistenciaClase> AsistenciaClases { get; set; } = new List<AsistenciaClase>();

    public virtual Materium Materia { get; set; } = null!;
}
