namespace TesisSys.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Asentamientos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Asentamientos()
        {
            Formularios = new HashSet<Formularios>();
        }

        [Key]
        public int AsentamientoID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public int ProvinciaID { get; set; }

        public int CantonID { get; set; }

        public int DistritoID { get; set; }

        [Required]
        public string Direccion { get; set; }

        public string Latitud { get; set; }

        public string Longitud { get; set; }

        [Required]
        [StringLength(50)]
        public string NombrePropietario { get; set; }

        [Required]
        [StringLength(50)]
        public string ApellidosPropietario { get; set; }

        public int TipoDocumentoID { get; set; }

        [Required]
        [StringLength(100)]
        public string NumDocumentoID { get; set; }

        public int NumViviendas { get; set; }

        public virtual Distritos Distritos { get; set; }

        public virtual TiposDocumento TiposDocumento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Formularios> Formularios { get; set; }
    }
}
