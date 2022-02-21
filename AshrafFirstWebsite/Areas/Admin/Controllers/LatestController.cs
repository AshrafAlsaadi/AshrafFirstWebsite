using Microsoft.AspNetCore.Mvc;
using AshrafFirstWebsite.BL;
using AshrafFirstWebsite.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace AshrafFirstWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LatestController : Controller
    {
        IIlatest ill;
        public LatestController(IIlatest il)
        {
            ill= il;
        }
        public IActionResult MyLatest()
        {
            return View(ill.getall());
        }


        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                return View(ill.getallbyid(Convert.ToInt32(id)));
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Save(Latest li, List<IFormFile> Files)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in Files)
                {
                    if (file.Length > 0)
                    {
                        string Image = Guid.NewGuid().ToString() + ".jpg";
                        var FilePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Upload", Image);
                        using (var stream = System.IO.File.Create(FilePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        li.Image = Image;
                    }

                }
                if (li.Id == 0 || li.Id == null)
                {
                    ill.Add(li);
                    return RedirectToAction("MyLatest");
                }
                else
                {
                    ill.Edit(li);
                    return RedirectToAction("MyLatest");
                }



            }
            else
            {
                return View(li);
            }

        }


        public IActionResult Delete(int id)
        {
            ill.Delete(id);
            return RedirectToAction("MyLatest");
        }
    }
}

