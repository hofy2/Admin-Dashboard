using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using template.dal.entity;

namespace template.bl.Interface
{
    public interface Icityrep
    {
        // this code allow me to put delegate into get function 
        IEnumerable<city> get(Expression<Func<city,bool>> filter = null);
        city getbyid(int id);
    }
}
