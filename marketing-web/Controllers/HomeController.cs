using marketing_web.Interfaces;
using marketing_web.Models;
using marketing_web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace marketing_web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _emailService;
        private readonly IProjectRepository _projectRepository;

        public HomeController(ILogger<HomeController> logger,
                              IEmailService emailService,
                              IProjectRepository projectRepository)
        {
            _logger = logger;
            _emailService = emailService;
            _projectRepository = projectRepository;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel();
            var projects = _projectRepository.GetAllProjects().Take(5).ToList();
            model.Projects = projects;
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(Contact model)
        {
            _emailService.SendEmailAsync(model);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
