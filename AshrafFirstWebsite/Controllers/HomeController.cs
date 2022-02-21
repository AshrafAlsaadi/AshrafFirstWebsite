using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AshrafFirstWebsite.BL;
using AshrafFirstWebsite.Models;
using AshrafFirstWebsite.Bl;

namespace AshrafFirstWebsite.Controllers
{
    public class HomeController : Controller
    {
        IIAbout ia;
        IISkills iss;
        IIService isi;
        IIeducation ii;
        IIlatest ili;
        IIContact iic;
        public HomeController(IIAbout iAbout,IISkills iSkills,IIService iService,IIeducation ieducation,IIlatest ilatest,IIContact iContact)
        {
            ia = iAbout;
            iss = iSkills;
            isi= iService;
            ii = ieducation;
            ili= ilatest; 
            iic= iContact;
        }
        public IActionResult Index()
        {
            ViewModel vmmodel = new ViewModel();
            vmmodel.AboutInfo = ia.getall().ToList();
           

            vmmodel.skillinfo = iss.getall();
            vmmodel.skillinfo = vmmodel.skillinfo.Take(1);

            vmmodel.serviceinfo=isi.getall().ToList();

            vmmodel.educationinfo=ii.getall().ToList();

            vmmodel.Latestinfo = ili.getall().ToList();

            vmmodel.contactinfo= iic.getall().ToList();
            
            return View(vmmodel);
        }
    }
}
