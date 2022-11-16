using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using template.dal.entity;

namespace template.bl.models
{
   public class employeevm
    {
        public int id { get; set; }

        [Required(ErrorMessage = "name required")]
        [MaxLength(50,ErrorMessage ="max len is 50")]
        [MinLength(4,ErrorMessage ="minlen is 4")]
        public string name { get; set; }
        [Range(3000,30000,ErrorMessage ="salary btw 3000 to 30000")]
        public float salary { get; set; }
        public DateTime hiredate { get; set; }
        public bool isactive { get; set; }
        public string notes { get; set; }

        //11-aaa-cairo-egypt
        [RegularExpression("[0-9]{1,5}-[a-zA-Z]{3,10}-[a-zA-Z]{3,10}-[a-zA-Z]{3,10}",ErrorMessage = "11-aaa-cairo-egypt")]
        public string address { get; set; }



        [EmailAddress(ErrorMessage ="rnter format male")]
        public string email { get; set; }
        public DateTime creationdate { get; set; }

        [Required(ErrorMessage = "department required")]

        public int departmentid { get; set; }
        public department department { get; set; }


    }
}
