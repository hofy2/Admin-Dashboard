using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using template.dal.entity;

namespace template.bl.Interface
{
    public interface Icountryrep
    {
        IEnumerable<country> get(); 
        country getbyid(int id);
    }
}
