using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using template.bl.models;
using template.dal.entity;

namespace template.bl.Interface
{
   public interface Idepartmentrep
    {
        IEnumerable<department> get();
        department getbyid(int id);
        IEnumerable<department> searchbyname(string name);

        void creat(department obj);
        void update(department obj);
        void delete(department obj);


    }
}
