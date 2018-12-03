namespace TesisSys.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cantones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cantones()
        {
            Distritos = new HashSet<Distritos>();
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="Provincia")]
        public int ProvinciaID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CantonID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Cantón")]
        public string Nombre { get; set; }

        public bool? Estado { get; set; }

        public virtual Provincias Provincias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Distritos> Distritos { get; set; }
    }
}
