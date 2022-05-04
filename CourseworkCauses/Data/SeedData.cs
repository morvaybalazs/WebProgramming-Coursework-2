using CourseworkCauses.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CourseworkCauses.Data
    //seed admin user details
{
    public class SeedData
    {
        //database connection
        private readonly ApplicationDbContext _context;

        public SeedData(ApplicationDbContext context)
        {
            _context = context;
        }

        //method to seed admin user
        // used to create new identitiy role
        public async Task SeedAdminUser()
        {
            // create new role and user store
            var roleStore = new RoleStore<IdentityRole>(_context);
            var userStore = new UserStore<ApplicationUser>(_context);

            var user = new ApplicationUser
            {
                //new admin user details
                UserName = "admin2@cause.com",
                NormalizedUserName = "admin2@cause.com",
                Email = "admin2@cause.com",
                NormalizedEmail = "admin2@cause.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            //hashing password
            var pwhasher = new PasswordHasher<ApplicationUser>();
            var hashedPassword = pwhasher.HashPassword(user, "adminpassword1234");
            user.PasswordHash = hashedPassword;
            //returns true if admin already exists
            var hasAdminRole = _context.Roles.Any(roles => roles.Name == "Admin");
            //if it doesnt exist create the new role
            if (!hasAdminRole)
            {
                await roleStore.CreateAsync(new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "admin"
                });
            }

            //check if database has a user with this name already
            var hasAdminUser = _context.Users.Any(u => u.NormalizedUserName == user.UserName);
            //if not, create it add admin role to user
            if (!hasAdminUser)
            {
                await userStore.CreateAsync(user);
                await userStore.AddToRoleAsync(user, "Admin");
            }

            await _context.SaveChangesAsync();
        }
    }
}


