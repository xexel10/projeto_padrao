using Padrao.Business.Models;

namespace Padrao.Business.Interfaces
{
    public interface IImovelRepository : IRepository<Imovel>
    {
        Task<IEnumerable<Imovel>> GetImovelByDesc(String _Imovel);
        Task<IEnumerable<Imovel>> GetAllImovel();
    }
}