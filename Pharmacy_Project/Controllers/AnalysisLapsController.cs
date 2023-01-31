using AutoMapper;
using Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pharmacy_Project.Bll;
using Pharmacy_Project.Data.Entities;
using Pharmacy_Project.Models;

namespace Pharmacy_Project.Controllers
{
    public class AnalysisLapsController : Controller
    {
        private readonly IAnalysisLapsRep _Ident;
        private readonly ICitiesRep _city;
        private readonly IAreasRep _area;

        private readonly IMapper mapper;

        public AnalysisLapsController(IMapper mapper, IAnalysisLapsRep ident, ICitiesRep city, IAreasRep area)
        {
            this.mapper = mapper;
            this._Ident = ident;
            _city = city;
            _area = area;
        }

        public IActionResult Index()
        {
            var data = _Ident.Get();
            var result = mapper.Map<IEnumerable<AnalysisLapsVM>>(data);
            return View(result);

        }



        [HttpGet]

        public IActionResult Create()
        {
            ViewBag.CitiesList=new SelectList(_city.Get(),"Id", "Cite_Name");
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(AnalysisLapsVM obj)
        {
            try
            {
                var img = UploadCv.uploadFile("Uploads/AnalysisLaps", obj.Photo);
                var data = mapper.Map<AnalysisLaps>(obj);
                data.Lap_ImgUrl = img;
                _Ident.Creat(data);
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
            var data = _Ident.GetById(id);
            var result = mapper.Map<AnalysisLapsVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(AnalysisLapsVM model)
        {
            UploadCv.RemoveFile("Uploads/AnalysisLaps", model.Lap_ImgUrl);
            var olddata = _Ident.GetById(model.Id);
            _Ident.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edite(int id)
        {
            var data = _Ident.GetById(id);
            var result = mapper.Map<AnalysisLapsVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edite(AnalysisLapsVM model)

        {
            if (model.Photo == null)
            {
                var url = model.Lap_ImgUrl;
                var data = mapper.Map<AnalysisLaps>(model);
                data.Lap_ImgUrl = url;
                _Ident.Edite(data);
                return RedirectToAction("Index");
            }
            else
            {
                var IdentityImgUrl = UploadCv.uploadFile("Uploads/AnalysisLaps", model.Photo);
                var data = mapper.Map<AnalysisLaps>(model);
                data.Lap_ImgUrl = IdentityImgUrl;
                _Ident.Edite(data);
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public JsonResult GetAreaDataByCityId(int cityId)
        {
            var data = _area.Get().Where(x => x.CityId == cityId);
            return Json(data);
        }
    }

}
