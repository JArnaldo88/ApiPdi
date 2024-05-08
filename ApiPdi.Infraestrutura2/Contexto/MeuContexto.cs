using ApiPdi.Application2.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace ApiPdi.Infraestrutura2.Contexto
{
    public class MeuContexto : DbContext
    {
        public MeuContexto(DbContextOptions<MeuContexto> options) : base(options) 
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Corrigido
        //            .AddJsonFile("appsettings.json")
        //            .Build();

        //        string connectionString = configuration.GetConnectionString("DefaultConnection");
        //        optionsBuilder.UseMySQL(connectionString);
        //    }
        //}
    }
}
