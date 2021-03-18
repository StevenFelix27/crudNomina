using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace crudNomina.Data
{
    public partial class NominaContext : DbContext
    {
        public NominaContext()
        {
        }

        public NominaContext(DbContextOptions<NominaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AsientoContable> AsientoContables { get; set; }
        public virtual DbSet<Deduccion> Deduccions { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Ingreso> Ingresos { get; set; }
        public virtual DbSet<Transaccion> Transaccions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=ConnectionStrings:NominaConn");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<AsientoContable>(entity =>
            {
                entity.ToTable("AsientoContable");

                entity.Property(e => e.Cuenta)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAsiento).HasColumnType("datetime");

                entity.Property(e => e.TipoMovimiento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.AsientoContables)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AsientoContable_Empleados");
            });

            modelBuilder.Entity<Deduccion>(entity =>
            {
                entity.ToTable("Deduccion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("Empleado");

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.IdNomina)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ingreso>(entity =>
            {
                entity.ToTable("Ingreso");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transaccion>(entity =>
            {
                entity.ToTable("Transaccion");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.TipoTransaccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDeduccionNavigation)
                    .WithMany(p => p.Transaccions)
                    .HasForeignKey(d => d.IdDeduccion)
                    .HasConstraintName("FK_Transaccion_Deduccion");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Transaccions)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaccion_Empleados");

                entity.HasOne(d => d.IdIngresoNavigation)
                    .WithMany(p => p.Transaccions)
                    .HasForeignKey(d => d.IdIngreso)
                    .HasConstraintName("FK_Transaccion_Ingreso");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
