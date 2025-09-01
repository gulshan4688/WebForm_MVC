using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVCCrudwithAjax.Models
{
    public class Employee
    {
        [Required] // validates if any field is not left empty.
        public string Name { get; set; }

        [Required]
        public int? Code { get; set; }

        [Required]
        public int? Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? Dob { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public string Active { get; set; }

        public string? Image { get; set; }

    }
}


