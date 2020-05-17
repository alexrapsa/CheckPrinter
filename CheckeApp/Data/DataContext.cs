using CheckeApp.Models;
using Microsoft.EntityFrameworkCore;


namespace CheckeApp.Data
{
    public class DataContext : DbContext
    {
         public DataContext(DbContextOptions<DataContext> options) : base(options) {}

         public DbSet<Check> Checks { get; set; }
         public DbSet<Payee> Payees { get; set; }
         public DbSet<User> Users { get; set; }
    }
}