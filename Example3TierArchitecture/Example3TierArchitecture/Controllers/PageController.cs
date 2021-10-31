using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuisnessLayer;
using DataLayer.Enums;
using PresentationLayer;
using PresentationLayer.Models;

namespace Example3TierArchitecture.Controllers
{
    public class PageController : Controller
    {
        private DataManager _datamanager;
        private ServicesManager _servicesmanager;

        public PageController(DataManager dataManager)
        {
            _datamanager = dataManager;
            _servicesmanager = new ServicesManager(dataManager);
        }
        public IActionResult Index(int pageId, PageEnums.PageType pageType)
        {
            PageViewModel _viewModel;
            switch (pageType)
            {
                case PageEnums.PageType.Directory: _viewModel = _servicesmanager.Directorys.DirectoryDBToViewModelById(pageId); break;
                case PageEnums.PageType.Material: _viewModel = _servicesmanager.Materials.MaterialDBModelToView(pageId); break;
                default: _viewModel = null; break;
            }
            ViewBag.PageType = pageType;
            return View(_viewModel);
        }

        [HttpGet]
        public IActionResult PageEditor(int pageId, PageEnums.PageType pageType, int directoryId = 0)
        {
            PageEditModel _editModel;

            switch (pageType)
            {
                case PageEnums.PageType.Directory:
                    if (pageId != 0) _editModel = _servicesmanager.Directorys.GetDirectoryEdetModel(pageId);
                    else _editModel = _servicesmanager.Directorys.CreateNewDirectoryEditModel();
                    break;
                case PageEnums.PageType.Material:
                    if (pageId != 0) _editModel = _servicesmanager.Materials.GetMaterialEdetModel(pageId);
                    else _editModel = _servicesmanager.Materials.CreateNewMaterialEditModel(directoryId);
                    break;
                default: _editModel = null; break;
            }

            ViewBag.PageType = pageType;
            return View(_editModel);
        }

        [HttpPost]
        public IActionResult SaveDirectory(DirectoryEditModel model)
        {
            _servicesmanager.Directorys.SaveDirectoryEditModelToDb(model);
            return RedirectToAction("PageEditor", "Page", new { pageId = model.Id, pageType = PageEnums.PageType.Directory });
        }

        [HttpPost]
        public IActionResult SaveMaterial(MaterialEditModel model)
        {
            _servicesmanager.Materials.SaveMaterialEditModelToDb(model);
            return RedirectToAction("PageEditor", "Page", new { pageId = model.Id, pageType = PageEnums.PageType.Material });
        }
    }
}
