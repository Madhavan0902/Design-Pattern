using Microsoft.EntityFrameworkCore;
using ShortCodeGeneratorService.Models;
namespace ShortCodeGeneratorService.Data
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<ShortCode> ShortCodes { get; set; }
    }
}