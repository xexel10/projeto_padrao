using Padrao.Business.Models;

namespace Padrao.Business.Interfaces
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<IEnumerable<Categoria>> GetCategoriaByDesc(String _categoria);
        Task<IEnumerable<Categoria>> GetAllCategorias();
    }
}