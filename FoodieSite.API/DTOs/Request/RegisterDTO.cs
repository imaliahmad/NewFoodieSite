using FoodieSite.CQRS.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using FoodieSite.API.DTOs.Response;

namespace FoodieSite.API.DTOs.Request
{
    public class RegisterDTO:BaseEntityDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Contact1 { get; set; }
        public string Contact2 { get; set; }
    }
}
