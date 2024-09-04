﻿namespace StoreApp.Data.Contracts
{
    public interface  IRepositoryManager
    {
        IProductRepository Product {get; }
        ICategoryRepository Category {get; }

        void Save();

    }
}
