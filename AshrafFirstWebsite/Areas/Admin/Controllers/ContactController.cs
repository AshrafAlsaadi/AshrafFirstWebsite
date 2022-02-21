using Microsoft.AspNetCore.Mvc;
using AshrafFirstWebsite.BL;
using System;
using AshrafFirstWebsite.Models;

namespace AshrafFirstWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        IIContact ic;
        public ContactController(IIContact iContact)
        {
           ic = iContact;
        }
        public IActionResult MyContact()
        {
            return View(ic.getall());
        }

        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                return View(ic.getallbyid(Convert.ToInt32(id)));
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public IActionResult Save(Contact edu)
        {
            if (ModelState.IsValid)
            {
                if (edu.Id == null || edu.Id == 0)
                {
                    ic.Add(edu);
                    return RedirectToAction("MyContact");
                }
                else
                {
                    ic.Edit(edu);
                    return RedirectToAction("MyContact");
                }



            }
            else
            {
                return View(edu);
            }

        }


        public IActionResult Delete(int id)
        {
            ic.Delete(id);
            return RedirectToAction("MyContact");
        }
    }


}

