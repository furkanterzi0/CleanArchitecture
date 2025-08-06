using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance.Context;

public sealed class AppDbContext : IdentityDbContext<User, Role, string>
{
    public AppDbContext(DbContextOptions options) : base(options) {}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly); // configurationsları tek satırla bağlamak
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<Entity>();
        foreach(var entry in entries)
        {
            if (entry.State == EntityState.Added )
                entry.Property(p=> p.CreateDate).CurrentValue = DateTime.Now;
            

            if (entry.State == EntityState.Modified)
                entry.Property(p => p.UpdateDate).CurrentValue = DateTime.Now;
            
        }
        return base.SaveChangesAsync(cancellationToken);
    }

}
