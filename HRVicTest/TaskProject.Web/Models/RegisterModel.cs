using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskProject.Bussiness.Models;

namespace TaskProject.Web.Models
{
    public class RegisterModel
    {
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StringLength(15)]
        public string Phone { get; set; }
        [StringLength(50)]
        [Required]
        public string UserName { get; set; }
        [StringLength(50)]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        [System.ComponentModel.DataAnnotations.Compare(nameof(Password), ErrorMessage = "Password mismatch")]
        public string ConfirmPassword { get; set; }
        [Required]
        public int RoleId { get; set; }
        public IEnumerable<SelectListItem> RolesDb { get; set; }
    }
}