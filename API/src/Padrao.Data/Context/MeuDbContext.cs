using Padrao.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace Padrao.Data.Context;
    public class MeuDbContext : DbContext
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

    }
