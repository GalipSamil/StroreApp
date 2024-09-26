using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using StoreApp.Entities.Models;

namespace StoreApp.Data.Contracts
{
    public  interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        Order? GetOneOrder(int id);

        void Complete(int id);

        void SaveOrder(Order order);

        int NumberOfInProcess { get; }
    }
}
