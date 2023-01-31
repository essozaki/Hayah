using AutoMapper;
using Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pharmacy_Project.Bll;
using Pharmacy_Project.Data.Entities;
using Pharmacy_Project.Models;

namespace Pharmacy_Project.Controllers
{
    public class MedicalCentresController : Controller
    {
        
        private readonly IMedicalCentresRep _Ident;
        private readonly ICitiesRep _city;
        private readonly IAreasRep _area;

        private readonly IMapper mapper;

        public MedicalCentresController(IMapper mapper, IMedicalCentresRep ident, ICitiesRep city, IAreasRep area)
        {
            this.mapper = mapper;
            this._Ident = ident;
            _city = city;
            _area = area;
        }

        public IActionResult Index()
        {
            var data = _Ident.Get();
            var result = mapper.Map<IEnumerable<MedicalCentresVM>>(data);
            return View(result);

        }



        [HttpGet]

        public IActionResult Create()
        {
            ViewBag.CitiesList = new SelectList(_city.Get(), "Id", "Cite_Name");
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(MedicalCentresVM obj)
        {
            try
            {
                var img = UploadCv.uploadFile("Uploads/MedicalCentres", obj.Photo);
                var data = mapper.Map<MedicalCentres>(obj);
                data.Centers_NameImgUrl = img;
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
            var result = mapper.Map<MedicalCentresVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(MedicalCentresVM model)
        {
            UploadCv.RemoveFile("Uploads/MedicalCentres", model.Centers_NameImgUrl);
            var olddata = _Ident.GetById(model.Id);
            _Ident.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edite(int id)
        {
            var data = _Ident.GetById(id);
            var result = mapper.Map<MedicalCentresVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edite(MedicalCentresVM model)

        {
            if (model.Photo == null)
            {
                var url = model.Centers_NameImgUrl;
                var data = mapper.Map<MedicalCentres>(model);
                data.Centers_NameImgUrl = url;
                _Ident.Edite(data);
                return RedirectToAction("Index");
            }
            else
            {
                var IdentityImgUrl = UploadCv.uploadFile("Uploads/MedicalCentres", model.Photo);
                var data = mapper.Map<MedicalCentres>(model);
                data.Centers_NameImgUrl = IdentityImgUrl;
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
