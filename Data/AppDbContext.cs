using Custom_Identity_practice.Models;
using Microsoft.AspNetCore.Identity;


namespace Custom_Identity_practice.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ):base(options)
        {
                
        }
    }
}
