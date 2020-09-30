using DataService.Models.Repositories.Create;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Models.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApartmentDbContext _dbContext;
        //
        //delacre Repository
        public UserRepository User { get; private set; }
        public HouseRepository House { get; private set; }
        public BlockRepository Block { get; private set; }
        public AroundProviderRepository AroundProvider { get; private set; }
        public AroundProviderCategoryRepository AroundPrividerCategory { get; private set; }
        public AroundProviderProductRepository AroundProviderProduct { get; private set; }

        public UnitOfWork(ApartmentDbContext dbContext)
        {
            this._dbContext = dbContext;
            this.User = new UserRepository(this._dbContext);
            this.House = new HouseRepository(this._dbContext);
            this.Block = new BlockRepository(this._dbContext);
            this.AroundProvider = new AroundProviderRepository(this._dbContext);
            this.AroundProviderProduct = new AroundProviderProductRepository(this._dbContext);
            this.AroundPrividerCategory = new AroundProviderCategoryRepository(this._dbContext);
        }
        public void Commit()
        {
            this._dbContext.SaveChanges();
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }
    }
}
