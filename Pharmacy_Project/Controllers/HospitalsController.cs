using AutoMapper;
using Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pharmacy_Project.Bll;
using Pharmacy_Project.Data.Entities;
using Pharmacy_Project.Models;

namespace Pharmacy_Project.Controllers
{
    
    public class HospitalsController : Controller
    {
        private readonly IHospitalsRep _Ident;
        private readonly ICitiesRep _city;
        private readonly IAreasRep _area;

        private readonly IMapper mapper;

        public HospitalsController(IMapper mapper, IHospitalsRep ident, ICitiesRep city, IAreasRep area)
        {
            this.mapper = mapper;
            this._Ident = ident;
            _city = city;
            _area = area;
        }

        public IActionResult Index()
        {
            var data = _Ident.Get();
            var result = mapper.Map<IEnumerable<HospitalsVM>>(data);
            return View(result);

        }



        [HttpGet]

        public IActionResult Create()
        {
            ViewBag.CitiesList = new SelectList(_city.Get(), "Id", "Cite_Name");
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(HospitalsVM obj)
        {
            try
            {
                var img = UploadCv.uploadFile("Uploads/Hospitals", obj.Photo);
                var data = mapper.Map<Hospitals>(obj);
                data.Hospt_NameImgUrl = img;
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
            var result = mapper.Map<HospitalsVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(HospitalsVM model)
        {
            UploadCv.RemoveFile("Uploads/Hospitals", model.Hospt_NameImgUrl);
            var olddata = _Ident.GetById(model.Id);
            _Ident.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edite(int id)
        {
            var data = _Ident.GetById(id);
            var result = mapper.Map<HospitalsVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edite(HospitalsVM model)

        {
            if (model.Photo == null)
            {
                var url = model.Hospt_NameImgUrl;
                var data = mapper.Map<Hospitals>(model);
                data.Hospt_NameImgUrl = url;
                _Ident.Edite(data);
                return RedirectToAction("Index");
            }
            else
            {
                var IdentityImgUrl = UploadCv.uploadFile("Uploads/Hospitals", model.Photo);
                var data = mapper.Map<Hospitals>(model);
                data.Hospt_NameImgUrl = IdentityImgUrl;
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
