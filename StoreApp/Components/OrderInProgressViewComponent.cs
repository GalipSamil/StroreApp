using Services.Contracts;
using Microsoft.AspNetCore.Mvc;
namespace StoreApp.Components
{
    public class OrderInProgressViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public OrderInProgressViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            return _manager
                .OrderService
                .NumberOfInProcess
                .ToString();

        }

    }
}
