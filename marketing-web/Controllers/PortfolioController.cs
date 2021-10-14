using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using marketing_web.Interfaces;
using marketing_web.Models;
using marketing_web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace marketing_web.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUploadService _uploadService;
        private readonly IUserService _userService;

        public PortfolioController(IProjectRepository projectRepository,
                                   IUploadService uploadService,
                                   IUserService userService)
        {
            _projectRepository = projectRepository;
            _uploadService = uploadService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var model = _projectRepository.GetAllProjects();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _projectRepository.GetProjectById(id);
            return View(model);
        }

        [Authorize]
        public IActionResult List()
        {
            var model = new PortfolioViewModel();
            var projects = _projectRepository.GetAllProjects().Select(t => new ProjectViewModel
            {
                Id = t.Id,
                Name = t.Name,
                Category = t.Category,
                CoverPhotoPath = t.CoverPhoto,
                ClientLogoPath = t.ClientLogo,
                ClientName = t.ClientName,
                Address = t.Address,
                InsertedDate = t.InsertedDate
            }).ToList();

            model.Projects = projects;

            return View(model);
        }

        [Authorize]
        public IActionResult Add()
        {
            var model = new ProjectViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProjectViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = new Projects();
                model.Name = viewModel.Name;
                model.Description = viewModel.Description;
                model.ClientName = viewModel.ClientName;
                model.Category = viewModel.Category;
                model.Address = viewModel.Address;
                model.CoverPhoto = "1";
                model.ClientLogo = "1";
                model.InsertedDate = DateTime.Now;
                model.InsertedFrom = _userService.GetUserId();

                _projectRepository.Add(model);
                await _projectRepository.SaveChanges();

                var coverPhoto = await _uploadService.Upload(viewModel.CoverPhoto, "Projects", model.Id.ToString());
                model.CoverPhoto = coverPhoto;

                var clientLogo = await _uploadService.Upload(viewModel.ClientLogo, "Projects", model.Id.ToString());
                model.ClientLogo = clientLogo;

                await _projectRepository.Update(model);
            }
            else
            {
                return View(viewModel);
            }
            return RedirectToAction("List");
        }

        [Authorize]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _projectRepository.GetById(id);

            var viewModel = new ProjectUpdateViewModel();
            viewModel.Id = model.Id;
            viewModel.Name = model.Name;
            viewModel.Category = model.Category;
            viewModel.Description = model.Description;
            viewModel.CoverPhotoPath = model.CoverPhoto;
            viewModel.ClientLogoPath = model.ClientLogo;
            viewModel.ClientName = model.ClientName;
            viewModel.Address = model.Address;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProjectUpdateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = await _projectRepository.GetById(viewModel.Id);
                model.Name = viewModel.Name;
                model.Category = viewModel.Category;
                model.Description = viewModel.Description;
                model.ClientName = viewModel.ClientName;
                model.Address = viewModel.Address;
                model.ModifiedDate = DateTime.Now;
                model.ModifiedFrom = _userService.GetUserId();
                if (viewModel.CoverPhoto != null)
                {
                    _uploadService.Remove(model.CoverPhoto);
                    var coverPhoto = await _uploadService.Upload(viewModel.CoverPhoto, "Projects", model.Id.ToString());
                    model.CoverPhoto = coverPhoto;
                }

                if (viewModel.ClientLogo != null)
                {
                    _uploadService.Remove(model.ClientLogo);
                    var clientLogo = await _uploadService.Upload(viewModel.ClientLogo, "Projects", model.Id.ToString());
                    model.ClientLogo = clientLogo;
                }

                await _projectRepository.Update(model);
            }
            else
            {
                return View(viewModel);
            }
            return RedirectToAction("List");
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _projectRepository.GetById(id);
            _uploadService.Remove(model.CoverPhoto);
            _uploadService.Remove(model.ClientLogo);
            _projectRepository.Remove(model);
            await _projectRepository.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
