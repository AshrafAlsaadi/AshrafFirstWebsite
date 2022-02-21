using Microsoft.AspNetCore.Mvc;
using AshrafFirstWebsite.BL;
using Domain;
using AshrafFirstWebsite.Models;
using System;

namespace AshrafFirstWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        IIService isx;
        public ServiceController(IIService isc)
        {
            isx = isc;
        }
        public IActionResult MyService()
        {
            return View(isx.getall());
        }

        public IActionResult Delete(string name)
        {
            isx.Delete(name);
            return RedirectToAction("MyService");
        }


        public IActionResult Edit(string name)
        {
            if (name != null)
            {
                return View(isx.getallbyname(name));
            }
            else
            {
                return View();
            }
            
        }

        [HttpPost]
        public IActionResult Save(Service serv)
        {
            if (ModelState.IsValid)
            {
                if(serv.ServiceName == null)
                {
                    isx.Add(serv);
                    return RedirectToAction("MyService");
                }
                else
                {
                    isx.Edit(serv);
                    return RedirectToAction("MyService");
                }

                
              
            }
            else
            {
                return View(serv);
            }
           
        }
    }
}
