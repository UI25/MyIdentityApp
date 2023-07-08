using IdentityApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IdentityApp.Data
{
    public class AuthDbContext :IdentityDbContext<AppUser, AppRole, Guid>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
