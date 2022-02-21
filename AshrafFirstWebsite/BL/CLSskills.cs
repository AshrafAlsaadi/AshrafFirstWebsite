using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using AshrafFirstWebsite.Models;

namespace AshrafFirstWebsite.BL
{
    public interface IISkills
    {
        List<Skill> getall();
        bool Add(Skill skl);
        Skill getallbyid(int id);
        bool Edit(Skill skill);
        bool Delete(int Id);
    }
    public class CLSskills:IISkills
    {
        FirstWebProjectContext fwc;
        public CLSskills(FirstWebProjectContext fff)
        {
            fwc = fff;
        }
        public List<Skill> getall()
        {
            List<Skill> sss = fwc.Skills.OrderByDescending(a => a.Id).ToList();
            return sss;
        }

        public bool Add(Skill skl)
        {
            try
            {
                fwc.Add<Skill>(skl);
                fwc.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public Skill getallbyid(int id)
        {
            Skill skill = fwc.Skills.FirstOrDefault(a => a.Id == id);
            return skill;
        }

        public bool Edit(Skill skill)
        {
            try
            {
                fwc.Entry(skill).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                fwc.SaveChanges();
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

                Skill skill = fwc.Skills.Where(a => a.Id == Id).FirstOrDefault();
                fwc.Skills.Remove(skill);
                fwc.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
