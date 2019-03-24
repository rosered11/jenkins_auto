using System;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DemoApp.DAL
{
    internal sealed class UnitOfWork : IUnitOfWork ,IDisposable
    {
        private DbContext context;
        private IGenericRepository<Products> productsRepository;
        private IGenericRepository<ProductsMachine> productsMachineRepository;

        public IGenericRepository<Products> ProductsRepository
        {
            get{
                if(productsRepository == null){
                    productsRepository = new GenericRepository<Products>(context);
                }
                return productsRepository;
            }
        }
        public IGenericRepository<ProductsMachine> ProductsMachineRepository
        {
            get{
                if(productsMachineRepository == null){
                    productsMachineRepository = new GenericRepository<ProductsMachine>(context);
                }
                return productsMachineRepository;
            }
        }
        public int SaveContext(){
            try{
                return context.SaveChanges();
            }
            catch(Exception exception){
                Log.Error(exception,"The unit of work is exception.");
            }
            return -1;
        }
        private bool disposed;
        internal UnitOfWork(){
            this.context = new DatabaseContext();
            this.disposed = false;
        }
        ~UnitOfWork(){
            Dispose(false);
            GC.SuppressFinalize(this);
        }
        public void Dispose()
        {
            Dispose(true);
        }
        private void Dispose(bool diposing){
            if(disposed){
                return;
            }
            if(diposing){
                this.context.Dispose();
            }
            disposed = true;
        }
    }
}