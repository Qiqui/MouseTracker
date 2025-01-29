using Microsoft.AspNetCore.Mvc;
using MouseTracker.Application.Interfaces;
using MouseTracker.Web.Helpers;
using MouseTracker.Web.Models;

namespace MouseTracker.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMouseMovementService _mouseMovementService;

        public HomeController(IMouseMovementService mouseMovementService)
        {
            _mouseMovementService = mouseMovementService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveMouseData([FromBody] List<MouseDataVM> data)
        {
            if (data == null || !data.Any())
            {
                return BadRequest("Данные не были переданы.");
            }
            var MouseData = data.ToMouseDataList();
            await _mouseMovementService.SaveMouseDataAsync(MouseData);
            return Ok();
        }

    }
}
