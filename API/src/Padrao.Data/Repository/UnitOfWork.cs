using Padrao.Data.Repository;
using Padrao.Business.Interfaces;
using Padrao.Data.Context;

namespace Padrao.Data.Repository;
public class UnitOfWork : IUnitOfWork
{

    private CategoriaRepository _categoriaRepo;
    private TipoImovelRepository _tipoImovelRepo;
    private ImovelRepository _imovelRepo;
    public MeuDbContext _context;

    public UnitOfWork(MeuDbContext contexto)
    {
        _context = contexto;
    }

    public ICategoriaRepository CategoriaRepository
    {
        get
        {
            return _categoriaRepo = _categoriaRepo ?? new CategoriaRepository(_context);
        }
    }

    public ITipoImovelRepository TipoImovelRepository
    {
        get
        {
            return _tipoImovelRepo = _tipoImovelRepo ?? new TipoImovelRepository(_context);
        }
    }

    public IImovelRepository ImovelRepository
    {
        get
        {
            return _imovelRepo = _imovelRepo ?? new ImovelRepository(_context);
        }
    }


    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }


}