namespace TesisSys.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FormularioAmenazas
    {
        [Key]
        public int FormularioAmenazaID { get; set; }

        [Required]
        [StringLength(80)]
        public string FormularioID { get; set; }

        public int AmenazaID { get; set; }

        public int CatalogoAmenazaID { get; set; }

        public virtual CatalogosAmenazas CatalogosAmenazas { get; set; }

        public virtual Formularios Formularios { get; set; }
    }
}
