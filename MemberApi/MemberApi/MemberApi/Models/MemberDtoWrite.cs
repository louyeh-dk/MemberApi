using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace MemberApi.Models
{
    public class MemberDtoWrite
    {

        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(50, ErrorMessage = "FirstName cannot be more then 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [StringLength(50, ErrorMessage = "LastName cannot be more then 50 characters")]
        public string LastName { get; set; }
        [StringLength(50, ErrorMessage = "MiddelName cannot be more then 50 characters")]
        public string MiddelName { get; set; }
        [StringLength(50, ErrorMessage = "Mail cannot be more then 50 characters")]
        public string Mail { get; set; }

        [StringLength(10, MinimumLength = 7, ErrorMessage = "Mobile number should be 7 - 10 digits")]
        public string Mobile { get; set; }
    }
}
