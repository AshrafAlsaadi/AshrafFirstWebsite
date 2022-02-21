using Domain;
using AshrafFirstWebsite.Models;
using System.Linq;
using System.Collections.Generic;
using System;

namespace AshrafFirstWebsite.BL
{
    public interface IIlatest
    {
        List<Latest> getall();
        bool Add(Latest ls);
        Latest getallbyid(int id);
        bool Delete(int id);
        bool Edit(Latest edu);
    }
   
    public class CLSlatest:IIlatest
    {
        FirstWebProjectContext ss;
        public CLSlatest(FirstWebProjectContext fs)
        {
            ss= fs;
        }

        public List<Latest> getall()
        {
            List<Latest> ed = ss.Latests.OrderByDescending(a => a.Id).ToList();
            return ed;
        }

        public bool Add(Latest ls)
        {
            try
            {
                ss.Add<Latest>(ls);
                ss.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Latest getallbyid(int id)
        {
            Latest edu = ss.Latests.FirstOrDefault(a => a.Id == id);
            return edu;
        }

        public bool Delete(int id)
        {
            try
            {

                Latest ed = ss.Latests.Where(a => a.Id == id).FirstOrDefault();
                ss.Latests.Remove(ed);
                ss.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(Latest edu)
        {
            try
            {
                ss.Entry(edu).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ss.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
