using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace empleados.Models
{
    public partial class registro_empleadosContext : DbContext
    {
        public registro_empleadosContext()
        {

        }

        public registro_empleadosContext(DbContextOptions<registro_empleadosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<FotoEmpleado> FotoEmpleados { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-LKEOE3R; Database=registro_empleados; User=sa; Password=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PK__empleado__88B5139482FD7065");

                entity.ToTable("empleados");

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.FechaContratacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_contratacion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<FotoEmpleado>(entity =>
            {
                entity.HasKey(e => e.IdFoto)
                    .HasName("PK__foto_emp__620EA3A52774000A");

                entity.ToTable("foto_empleado");

                entity.HasIndex(e => e.IdUsuario, "UQ__foto_emp__4E3E04ACAB788E49")
                    .IsUnique();

                entity.Property(e => e.IdFoto).HasColumnName("id_foto");

                entity.Property(e => e.Foto).HasColumnName("foto");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithOne(p => p.FotoEmpleado)
                    .HasForeignKey<FotoEmpleado>(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__foto_empl__id_us__31EC6D26");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
