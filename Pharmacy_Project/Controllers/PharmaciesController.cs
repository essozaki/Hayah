using AutoMapper;
using Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pharmacy_Project.Bll;
using Pharmacy_Project.Data.Entities;
using Pharmacy_Project.Models;

namespace Pharmacy_Project.Controllers
{
    
    public class PharmaciesController : Controller
    {
        private readonly IPharmaciesRep _Ident;
        private readonly ICitiesRep _city;
        private readonly IAreasRep _area;

        private readonly IMapper mapper;

        public PharmaciesController(IMapper mapper, IPharmaciesRep ident, ICitiesRep city, IAreasRep area)
        {
            this.mapper = mapper;
            this._Ident = ident;
            _city = city;
            _area = area;
        }

        public IActionResult Index()
        {
            var data = _Ident.Get();
            var result = mapper.Map<IEnumerable<PharmaciesVM>>(data);
            return View(result);

        }



        [HttpGet]

        public IActionResult Create()
        {
            ViewBag.CitiesList = new SelectList(_city.Get(), "Id", "Cite_Name");
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(PharmaciesVM obj)
        {
            try
            {
                var img = UploadCv.uploadFile("Uploads/Pharmacies", obj.Photo);
                var data = mapper.Map<Pharmacies>(obj);
                data.Pharm_NameImgUrl = img;
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
            var result = mapper.Map<PharmaciesVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(PharmaciesVM model)
        {
            UploadCv.RemoveFile("Uploads/Pharmacies", model.Pharm_NameImgUrl);
            var olddata = _Ident.GetById(model.Id);
            _Ident.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edite(int id)
        {
            var data = _Ident.GetById(id);
            var result = mapper.Map<PharmaciesVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edite(PharmaciesVM model)

        {
            if (model.Photo == null)
            {
                var url = model.Pharm_NameImgUrl;
                var data = mapper.Map<Pharmacies>(model);
                data.Pharm_NameImgUrl = url;
                _Ident.Edite(data);
                return RedirectToAction("Index");
            }
            else
            {
                var IdentityImgUrl = UploadCv.uploadFile("Uploads/Pharmacies", model.Photo);
                var data = mapper.Map<Pharmacies>(model);
                data.Pharm_NameImgUrl = IdentityImgUrl;
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
