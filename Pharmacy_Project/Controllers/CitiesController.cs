using AutoMapper;
using Helper;
using Microsoft.AspNetCore.Mvc;
using Pharmacy_Project.Bll;
using Pharmacy_Project.Data.Entities;
using Pharmacy_Project.Models;

namespace Pharmacy_Project.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICitiesRep _doc;

        private readonly IMapper mapper;

        public CitiesController(IMapper mapper, ICitiesRep doc)
        {
            this.mapper = mapper;
            this._doc = doc;
        }

        public IActionResult Index()
        {
            var data = _doc.Get();
            var result = mapper.Map<IEnumerable<CitiesVM>>(data);
            return View(result);

        }



        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(CitiesVM obj)
        {
            try
            {
             
                var data = mapper.Map<Cities>(obj);
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
            var result = mapper.Map<CitiesVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(CitiesVM model)
        {
            var olddata = _doc.GetById(model.Id);
            _doc.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edite(int id)
        {
            var data = _doc.GetById(id);
            var result = mapper.Map<CitiesVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edite(CitiesVM model)

        {


            var data = mapper.Map<Cities>(model);
            _doc.Edite(data);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var data = _doc.GetById(id);
            var result = mapper.Map<CitiesVM>(data);
            return View(result);
        }

    }

}
