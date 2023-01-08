 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using template.bl.Interface;
using template.bl.models;
using template.dal.database;
using template.dal.entity;
using Microsoft.EntityFrameworkCore;
namespace template.bl.reposatry
{

   
    public class departmentrep : Idepartmentrep 
    {
        private readonly templatecontext db;

        public departmentrep(templatecontext db)
        {
        
            this.db = db;
        }
       

        public void creat(department obj)
        {

          
            db.department.Add(obj);
            db.SaveChanges();
        }

        public void delete(department obj)
        {
          
            db.department.Remove(obj);
            db.SaveChanges();
        }

      

        public void update(department obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

       public IEnumerable<department> get()
        {
            IQueryable<department> data = getrefactor();
            return data;
        }




        public department getbyid(int id)
        {
            var data = db.department.Where(a => a.id == id).FirstOrDefault();


            return data;
        }

        //====refactor=======
        private IQueryable<department> getrefactor()
        {
            return db.department.Select(a => a);
        }

        public IEnumerable<department> searchbyname(string name)
        {
            var data = db.department.Where(a => a.departmentname.Contains(name));
            return data;
        }
    }
}
