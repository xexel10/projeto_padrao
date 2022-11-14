using Padrao.Business.Interfaces;
using Padrao.Business.Models;
using Padrao.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Padrao.Data.Repository;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(MeuDbContext contexto) : base(contexto)
    {
    }


    public async Task<IEnumerable<Categoria>> GetAllCategorias()
    {
        return (IQueryable<Categoria>)await Get().AsNoTracking().ToListAsync();
    }


    public async Task<IEnumerable<Categoria>> GetCategoriaByDesc(string _categoria)
    {
        return (IQueryable<Categoria>)await Get().AsNoTracking().Where(p => p.Descricao == _categoria).ToListAsync();
    }


}

