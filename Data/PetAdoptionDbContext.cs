using Microsoft.EntityFrameworkCore;
using PetAdoptionMVC.Models;

namespace PetAdoptionMVC.Data
{
    public class PetAdoptionDbContext : DbContext
    {
        public PetAdoptionDbContext(DbContextOptions<PetAdoptionDbContext> options)
         : base(options)
        {
        }

        // Animals
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Bird> Birds { get; set; }
        public DbSet<Fish> Fish { get; set; }
        public DbSet<Reptile> Reptiles { get; set; }
        public DbSet<SmallAnimal> SmallAnimals { get; set; }
        public DbSet<FarmAnimal> FarmAnimals { get; set; }
        public DbSet<ExoticAnimal> ExoticAnimals { get; set; }

        // Other models
        public DbSet<Adopter> Adopters { get; set; }
        public DbSet<Adoption> Adoptions { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Warning> Warnings { get; set; }
        public DbSet<Payment> Payments { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Adoption>()
                .Property(a => a.AdoptionFee)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Animal>()
                .Property(a => a.AdoptionFee)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Adoption>()
                .Property(a => a.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Adoption>()
                .Property(a => a.AnimalType)
                .HasConversion<string>();

            modelBuilder.Entity<Note>()
                .Property(n => n.EntityType)
                .HasConversion<string>();

            modelBuilder.Entity<Note>()
                .Property(n => n.Category)
                .HasConversion<string>();

            modelBuilder.Entity<Warning>()
                .Property(w => w.Type)
                .HasConversion<string>();

            modelBuilder.Entity<Warning>()
                .Property(w => w.Severity)
                .HasConversion<string>();

            modelBuilder.Entity<Payment>()
                .Property(p => p.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Payment>()
                .Property(p => p.Type)
                .HasConversion<string>();

            modelBuilder.Entity<Animal>()
                .Property(a => a.AnimalType)
                .HasConversion<string>();
        }

    }

}
