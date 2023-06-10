using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace FoodieSite.CQRS.Data
{
    public class SeedData
    {
        public void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "Admin",
                },
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Manager",
                    NormalizedName = "Manager",
                },
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "TeamLeader",
                    NormalizedName = "TeamLeader",
                },
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                    NormalizedName = "User",
                }
            );
        }
    }
}
