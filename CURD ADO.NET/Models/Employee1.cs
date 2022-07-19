using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CURD_ADO.NET.Models
{

    [Table("Emploee1")]
    public class Employee1 { 


         //Write this on Head of Id So it apply on Id

    [Key]
    [ScaffoldColumn(false)]

     public int Id { get; set; }







        [Required(ErrorMessage = "Employee Name Feild Reqiured")]
        [DataType(DataType.Text)]
        [Display(Name = "Employee Name")]
        public string Name { get; set; }





        //Write this on Head of Price So it apply on Price

        [Range(minimum: 20000, maximum: 5000000)]

        [Required(ErrorMessage = "Salary Is Required")]
        [Display(Name = "Employee Salary")]

        public int Salary { get; set; }


    }
}
