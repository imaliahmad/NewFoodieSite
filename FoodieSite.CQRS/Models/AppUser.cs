using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Models
{
    public class AppUser : IdentityUser
    {
        [Column("first_name", TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [Column("last_name", TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [Column("password", TypeName = "nvarchar(max)")]
        public string Password { get; set; }

        [Column("address", TypeName = "nvarchar(max)")]
        public string Address { get; set; }

        [Column("contact1", TypeName = "nvarchar(max)")]
        public string Contact1 { get; set; }

        [Column("contact2", TypeName = "nvarchar(max)")]
        public string? Contact2 { get; set; }

        [Column("created_by", TypeName = "nvarchar(max)")]
        public string CreatedBy { get; set; }

        [Column("created_date")]
        public DateTime CreatedDate { get; set; }

        [Column("modified_by", TypeName = "nvarchar(max)")]
        public string? ModifiedBy { get; set; }

        [Column("modified_date")]
        public DateTime? ModifiedDate { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        public AppUser()
        {
        }

        public AppUser(string firstName, string lastName, string password,
            string address, string contact1, string? contact2, string createdBy,
            DateTime createdDate, string modifiedBy, DateTime? modifiedDate,
            bool isActive)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Address = address;
            Contact1 = contact1;
            Contact2 = contact2;
            CreatedBy = createdBy;
            CreatedDate = createdDate;
            ModifiedBy = modifiedBy;
            ModifiedDate = modifiedDate;
            IsActive = isActive;
        }
    }
}
