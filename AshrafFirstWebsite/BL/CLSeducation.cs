using Domain;
using AshrafFirstWebsite.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AshrafFirstWebsite.Bl
{
    public interface IIeducation
    {
        List<Education> getall();
        bool Add(Education ed);
        Education getallbyid(int id);
        bool Delete(int id);
        bool Edit(Education edu);
    }
    public class CLSeducation:IIeducation
    {
        FirstWebProjectContext fss;
        public CLSeducation(FirstWebProjectContext ffs)
        {
            fss = ffs;
        }

        public List<Education> getall()
        {
            List<Education> ed = fss.Educations.OrderByDescending(a => a.Id).ToList();
            return ed;
        }

        public bool Add(Education ed)
        {
            try
            {
                fss.Add<Education>(ed);
                fss.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Education getallbyid(int id)
        {
            Education edu = fss.Educations.FirstOrDefault(a => a.Id== id);
            return edu;
        }

        public bool Delete(int id)
        {
            try
            {

                Education ed = fss.Educations.Where(a => a.Id== id).FirstOrDefault();
                fss.Educations.Remove(ed);
                fss.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(Education edu)
        {
            try
            {
                fss.Entry(edu).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                fss.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}