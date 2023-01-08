using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace template.dal.entity
{
    [Table("country")]
    public class country
    {
        public int id { get; set; }
        public string countryname { get; set; }
        public ICollection<city> city { get; set; }
    }
}
