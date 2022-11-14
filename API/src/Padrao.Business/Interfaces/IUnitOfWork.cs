namespace Padrao.Business.Interfaces;
    public interface IUnitOfWork
    {
        ICategoriaRepository CategoriaRepository{get;}

        Task Commit();

        
    }
