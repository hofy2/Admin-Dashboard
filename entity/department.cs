using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;// التعديل جوا التيبل نفسه
using System.ComponentModel.DataAnnotations.Schema;
namespace template.dal.entity
{
    [Table("departments")]
   public class department
    {
      //  [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity) ] 
        public int id { get; set; }
        [StringLength(50)]
        public string departmentname { get; set; }
        [StringLength(50)]
        public string departmentcode { get; set; }
        public Nullable<int> departmentsize { get; set; } 

        public ICollection<employee> employee { get; set; }
    }
}
