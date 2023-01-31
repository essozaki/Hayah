using AutoMapper;
using Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pharmacy_Project.Bll;
using Pharmacy_Project.Data.Entities;
using Pharmacy_Project.Models;

namespace Pharmacy_Project.Controllers
{
    public class MedicalInformationController : Controller
    {

        private readonly IMedical_InformationRep _info;

        private readonly IMapper mapper;

        public MedicalInformationController(IMapper mapper, IMedical_InformationRep info)
        {
            this.mapper = mapper;
            _info=info;
        }

        public IActionResult Index()
        {
            var data = _info.Get();
            var result = mapper.Map<IEnumerable<Medical_InformationVM>>(data);
            return View(result);

        }



        [HttpGet]

        public IActionResult Create()
        {
          
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(Medical_InformationVM obj)
        {
            try
            {
                var img = UploadCv.uploadFile("Uploads/Medical_Information", obj.Photo);
                var data = mapper.Map<Medical_Information>(obj);
                data.ImgUrl = img;
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
            var result = mapper.Map<Medical_InformationVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(Medical_InformationVM model)
        {
            UploadCv.RemoveFile("Uploads/Medical_Information", model.ImgUrl);
            var olddata = _info.GetById(model.Id);
            _info.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edite(int id)
        {
            var data = _info.GetById(id);
            var result = mapper.Map<Medical_InformationVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edite(Medical_InformationVM model)

        {
            if (model.Photo == null)
            {
                var url = model.ImgUrl;
                var data = mapper.Map<Medical_Information>(model);
                data.ImgUrl = url;
                _info.Edite(data);
                return RedirectToAction("Index");
            }
            else
            {
                var IdentityImgUrl = UploadCv.uploadFile("Uploads/MedicalInformation", model.Photo);
                var data = mapper.Map<Medical_Information>(model);
                data.ImgUrl = IdentityImgUrl;
                _info.Edite(data);
                return RedirectToAction("Index");
            }

        }
      
    }

}
