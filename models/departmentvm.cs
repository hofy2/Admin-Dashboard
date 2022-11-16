using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace template.bl.models
{
   public class departmentvm
    {
        public int id { get; set; }

        [Required(ErrorMessage = "enter departmentname ")]
        [MinLength(4,ErrorMessage ="min5 cha")]
        [MaxLength(50,ErrorMessage ="max50 cha")]
        public string departmentname { get; set; }

        [Required(ErrorMessage = "enter departmentcode ")]
        [MinLength(4, ErrorMessage = "min5 cha")]
        [MaxLength(50, ErrorMessage = "max50 cha")]
        public string departmentcode { get; set; }

      
    

        //Nullable<int>
        // بيسمح بال null
        public Nullable<int> departmentsize { get; set; } 
    }
}
