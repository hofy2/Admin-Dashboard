using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using template.dal.entity;

namespace template.bl.Interface
{
    public interface Iemployeerep
    {
        IEnumerable<employee> get();
        employee getbyid(int id);
        IEnumerable<employee> searchbyname(string name);

        void creat(employee obj);
        void update(employee obj);
        void delete(employee obj);



    }
}
