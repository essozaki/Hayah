using AutoMapper;
using Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharmacy_Project.Bll;
using Pharmacy_Project.Data.Entities;
using Pharmacy_Project.Models;

namespace Pharmacy_Project.Controllers
{
    [Authorize]

    public class ClientController : Controller
    {
        private readonly IClientRep _doc;

        private readonly IMapper mapper;

        public ClientController(IMapper mapper, IClientRep doc)
        {
            this.mapper = mapper;
            this._doc = doc;
        }

        public IActionResult Index()
        {
            var data = _doc.Get();
            var result = mapper.Map<IEnumerable<ClientVM>>(data);
            return View(result);

        }



        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(ClientVM obj)
        {
            try
            {
                var data = mapper.Map<Client>(obj);
                _doc.Creat(data);
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
            var data = _doc.GetById(id);
            var result = mapper.Map<ClientVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(ClientVM model)
        {
            var olddata = _doc.GetById(model.Id);
            _doc.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edite(int id)
        {
            var data = _doc.GetById(id);
            var result = mapper.Map<ClientVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edite(ClientVM model)

        {
          
               
                var data = mapper.Map<Client>(model);
                _doc.Edite(data);
                return RedirectToAction("Index");
            }
        public IActionResult Details(int id)
        {
            var data = _doc.GetById(id);
            var result = mapper.Map<ClientVM>(data);
            return View(result);
        }

    }

    }
