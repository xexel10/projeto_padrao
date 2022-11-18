using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Padrao.Business.Models;
using Padrao.Business.Models.Identity;


namespace Padrao.Data.Context;
public class MeuDbContext : IdentityDbContext<User, Role, int,
                                                   IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
                                                   IdentityRoleClaim<int>, IdentityUserToken<int>>

{
    public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;
    }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<TipoImovel> TiposImoveis { get; set; }
    public DbSet<Imovel> Imoveis { get; set; }
    public DbSet<Foto> Fotos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            }
        );
    }

}
