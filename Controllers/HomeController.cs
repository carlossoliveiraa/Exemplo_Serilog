using CentralizandoLogs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CentralizandoLogs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Exemplo de gravacao de log com Serilog");
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Exemplo de gravacao de log com Serilog");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogInformation("Exemplo de gravacao de log com Serilog");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}