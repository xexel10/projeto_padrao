using Padrao.Business.Models;

namespace Padrao.Business.Interfaces
{
    public interface ITipoImovelRepository : IRepository<TipoImovel>
    {
        Task<IEnumerable<TipoImovel>> GetTipoImovelByDesc(String _tipoImovel);
        Task<IEnumerable<TipoImovel>> GetAllTipoImovel();
    }
}