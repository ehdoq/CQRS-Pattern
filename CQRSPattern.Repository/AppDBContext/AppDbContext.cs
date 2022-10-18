using CQRSPattern.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CQRSPattern.Repository.AppDBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public IDbConnection Connection => Database.GetDbConnection();

        public DbSet<Product>? Products { get; set; }
    }
}