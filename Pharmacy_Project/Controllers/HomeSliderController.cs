using AutoMapper;
using Helper;
using Microsoft.AspNetCore.Mvc;
using Pharmacy_Project.Bll;
using Pharmacy_Project.Data.Entities;
using Pharmacy_Project.Models;

namespace Pharmacy_Project.Controllers
{
    public class HomeSliderController : Controller
    {

        private readonly IHomeSliderRep _info;

        private readonly IMapper mapper;

        public HomeSliderController(IMapper mapper, IHomeSliderRep info)
        {
            this.mapper = mapper;
            _info = info;
        }

        public IActionResult Index()
        {
            var data = _info.Get();
            var result = mapper.Map<IEnumerable<HomeSliderVM>>(data);
            return View(result);

        }



        [HttpGet]

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(HomeSliderVM obj)
        {
            try
            {
                var img = UploadCv.uploadFile("Uploads/HomeSlider", obj.Photo);
                var data = mapper.Map<HomeSlider>(obj);
                data.SliderImgUrl = img;
                _info.Creat(data);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _info.GetById(id);
            var result = mapper.Map<HomeSliderVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(HomeSliderVM model)
        {
            UploadCv.RemoveFile("Uploads/HomeSlider", model.SliderImgUrl);
            var olddata = _info.GetById(model.Id);
            _info.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edite(int id)
        {
            var data = _info.GetById(id);
            var result = mapper.Map<HomeSliderVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edite(HomeSliderVM model)

        {
            if (model.Photo == null)
            {
                var url = model.SliderImgUrl;
                var data = mapper.Map<HomeSlider>(model);
                data.SliderImgUrl = url;
                _info.Edite(data);
                return RedirectToAction("Index");
            }
            else
            {
                var IdentitySliderImgUrl = UploadCv.uploadFile("Uploads/HomeSlider", model.Photo);
                var data = mapper.Map<HomeSlider>(model);
                data.SliderImgUrl = IdentitySliderImgUrl;
                _info.Edite(data);
                return RedirectToAction("Index");
            }

        }

    }

}
