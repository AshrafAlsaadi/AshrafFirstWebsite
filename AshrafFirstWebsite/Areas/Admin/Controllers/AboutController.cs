using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AshrafFirstWebsite.BL;
using AshrafFirstWebsite.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Domain;

namespace AshrafFirstWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
       
        IIAbout ics;
        public AboutController(IIAbout ic)
        {
            ics = ic;
        }
       
        public IActionResult MyAbout()
        {
            

            return View(ics.getall());
        }

        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                
                return View(ics.getallbyid(Convert.ToInt32(id)));
            }
            else
            {
                return View();
            }
            
        }

        public IActionResult Delete(int Id)
        {
            ics.Delete(Id);
            return RedirectToAction("MyAbout");
        }


        [HttpPost]
        public async Task<IActionResult> Save(About about, List<IFormFile> Files)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in Files)
                {
                    if (file.Length > 0)
                    {
                        string Image = Guid.NewGuid().ToString() + ".jpg";
                        var FilePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Admin\img", Image);
                        using (var stream = System.IO.File.Create(FilePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        about.Image = Image;
                    }

                }

                if (about.Id == 0 || about.Id == null)
                {
                    ics.Add(about);
                    return RedirectToAction("MyAbout");
                }


                else
                {
                    ics.Edit(about);
                    return RedirectToAction("MyAbout");
                }
            }
            else
            {
                return View("MyAbout");
            }
        }

    }
}

