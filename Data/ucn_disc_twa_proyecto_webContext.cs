using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Proyecto_Web.Models.Domain;

namespace Proyecto_Web.Data
{
    public partial class ucn_disc_twa_proyecto_webContext : DbContext
    {
        public virtual DbSet<Archivo> Archivo { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Proyecto> Proyecto { get; set; }
        public virtual DbSet<Trabajadores> Trabajadores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseMySql(@"server=localhost;port=3306;user=root;password=Yolo2015;database=ucn.disc.twa.proyecto_web");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Archivo>(entity =>
            {
                entity.ToTable("archivo");

                entity.HasIndex(e => e.IdEstado)
                    .HasName("idEstado");

                entity.HasIndex(e => e.IdProyecto)
                    .HasName("idProyecto");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEstado)
                    .HasColumnName("idEstado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdProyecto)
                    .HasColumnName("idProyecto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Ruta)
                    .HasColumnName("ruta")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Archivo)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("archivo_ibfk_1");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.Archivo)
                    .HasForeignKey(d => d.IdProyecto)
                    .HasConstraintName("archivo_ibfk_2");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("estado");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Rut)
                    .HasName("PK_persona");

                entity.ToTable("persona");

                entity.Property(e => e.Rut)
                    .HasColumnName("rut")
                    .HasColumnType("varchar(11)");

                entity.Property(e => e.Admin)
                    .HasColumnName("admin")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("fechaNacimiento")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Materno)
                    .HasColumnName("materno")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("_password")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Paterno)
                    .HasColumnName("paterno")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.ToTable("proyecto");

                entity.HasIndex(e => e.RutDirector)
                    .HasName("rutDirector");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FechaFin)
                    .HasColumnName("fechaFin")
                    .HasColumnType("date");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("fechaInicio")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.RutDirector)
                    .HasColumnName("rutDirector")
                    .HasColumnType("varchar(11)");

                entity.HasOne(d => d.RutDirectorNavigation)
                    .WithMany(p => p.Proyecto)
                    .HasForeignKey(d => d.RutDirector)
                    .HasConstraintName("proyecto_ibfk_1");
            });

            modelBuilder.Entity<Trabajadores>(entity =>
            {
                entity.HasKey(e => new { e.RutPersona, e.IdProyecto })
                    .HasName("PK_trabajadores");

                entity.ToTable("trabajadores");

                entity.HasIndex(e => e.IdProyecto)
                    .HasName("idProyecto");

                entity.HasIndex(e => e.RutPersona)
                    .HasName("rutPersona");

                entity.Property(e => e.RutPersona)
                    .HasColumnName("rutPersona")
                    .HasColumnType("varchar(11)");

                entity.Property(e => e.IdProyecto)
                    .HasColumnName("idProyecto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cargo)
                    .HasColumnName("cargo")
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.Trabajadores)
                    .HasForeignKey(d => d.IdProyecto)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("trabajadores_ibfk_2");

                entity.HasOne(d => d.RutPersonaNavigation)
                    .WithMany(p => p.Trabajadores)
                    .HasForeignKey(d => d.RutPersona)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("trabajadores_ibfk_1");
            });
        }
    }
}