using Microsoft.EntityFrameworkCore;
using System.Data;
using Task2.Models;

namespace Task2.Context
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions options) : base(options)
        {
        }


       public  DbSet<AddressModel> Addresses {get; set;}


    }
}
