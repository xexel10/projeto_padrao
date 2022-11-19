using Padrao.Data.Repository;
using Padrao.Business.Interfaces;
using Padrao.Data.Context;

namespace Padrao.Data.Repository;
public class UnitOfWork : IUnitOfWork
{

    private CategoriaRepository _categoriaRepo;
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


    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }


}