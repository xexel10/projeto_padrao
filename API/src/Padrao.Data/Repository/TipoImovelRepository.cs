using Padrao.Business.Interfaces;
using Padrao.Business.Models;
using Padrao.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Padrao.Data.Repository;

public class TipoImovelRepository : Repository<TipoImovel>, ITipoImovelRepository
{
    public TipoImovelRepository(MeuDbContext contexto) : base(contexto)
    {
    }


    public async Task<IEnumerable<TipoImovel>> GetAllTipoImovel()
    {
        return (IQueryable<TipoImovel>)await Get().AsNoTracking().ToListAsync();
    }


    public async Task<IEnumerable<TipoImovel>> GetTipoImovelByDesc(string _tipoImovel)
    {
        return (IQueryable<TipoImovel>)await Get().AsNoTracking().Where(p => p.Descricao == _tipoImovel).ToListAsync();
    }


}

