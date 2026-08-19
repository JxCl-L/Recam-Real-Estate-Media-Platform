using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RECAM.Common.Interfaces;
using RECAM.Models.Entities;

namespace RECAM.DataAccess.Data;

public class RECAMDbContext : IdentityDbContext<ApplicationUser>
{
    public RECAMDbContext(DbContextOptions<RECAMDbContext> options) : base(options)
    {
    }

    // DbSet
    public DbSet<Agent> Agents { get; set; }
    public DbSet<PhotographyCompany> PhotographyCompanies { get; set; }
    public DbSet<ListingCase> ListingCases { get; set; }
    public DbSet<MediaAsset> MediaAssets { get; set; }
    public DbSet<CaseContact> CaseContacts { get; set; }
    public DbSet<AgentPhotographyCompany> AgentPhotographyCompanies { get; set; } // explicit join table need to add here
    // no need ApplicationUser, provided by IdentityDbContext<ApplicationUser>

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder); // must 1st line to get all DbSet ready

        // add 1:1 relationship FK User → XX & remove all cascade delete (soft delete IsDeleted)
        builder.Entity<Agent>()
        .HasOne(a => a.User) // 1 agent has 1 user
        .WithOne() // user side not add navigation to agent
        .HasForeignKey<Agent>(a => a.Id) // FK is agent.Id, that points to user and == UserId
        .OnDelete(DeleteBehavior.NoAction); // user delete => not casecade delete agent

        builder.Entity<PhotographyCompany>().HasOne(p => p.User).WithOne().HasForeignKey<PhotographyCompany>(p => p.Id).OnDelete(DeleteBehavior.NoAction);

        builder.Entity<ListingCase>().HasOne(l => l.User).WithMany().HasForeignKey(l => l.UserId).OnDelete(DeleteBehavior.NoAction);

        builder.Entity<MediaAsset>().HasOne(m => m.User).WithMany().HasForeignKey(m => m.UserId).OnDelete(DeleteBehavior.NoAction);

        // global filter soft deleted
        builder.Entity<ListingCase>().HasQueryFilter(l => !l.IsDeleted);
        builder.Entity<MediaAsset>().HasQueryFilter(m => !m.IsDeleted);
        builder.Entity<ApplicationUser>().HasQueryFilter(u => !u.IsDeleted);

        builder.Entity<Agent>().HasQueryFilter(a => !a.User.IsDeleted);
        builder.Entity<PhotographyCompany>().HasQueryFilter(p => !p.User.IsDeleted);

        builder.Entity<CaseContact>().HasQueryFilter(c => !c.ListingCase.IsDeleted);
    }

    private void ApplyAuditTimestamps()
    {
        var now = DateTime.UtcNow;

        foreach(var entry in ChangeTracker.Entries<IAuditable>())
        {
            if(entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = now;
            }
        }
    }
    public override int SaveChanges()
    {
        ApplyAuditTimestamps();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyAuditTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }





}
