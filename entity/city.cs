using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace template.dal.entity
{
    [Table("city")]
         public  class city
    {
        public int id { get; set; }
        public string cityname { get; set; }
        public int countryid { get; set; }
        public country country { get; set; }
        public ICollection<district> districts { get; set; }
    }
}
