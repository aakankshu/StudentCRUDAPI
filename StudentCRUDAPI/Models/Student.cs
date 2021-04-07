using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCRUDAPI.Models
{
    public class Student
    {
        [Key]
        public Guid StudentID { get; set; }

        [Required]
        [MaxLength(21, ErrorMessage ="RollNo can only be 21 characters long!")]
        public string RollNo { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage ="FirstName can only be 15 characters long")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
