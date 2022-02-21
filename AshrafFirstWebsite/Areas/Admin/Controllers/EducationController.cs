using Microsoft.AspNetCore.Mvc;
using AshrafFirstWebsite.BL;
using AshrafFirstWebsite.Bl;
using AshrafFirstWebsite.Models;
using System;

namespace AshrafFirstWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EducationController : Controller
    {
        IIeducation es;
        public EducationController(IIeducation ed)
        {
            es = ed;
        }
        public IActionResult MyEducation()
        {
            return View(es.getall());
        }

        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                return View(es.getallbyid(Convert.ToInt32(id)));
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public IActionResult Save(Education edu)
        {
            if (ModelState.IsValid)
            {
                if (edu.Id == null||edu.Id==0)
                {
                    es.Add(edu);
                    return RedirectToAction("MyEducation");
                }
                else
                {
                    es.Edit(edu);
                    return RedirectToAction("MyEducation");
                }



            }
            else
            {
                return View(edu);
            }

        }


        public IActionResult Delete(int id)
        {
            es.Delete(id);
            return RedirectToAction("MyEducation");
        }
    }
}
