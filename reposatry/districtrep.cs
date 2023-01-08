using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using template.bl.Interface;
using template.dal.database;
using template.dal.entity;

namespace template.bl.reposatry
{
   public class districtrep : Idistrictrep
    {
        private readonly templatecontext db;

        public districtrep(templatecontext db)
        {

            this.db = db;
        }

        public IEnumerable<district> get(Expression<Func<district, bool>> filter = null)
        {
            var data = db.district.Select(a => a);
            if (filter != null)
            {
                data = db.district.Where(filter);
            }
            return data;

          
      



        }




        public district getbyid(int id)
        {
            var data = db.district.Where(a => a.id == id).FirstOrDefault();


            return data;
        }
    }
}
