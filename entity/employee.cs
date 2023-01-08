using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;// التعديل جوا التيبل نفسه
using System.ComponentModel.DataAnnotations.Schema;
namespace template.dal.entity
{
    [Table("employee")]

    public class employee
    {
        public employee()
        {
            creationdate = DateTime.Now;
        }
        public int id { get; set; }
        [StringLength(50)]
        public string name { get; set; }
        public float salary { get; set; }
        public DateTime hiredate { get; set; }
        public bool isactive { get; set; }
        public string notes { get; set; }
        public string address { get; set; }

        public string email { get; set; }
        public DateTime creationdate { get; set; }

        public int departmentid { get; set; }
        [ForeignKey("departmentid")]
        public department department { get; set; }

        public int districtid { get; set; }

        public district district { get; set; }

        public string cvurl { get; set; }
        public string imgurl { get; set; }

    }
}
