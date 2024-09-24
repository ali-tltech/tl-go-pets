using Microsoft.EntityFrameworkCore;

namespace TLCAREERSCORE.Services
{
	public class AppDbContext : DbContext
    {
        private readonly DbContextOptions<AppDbContext> options;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            this.options = options;
        }

    }
}
