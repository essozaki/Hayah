using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pharmacy_Project.Bll;
using Pharmacy_Project.Data.Entities;
using Pharmacy_Project.Models;

namespace Pharmacy_Project.Controllers
{
    public class AreasController : Controller
    {
        private readonly IAreasRep _doc;
        private readonly ICitiesRep _cit;

        private readonly IMapper mapper;

        public AreasController(IMapper mapper, IAreasRep doc, ICitiesRep cit)
        {
            this.mapper = mapper;
            this._doc = doc;
            this._cit = cit;
        }

        public IActionResult Index()
        {
            var data = _doc.Get();
            var result = mapper.Map<IEnumerable<AreasVM>>(data);
            return View(result);

        }



        [HttpGet]

        public IActionResult Create()
        {
            var cits = _cit.Get();
            ViewBag.CitiesList = new SelectList(cits, "Id", "Cite_Name");
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(AreasVM obj)
        {
            try
            {
                var data = mapper.Map<Areas>(obj);
                _doc.Creat(data);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _doc.GetById(id);
            var result = mapper.Map<AreasVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(AreasVM model)
        {
            var olddata = _doc.GetById(model.Id);
            _doc.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edite(int id)
        {
            var cits = _cit.Get();
            ViewBag.CitiesList = new SelectList(cits, "Id", "Cite_Name");

            var data = _doc.GetById(id);
            var result = mapper.Map<AreasVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edite(AreasVM model)

        {


            var data = mapper.Map<Areas>(model);
            _doc.Edite(data);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var data = _doc.GetById(id);
            var result = mapper.Map<AreasVM>(data);
            return View(result);
        }

    }

}
