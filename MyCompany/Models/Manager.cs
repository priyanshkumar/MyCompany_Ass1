namespace MyCompany.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Manager
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Manager()
        {
            Employes = new HashSet<Employe>();
        }

        [Key]
        public int Manager_Id { get; set; }

        public int Branch_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Manager_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Manager_Job { get; set; }

        [Required]
        [StringLength(50)]
        public string Manager_Email { get; set; }

        [Required]
        [StringLength(20)]
        public string City { get; set; }

        [Required]
        [StringLength(10)]
        public string Provience { get; set; }

        public virtual Branch Branch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employe> Employes { get; set; }
    }
}
