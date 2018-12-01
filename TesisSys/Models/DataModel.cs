namespace TesisSys.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<Amenazas> Amenazas { get; set; }
        public virtual DbSet<Asentamientos> Asentamientos { get; set; }
        public virtual DbSet<Cantones> Cantones { get; set; }
        public virtual DbSet<CatalogosAmenazas> CatalogosAmenazas { get; set; }
        public virtual DbSet<Distritos> Distritos { get; set; }
        public virtual DbSet<FormularioAmenazas> FormularioAmenazas { get; set; }
        public virtual DbSet<Formularios> Formularios { get; set; }
        public virtual DbSet<Provincias> Provincias { get; set; }
        public virtual DbSet<TiposDocumento> TiposDocumento { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Amenazas>()
                .HasMany(e => e.CatalogosAmenazas)
                .WithRequired(e => e.Amenazas)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Asentamientos>()
                .HasMany(e => e.Formularios)
                .WithRequired(e => e.Asentamientos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cantones>()
                .HasMany(e => e.Distritos)
                .WithRequired(e => e.Cantones)
                .HasForeignKey(e => new { e.ProvinciaID, e.CantonID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CatalogosAmenazas>()
                .HasMany(e => e.FormularioAmenazas)
                .WithRequired(e => e.CatalogosAmenazas)
                .HasForeignKey(e => new { e.AmenazaID, e.CatalogoAmenazaID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Distritos>()
                .HasMany(e => e.Asentamientos)
                .WithRequired(e => e.Distritos)
                .HasForeignKey(e => new { e.ProvinciaID, e.CantonID, e.DistritoID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Formularios>()
                .HasMany(e => e.FormularioAmenazas)
                .WithRequired(e => e.Formularios)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Provincias>()
                .HasMany(e => e.Cantones)
                .WithRequired(e => e.Provincias)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TiposDocumento>()
                .HasMany(e => e.Asentamientos)
                .WithRequired(e => e.TiposDocumento)
                .WillCascadeOnDelete(false);
        }
    }
}
