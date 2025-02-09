using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PlumaWeb.Models;

namespace PlumaWeb.Data;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AsistenciaClase> AsistenciaClases { get; set; }

    public virtual DbSet<AsistenciaEstado> AsistenciaEstados { get; set; }

    public virtual DbSet<Clase> Clases { get; set; }

    public virtual DbSet<Materium> Materia { get; set; }

    public virtual DbSet<Perfil> Perfils { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioPortal> UsuarioPortals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AsistenciaClase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("asistencia_clase_pkey");

            entity.ToTable("asistencia_clase");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BorradoLogico)
                .HasDefaultValue(false)
                .HasColumnName("borrado_logico");
            entity.Property(e => e.ClaseId).HasColumnName("clase_id");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.EstadoId).HasColumnName("estado_id");
            entity.Property(e => e.MotivoFalta).HasColumnName("motivo_falta");
            entity.Property(e => e.PersonaId).HasColumnName("persona_id");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Clase).WithMany(p => p.AsistenciaClases)
                .HasForeignKey(d => d.ClaseId)
                .HasConstraintName("asistencia_clase_clase_id_fkey");

            entity.HasOne(d => d.Estado).WithMany(p => p.AsistenciaClases)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("asistencia_clase_estado_id_fkey");

            entity.HasOne(d => d.Persona).WithMany(p => p.AsistenciaClases)
                .HasForeignKey(d => d.PersonaId)
                .HasConstraintName("asistencia_clase_persona_id_fkey");
        });

        modelBuilder.Entity<AsistenciaEstado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("asistencia_estado_pkey");

            entity.ToTable("asistencia_estado");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BorradoLogico)
                .HasDefaultValue(false)
                .HasColumnName("borrado_logico");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .HasColumnName("nombre");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<Clase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("clase_pkey");

            entity.ToTable("clase");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BorradoLogico)
                .HasDefaultValue(false)
                .HasColumnName("borrado_logico");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Hora).HasColumnName("hora");
            entity.Property(e => e.MateriaId).HasColumnName("materia_id");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Materia).WithMany(p => p.Clases)
                .HasForeignKey(d => d.MateriaId)
                .HasConstraintName("clase_materia_id_fkey");
        });

        modelBuilder.Entity<Materium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("materia_pkey");

            entity.ToTable("materia");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BorradoLogico)
                .HasDefaultValue(false)
                .HasColumnName("borrado_logico");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<Perfil>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("perfil_pkey");

            entity.ToTable("perfil");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BorradoLogico)
                .HasDefaultValue(false)
                .HasColumnName("borrado_logico");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasMany(d => d.Permisos).WithMany(p => p.Perfils)
                .UsingEntity<Dictionary<string, object>>(
                    "PerfilPermiso",
                    r => r.HasOne<Permiso>().WithMany()
                        .HasForeignKey("PermisoId")
                        .HasConstraintName("perfil_permiso_permiso_id_fkey"),
                    l => l.HasOne<Perfil>().WithMany()
                        .HasForeignKey("PerfilId")
                        .HasConstraintName("perfil_permiso_perfil_id_fkey"),
                    j =>
                    {
                        j.HasKey("PerfilId", "PermisoId").HasName("perfil_permiso_pkey");
                        j.ToTable("perfil_permiso");
                        j.IndexerProperty<int>("PerfilId").HasColumnName("perfil_id");
                        j.IndexerProperty<int>("PermisoId").HasColumnName("permiso_id");
                    });
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("permiso_pkey");

            entity.ToTable("permiso");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BorradoLogico)
                .HasDefaultValue(false)
                .HasColumnName("borrado_logico");
            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("persona_pkey");

            entity.ToTable("persona");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(30)
                .HasColumnName("apellidos");
            entity.Property(e => e.BorradoLogico)
                .HasDefaultValue(false)
                .HasColumnName("borrado_logico");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Documento)
                .HasMaxLength(20)
                .HasColumnName("documento");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nombres)
                .HasMaxLength(30)
                .HasColumnName("nombres");
            entity.Property(e => e.NroTelefono)
                .HasMaxLength(30)
                .HasColumnName("nro_telefono");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuario_pkey");

            entity.ToTable("usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BorradoLogico)
                .HasDefaultValue(false)
                .HasColumnName("borrado_logico");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .HasColumnName("password");
            entity.Property(e => e.PersonaId).HasColumnName("persona_id");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasColumnName("username");

            entity.HasOne(d => d.Persona).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.PersonaId)
                .HasConstraintName("usuario_persona_id_fkey");

            entity.HasMany(d => d.Perfils).WithMany(p => p.Usuarios)
                .UsingEntity<Dictionary<string, object>>(
                    "PerfilUsuario",
                    r => r.HasOne<Perfil>().WithMany()
                        .HasForeignKey("PerfilId")
                        .HasConstraintName("perfil_usuario_perfil_id_fkey"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("perfil_usuario_usuario_id_fkey"),
                    j =>
                    {
                        j.HasKey("UsuarioId", "PerfilId").HasName("perfil_usuario_pkey");
                        j.ToTable("perfil_usuario");
                        j.IndexerProperty<int>("UsuarioId").HasColumnName("usuario_id");
                        j.IndexerProperty<int>("PerfilId").HasColumnName("perfil_id");
                    });
        });

        modelBuilder.Entity<UsuarioPortal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuario_portal_pkey");

            entity.ToTable("usuario_portal");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Blocked)
                .HasDefaultValue(false)
                .HasColumnName("blocked");
            entity.Property(e => e.BorradoLogico)
                .HasDefaultValue(false)
                .HasColumnName("borrado_logico");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.GrupoFamiliarId).HasColumnName("grupo_familiar_id");
            entity.Property(e => e.IntentoLogin).HasColumnName("intento_login");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .HasColumnName("password");
            entity.Property(e => e.PersonaId).HasColumnName("persona_id");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasColumnName("username");

            entity.HasOne(d => d.Persona).WithMany(p => p.UsuarioPortals)
                .HasForeignKey(d => d.PersonaId)
                .HasConstraintName("usuario_portal_persona_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
