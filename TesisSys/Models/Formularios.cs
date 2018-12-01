namespace TesisSys.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Formularios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Formularios()
        {
            FormularioAmenazas = new HashSet<FormularioAmenazas>();
        }

        [Key]
        [StringLength(80)]
        public string FormularioID { get; set; }

        public DateTime FechaLlenado { get; set; }

        public int AsentamientoID { get; set; }

        [Required]
        [StringLength(100)]
        public string TenenciaIndicadores { get; set; }

        [Required]
        [StringLength(100)]
        public string FamiliasIndicadores { get; set; }

        [Required]
        [StringLength(100)]
        public string EducacionPrimariaIndicadores { get; set; }

        [Required]
        [StringLength(100)]
        public string EducacionSecundariaIndicadores { get; set; }

        [Required]
        [StringLength(100)]
        public string SaludIndicadores { get; set; }

        [Required]
        [StringLength(100)]
        public string CuidoIndicadores { get; set; }

        [Required]
        [StringLength(100)]
        public string IMASIndicadores { get; set; }

        [Required]
        [StringLength(100)]
        public string RecreativoIndicadores { get; set; }

        public int ConPersoneria { get; set; }

        public int SinPersoneria { get; set; }

        [Required]
        [StringLength(100)]
        public string AccesoAgua { get; set; }

        [Required]
        [StringLength(100)]
        public string AccesoElectricidad { get; set; }

        [Required]
        [StringLength(100)]
        public string AguasResiduales { get; set; }

        [Required]
        [StringLength(100)]
        public string RecoleccionBasura { get; set; }

        public int Hurtos { get; set; }

        public int ViolenciaIntrafamiliar { get; set; }

        public int Abandono { get; set; }

        public int Alcoholismo { get; set; }

        public int Empleo { get; set; }

        public int EdadProductiva { get; set; }

        public int EmpleoInformal { get; set; }

        public int EmpleoInfantil { get; set; }

        public int JefesHogar { get; set; }

        public int EmbarazosAdolescentes { get; set; }

        public int MiembrosCostarricenses { get; set; }

        public int MiembroExtranjero { get; set; }

        public int ResidenciaPermanente { get; set; }

        public int CondicionIrregular { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreEvaluador { get; set; }

        [Required]
        [StringLength(50)]
        public string Institucion { get; set; }

        [Required]
        [StringLength(50)]
        public string NumCedula { get; set; }

        [Required]
        [StringLength(500)]
        public string Observaciones { get; set; }

        public virtual Asentamientos Asentamientos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormularioAmenazas> FormularioAmenazas { get; set; }
    }
}
