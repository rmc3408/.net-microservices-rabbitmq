using Microsoft.EntityFrameworkCore;
using companyData;

namespace company.Models
{
    public class Contexto : DbContext
    { 
        public DbSet<Product> Products { get; set; }
        public DbSet<ClientModel> Client { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options) 
        { 

        }
        

    }
}
