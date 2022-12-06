namespace Padrao.Business.Interfaces;
    public interface IUnitOfWork
    {
        ICategoriaRepository CategoriaRepository{get;}
        ITipoImovelRepository TipoImovelRepository{get;}
        IImovelRepository ImovelRepository{get;}
        Task Commit();

        
    }
