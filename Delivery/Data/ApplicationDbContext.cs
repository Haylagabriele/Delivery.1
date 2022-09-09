using Delivery.Models;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)

        {
        }

        public DbSet<EntregasModel> Entregas { get; set; }  

    }
}
