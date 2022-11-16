using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using template.bl.Interface;
using template.dal.database;
using template.dal.entity;

namespace template.bl.reposatry
{
    public class employeerep : Iemployeerep
    {
        private readonly templatecontext db;

        public employeerep(templatecontext db)
        {

            this.db = db;
        }


        public void creat(employee obj)
        {


            db.employee.Add(obj);
            db.SaveChanges();
        }

        public void delete(employee obj)
        {

            db.employee.Remove(obj);
            db.SaveChanges();
        }



        public void update(employee obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<employee> get()
        {
            IQueryable<employee> data = getrefactor();
            return data;
        }




        public employee getbyid(int id)
        {
            var data = db.employee.Include("department").Where(a => a.id == id).FirstOrDefault();


            return data;
        }

        //====refactor=======
        private IQueryable<employee> getrefactor()
        {
            return db.employee.Include("department").Select(a => a);
        }

        public IEnumerable<employee> searchbyname(string name)
        {
            var data = db.employee.Include("department").Where(a => a.name.Contains(name));
            return data;
        }
    }
}
