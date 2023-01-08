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
    public class countryrep : Icountryrep
    {
        private readonly templatecontext db;

        public countryrep (templatecontext db)
        {

            this.db = db;
        }

        public IEnumerable<country> get()
        {
            var data = db.country.Select(a => a) ;
            return data;
        }




        public country getbyid(int id)
        {
            var data = db.country.Where(a => a.id == id).FirstOrDefault();


            return data;
        }


    }
}
