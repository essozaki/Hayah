using AutoMapper;
using Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pharmacy_Project.Bll;
using Pharmacy_Project.Data.Entities;
using Pharmacy_Project.Models;

namespace Pharmacy_Project.Controllers
{
    
    public class ClincsController : Controller
    {
        private readonly IClincsRep _Ident;
        private readonly IAreasRep _area;
        private readonly ICitiesRep _city;

        private readonly IMapper mapper;

        public ClincsController(IMapper mapper, IClincsRep ident, IAreasRep area, ICitiesRep city)
        {
            this.mapper = mapper;
            this._Ident = ident;
            _area = area;
            _city = city;
        }

        public IActionResult Index()
        {
            var data = _Ident.Get();
            var result = mapper.Map<IEnumerable<ClincsVM>>(data);
            return View(result);

        }



        [HttpGet]

        public IActionResult Create()
        {
            ViewBag.CitiesList = new SelectList(_city.Get(), "Id", "Cite_Name");
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(ClincsVM obj)
        {
            try
            {
                var img = UploadCv.uploadFile("Uploads/Clincs", obj.Photo);
                var data = mapper.Map<Clincs>(obj);
                data.Clin_NameImgUrl = img;
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
            var result = mapper.Map<ClincsVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(ClincsVM model)
        {
            UploadCv.RemoveFile("Uploads/Clincs", model.Clin_NameImgUrl);
            var olddata = _Ident.GetById(model.Id);
            _Ident.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edite(int id)
        {
            var data = _Ident.GetById(id);
            var result = mapper.Map<ClincsVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edite(ClincsVM model)

        {
            if (model.Photo == null)
            {
                var url = model.Clin_NameImgUrl;
                var data = mapper.Map<Clincs>(model);
                data.Clin_NameImgUrl = url;
                _Ident.Edite(data);
                return RedirectToAction("Index");
            }
            else
            {
                var IdentityImgUrl = UploadCv.uploadFile("Uploads/Clincs", model.Photo);
                var data = mapper.Map<Clincs>(model);
                data.Clin_NameImgUrl = IdentityImgUrl;
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
