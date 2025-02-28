using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//DAO - Data Access Object
//DAL - Data Access Layer

namespace ScreenSound.Bancos
{
    internal class ArtistaDAL
    {
        private readonly ScreenSoundContext context;

        public ArtistaDAL(ScreenSoundContext context) //cria o context em todos os metodos abaixo
        {
            this.context = context;
        }

        public IEnumerable<Artista> Listar()
        {

            return context.Artistas.ToList(); //retorna a lista de artistas  
        }


        public void Adicionar(Artista artista)
        {
            try
            {
                context.Artistas.Add(artista); //retorna a lista de artistas  
                context.SaveChanges(); //salva as alterações no banco de dados

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar artista: {ex.Message}");
            }
        }

        public void Deletar(Artista artista)
        {

            context.Artistas.Remove(artista); //roda um delete no banco de dados
            context.SaveChanges(); //salva as alterações no banco de dados
        }

        public void Atualizar(Artista artista)
        {

            context.Artistas.Update(artista); //roda um update no banco de dados
            context.SaveChanges(); //salva as alterações no banco de dados

        }
        public IEnumerable<Artista> Buscar(string nome)
        {
            try
            {
                return context.Artistas.Where(a => a.Nome.Contains(nome)).ToList(); //busca artistas cujo nome contém a substring
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao procurar artista: {ex.Message}");
                return new List<Artista>();
            }
        }
    }
}