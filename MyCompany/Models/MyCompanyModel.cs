namespace MyCompany.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyCompanyModel : DbContext
    {
        public MyCompanyModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Employe> Employes { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>()
                .Property(e => e.Provience)
                .IsFixedLength();

            modelBuilder.Entity<Branch>()
                .Property(e => e.Postal_Code)
                .IsFixedLength();

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.Employes)
                .WithRequired(e => e.Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.Managers)
                .WithRequired(e => e.Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employe>()
                .Property(e => e.Provience)
                .IsFixedLength();

            modelBuilder.Entity<Manager>()
                .Property(e => e.Provience)
                .IsFixedLength();

            modelBuilder.Entity<Manager>()
                .HasMany(e => e.Employes)
                .WithRequired(e => e.Manager)
                .WillCascadeOnDelete(false);
        }
    }
}
