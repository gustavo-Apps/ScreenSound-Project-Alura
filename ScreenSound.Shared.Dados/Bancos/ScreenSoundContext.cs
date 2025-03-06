using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Bancos
{
    public class ScreenSoundContext: DbContext
    {
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Musica> Musicas { get; set; }


        private string connectionServer = "Data Source=(localdb)\\MSSQLLocalDB;Initial " +
                    "Catalog=screenSoundV1;Integrated Security=True;Encrypt=False;";
        //atribuir a conexao a uma variavel privada
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            optionsBuilder.UseSqlServer(connectionServer)
                          .UseLazyLoadingProxies();
        }
    }
}
