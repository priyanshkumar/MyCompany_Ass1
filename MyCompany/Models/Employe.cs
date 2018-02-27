namespace MyCompany.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employe
    {
        [Key]
        public int Employee_Id { get; set; }

        public int Manager_Id { get; set; }

        public int Branch_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Employee_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Employee_Job { get; set; }

        [Required]
        [StringLength(50)]
        public string Employee_Email { get; set; }

        [Required]
        [StringLength(20)]
        public string City { get; set; }

        [Required]
        [StringLength(10)]
        public string Provience { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual Manager Manager { get; set; }
    }
}
