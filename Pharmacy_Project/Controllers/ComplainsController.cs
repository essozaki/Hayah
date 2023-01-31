using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pharmacy_Project.Bll;
using Pharmacy_Project.Data.Entities;
using Pharmacy_Project.Models;

namespace Pharmacy_Project.Controllers
{
    public class ComplainsController : Controller
    {
        private readonly IComplainsRep _doc;

        private readonly IMapper mapper;

        public ComplainsController(IMapper mapper, IComplainsRep doc)
        {
            this.mapper = mapper;
            this._doc = doc;
        }

        public IActionResult Index()
        {
            var data = _doc.Get();
            var result = mapper.Map<IEnumerable<ComplainsVM>>(data);
            return View(result);

        }



        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(ComplainsVM obj)
        {
            try
            {
                var data = mapper.Map<Complains>(obj);
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
            var result = mapper.Map<ComplainsVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(ComplainsVM model)
        {
            var olddata = _doc.GetById(model.Id);
            _doc.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edite(int id)
        {
            var data = _doc.GetById(id);
            var result = mapper.Map<ComplainsVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edite(ComplainsVM model)

        {


            var data = mapper.Map<Complains>(model);
            _doc.Edite(data);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var data = _doc.GetById(id);
            var result = mapper.Map<ComplainsVM>(data);
            return View(result);
        }

    }

}
