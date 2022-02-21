
using AshrafFirstWebsite.Models;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AshrafFirstWebsite.BL
{
  public interface IIService
    {
        List<Service> getall();
        bool Add(Service serv);
        bool Edit(Service service);
        Service getallbyname(string name);
        bool Delete(string name);
    }
    public class CLSservice:IIService
    {
        FirstWebProjectContext fs;
       public CLSservice(FirstWebProjectContext fa)
        {
            fs = fa;
        }

        public List<Service> getall()
        {
            List<Service>serv=fs.Services.OrderByDescending(a=>a.ServiceName).ToList();  
            return serv;
        }

        public bool Add(Service serv)
        {
            try
            {
                fs.Add<Service>(serv);
                fs.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public Service getallbyname(string name)
        {
            Service service=fs.Services.FirstOrDefault(a=>a.ServiceName==name);
            return service;
        }

        public bool Delete(string name)
        {
            try
            {

                Service serv = fs.Services.Where(a => a.ServiceName== name).FirstOrDefault();
                fs.Services.Remove(serv);
                fs.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(Service service)
        {
            try
            {
                fs.Entry(service).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                fs.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}