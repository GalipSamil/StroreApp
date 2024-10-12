using DocumentFormat.OpenXml.Drawing.Charts;
using StoreApp.Entities.Models;

namespace Services.Contracts
{
    public interface IOrderService
    {
        IQueryable<StoreApp.Entities.Models.Order> Orders { get; }

        StoreApp.Entities.Models.Order? GetOneOrder(int id);

        void Complete(int id);

        void SaveOrder(StoreApp.Entities.Models.Order order);
        
        int NumberOfInProcess {  get; } 
    }
}
