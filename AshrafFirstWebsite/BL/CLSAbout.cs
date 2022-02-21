using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AshrafFirstWebsite.Models;


namespace AshrafFirstWebsite.BL
{
    public interface IIAbout
    {
        List<About> getall();
        bool Add(About about);
        About getallbyid(int id);
        bool Edit(About about);
        bool Delete(int Id);
    }
    public class CLSAbout:IIAbout
    {
        FirstWebProjectContext fw;
        public CLSAbout(FirstWebProjectContext fwp)
        {
            fw = fwp;
        }
        public List<About> getall()
        {
            
            List<About> Myabout = fw.Abouts.OrderByDescending(a => a.Id).ToList();
            return Myabout;
        }

        public bool Add(About about)
        {
            try
            {
                
                fw.Add<About>(about);
                fw.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public About getallbyid(int id)
        {
           
            About about = fw.Abouts.FirstOrDefault(a => a.Id == id);
            return about;
        }

        public bool Edit(About about)
        {
            try
            {
                
                fw.Entry(about).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                fw.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int Id)
        {
            try
            {

                About oslide = fw.Abouts.Where(a => a.Id == Id).FirstOrDefault();
                fw.Abouts.Remove(oslide);
                fw.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
