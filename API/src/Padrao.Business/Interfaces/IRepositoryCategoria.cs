using Padrao.Business.Models;
using Padrao.Business.Repository;

namespace Padrao.Business.Interfaces;
public interface ICategoriaRepository : IRepository<Categoria>
{
     Task<IEnumerable<Categoria>> GetCategoriaByDesc(String _categoria);
    Task<IEnumerable<Categoria>> GetAllCategorias();
}
