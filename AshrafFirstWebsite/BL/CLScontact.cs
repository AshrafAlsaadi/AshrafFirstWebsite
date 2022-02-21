using Domain;
using AshrafFirstWebsite.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace AshrafFirstWebsite.BL
{
    public interface IIContact
    {
        List<Contact> getall();
        bool Add(Contact ed);
        Contact getallbyid(int id);
        bool Delete(int id);
        bool Edit(Contact edu);
    }
    public class CLScontact: IIContact
    {
        FirstWebProjectContext co;
        public CLScontact(FirstWebProjectContext we)
        {
            co = we;
        }

        public List<Contact> getall()
        {
            List<Contact> ed = co.Contacts.OrderByDescending(a => a.Id).ToList();
            return ed;
        }

        public bool Add(Contact ed)
        {
            try
            {
                co.Add<Contact>(ed);
                co.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Contact getallbyid(int id)
        {
            Contact edu = co.Contacts.FirstOrDefault(a => a.Id == id);
            return edu;
        }

        public bool Delete(int id)
        {
            try
            {

                Contact ed = co.Contacts.Where(a => a.Id == id).FirstOrDefault();
                co.Contacts.Remove(ed);
                co.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(Contact edu)
        {
            try
            {
                co.Entry(edu).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                co.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
