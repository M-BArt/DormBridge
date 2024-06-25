using Microsoft.AspNetCore.Mvc;

namespace DormBridge.API.Controllers
{
    public class BaseController<T> : ControllerBase where T : BaseController<T> 
    {
        private ILogger<T>? _logger;
        protected ILogger<T> Logger => _logger ??= HttpContext.RequestServices.GetRequiredService<ILogger<T>>();
    }
}
