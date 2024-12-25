using Microsoft.EntityFrameworkCore;

namespace CodeFirstRelation.Models;

public class PatikaSecondDbContext : DbContext
{
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Username=postgres;Password=12345;Database=PatikaCodeFirstDb2");
    }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Post> Posts { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.HasKey(x => x.Id);
            entity.HasMany(u => u.Posts)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);
            entity.Property(p => p.Email).HasMaxLength(50);
            entity.Property(p => p.Username).IsRequired().HasMaxLength(20);
        });
        
        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("Posts");
            entity.HasKey(x => x.Id);
            entity.Property(p => p.Title).IsRequired();
            entity.Property(p => p.Content).IsRequired();
            entity.Property(p => p.UserId).IsRequired();
        });
    }

}