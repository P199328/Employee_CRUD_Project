using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplication_WinForm
{
    public class EmployeeModel
    {
        [Required(ErrorMessage = "Please enter id")]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required,EmailAddress]
        public string email { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string status { get; set; }

    }
}
