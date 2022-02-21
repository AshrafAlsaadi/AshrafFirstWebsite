using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AshrafFirstWebsite.BL;
using Domain;
using AshrafFirstWebsite.Models;
using Microsoft.AspNetCore.Http;

namespace AshrafFirstWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillsController : Controller
    {
        IISkills iss;
        public SkillsController(IISkills iis)
        {
            iss = iis;
        }

        public IActionResult MySkills()
        {
            return View(iss.getall());
        }

        public IActionResult Delete(int Id)
        {
            iss.Delete(Id);
            return RedirectToAction("MySkills");
        }


        public IActionResult Edit(int? id)
        {
            if(id != null)
            {
                return View(iss.getallbyid(Convert.ToInt32(id)));
            }
            else
            {
                return View();
            }
           
        }

        [HttpPost]
        public IActionResult Save(Skill skl)
        {
            if (ModelState.IsValid)
            {
                if (skl.Id == 0 || skl.Id == null)
                {
                    iss.Add(skl);
                    return RedirectToAction("MySkills");
                }


                else
                {
                    iss.Edit(skl);
                    return RedirectToAction("MySkills");
                }

               
            }
            else
            {
                return View(skl);
            }
        
        }
    }
}
