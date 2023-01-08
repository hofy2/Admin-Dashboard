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
    public class cityrep : Icityrep
    {
        private readonly templatecontext db;

        public cityrep(templatecontext db)
        {

            this.db = db;
        }

        public IEnumerable<city> get(Expression<Func<city, bool>> filter = null)
        {
            var data = db.city.Select(a => a);
            if(filter != null)
            {
                data = db.city.Where(filter);
            }
            return data;
        }




        public city getbyid(int id)
        {
            var data = db.city.Where(a => a.id == id).FirstOrDefault();


            return data;
        }

    }
}
