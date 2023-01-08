using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace template.dal.entity
{
    [Table("district")]
  public  class district
    {
        public int id { get; set; }
        public string districtname { get; set; }
        public int cityid { get; set; }
        public city city { get; set; }
        public ICollection<employee> employee { get; set; }
    }
}
