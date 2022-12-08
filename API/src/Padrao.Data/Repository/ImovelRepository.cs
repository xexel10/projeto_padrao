using Padrao.Business.Interfaces;
using Padrao.Business.Models;
using Padrao.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Padrao.Data.Repository;

public class ImovelRepository : Repository<Imovel>, IImovelRepository
{
    public ImovelRepository(MeuDbContext contexto) : base(contexto)
    {
    }


    public async Task<IEnumerable<Imovel>> GetAllImovel()
    {
        return (IQueryable<Imovel>)await Get().Include(c => c.Categoria)
                                              .Include(t=> t.TipoImovel)
                                              .AsNoTracking().ToListAsync();

    }


    public async Task<IEnumerable<Imovel>> GetImovelByDesc(string _imovel)
    {
        return (IQueryable<Imovel>)await Get().AsNoTracking().Where(p => p.Descricao == _imovel).ToListAsync();
    }


}

