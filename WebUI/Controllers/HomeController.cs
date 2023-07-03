using Business.Abstract;
using Core.Response;
using DataAccess.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkService _workService;
        public HomeController(IWorkService workService)
        {
            _workService = workService;
        }

        public async Task<IActionResult> Index()
        {

            var data = await _workService.GetWorkListDtos();
            HomePageModel model = new()
            {
                WorkListDtos = data.Data,
                CreateWorkDto = new Entities.DTOs.CreateWorkDto()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateWorkDto createWorkDto)
        {
            var data = await _workService.Add(createWorkDto);
            if (data.ResponseType == ResponseType.ValidationError)
            {
                foreach (var item in data.ValidationErrors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return RedirectToAction();
            }
            else
            {
                return RedirectToAction("Index");
            }
            

        }
        public async Task<IActionResult> Update(int id)
        {
            var workDto = await _workService.GetWorkListDto(id);
            return View(workDto.Data);
        }

        [HttpPost]
        public IActionResult Update(UpdateWorkDto updateWorkDto)
        {
            var data = _workService.Update(updateWorkDto);
            if (data.ResponseType == ResponseType.ValidationError)
            {
                foreach (var item in data.ValidationErrors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
         
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _workService.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
