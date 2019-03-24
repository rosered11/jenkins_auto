namespace DemoApp.DAL
{
    public interface IUnitOfWork
    {
        IGenericRepository<Products> ProductsRepository {get;}
        IGenericRepository<ProductsMachine> ProductsMachineRepository {get;}
        int SaveContext();
    }
}