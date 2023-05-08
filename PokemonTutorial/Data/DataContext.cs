using Microsoft.EntityFrameworkCore;
using PokemonTutorial.Models;

namespace PokemonTutorial.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<PokemonOwner> PokemonOwners { get; set; }
        public DbSet<PokemonCategory> PokemonCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // For PokemonCategory
            modelBuilder.Entity<PokemonCategory>()
                .HasKey(pc => new { pc.PokemonID, pc.CategoryID });

            modelBuilder.Entity<PokemonCategory>()
                .HasOne(p => p.Pokemon)
                .WithMany(pc => pc.PokemonCategories)
                .HasForeignKey(c => c.PokemonID);

            modelBuilder.Entity<PokemonCategory>()
                .HasOne(p => p.Category)
                .WithMany(pc => pc.PokemonCategories)
                .HasForeignKey(c => c.CategoryID);


            // For PokemonOwner
            modelBuilder.Entity<PokemonOwner>()
                .HasKey(po => new { po.PokemonID, po.OwnerID });

            modelBuilder.Entity<PokemonOwner>()
                .HasOne(p => p.Pokemon)
                .WithMany(po => po.PokemonOwners)
                .HasForeignKey(c => c.PokemonID);

            modelBuilder.Entity<PokemonOwner>()
                .HasOne(p => p.Owner)
                .WithMany(po => po.PokemonOwners)
                .HasForeignKey(c => c.OwnerID);
        }


    }
}
