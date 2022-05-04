using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CourseworkCauses.Models;

namespace CourseworkCauses.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //tables in database
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<CauseType> CauseTypes { get; set; }
        public DbSet<Cause> Causes { get; set; }
        public DbSet<Signature> Signatures { get; set; }
    }
}
