using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using template.dal.entity;

namespace template.bl.Interface
{
     public interface Idistrictrep
    {
        IEnumerable<district> get(Expression<Func<district, bool>> filter = null);
        district getbyid(int id);
    }
}
