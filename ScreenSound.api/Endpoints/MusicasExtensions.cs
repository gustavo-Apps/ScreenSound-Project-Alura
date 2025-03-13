using Microsoft.AspNetCore.Mvc;
using ScreenSound.api.Requests;
using ScreenSound.Bancos;
using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos.Modelos;
using System;

namespace ScreenSound.api.Endpoints
{
    public static class MusicasExtensions
    {
        public static void AddEndpointsMusicas(this WebApplication app)
        {
            app.MapGet("/Musicas", ([FromServices] DAL<Musica> dal) =>
            {
                return Results.Ok(dal.Listar());
            });

            app.MapGet("/Musicas/{nome}", ([FromServices] DAL<Musica> dal, string nome) =>
            {
                var musica = dal.Buscar(m => m.Nome.ToUpper().Equals(nome.ToUpper()));
                if (musica is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(musica);
            });

            app.MapPost("/Musicas", ([FromServices] DAL<Musica> dal, [FromServices] DAL<Artista> artistaDal, [FromServices] DAL<Genero> dalGenero, [FromBody] MusicaRequest musicaRequest) =>
            {
                var artista = artistaDal.Buscar(a => a.Id == musicaRequest.artistaId).FirstOrDefault();
                if (artista is null)
                {
                    return Results.NotFound("Artista not found");
                }
                var musica = new Musica(musicaRequest.nome)
                {
                    Artista = artista, // Fix: Assign the Artista object instead of the artistaId
                    AnoLancamento = musicaRequest.anoLancamento,
                    Generos = musicaRequest.Generos is not null ? GeneroRequestConverter(musicaRequest.Generos, dalGenero) : new List<Genero>()
                };
                dal.Adicionar(musica);
                return Results.Ok();
            });

            app.MapDelete("/Musicas/{id}", ([FromServices] DAL<Musica> dal, int id) =>
            {
                var musica = dal.Buscar(m => m.Id == id).FirstOrDefault();
                if (musica is null)
                {
                    return Results.NotFound();
                }
                dal.Deletar(musica);
                return Results.NoContent();
            });

            app.MapPut("/Musicas", ([FromServices] DAL<Musica> dal, [FromBody] MusicaRequestEdit musicaRequestEdit) =>
            {
                var musica = new Musica(musicaRequestEdit.nome) { Id = musicaRequestEdit.id, AnoLancamento = musicaRequestEdit.anoLancamento, };
                var musicaAtualizar = dal.Buscar(m => m.Id == musica.Id).FirstOrDefault();
                if (musicaAtualizar is null)
                {
                    return Results.NotFound();
                }
                musicaAtualizar.Nome = musica.Nome;
                musicaAtualizar.AnoLancamento = musica.AnoLancamento;
                musicaAtualizar.Artista = musica.Artista;

                dal.Atualizar(musicaAtualizar);
                return Results.Ok();
            });
        }

        private static ICollection<Genero> GeneroRequestConverter(ICollection<GeneroRequest> generos, DAL<Genero> dalGenero)
        {
            var listaGeneros = new List<Genero>();
            foreach (var item in generos)
            {
                var entity = RequestToEntity(item);
                var genero = dalGenero.Buscar(g => g.Nome.ToUpper().Equals(item.Nome.ToUpper())).FirstOrDefault();

                if (genero is not null)
                {
                    listaGeneros.Add(genero);
                }
                else
                {
                    listaGeneros.Add(entity);
                }
            }
            return listaGeneros;
        }

        private static Genero RequestToEntity(GeneroRequest genero)
        {
            return new Genero() { Nome = genero.Nome, Descricao = genero.Descricao };
        }

       
    }
}