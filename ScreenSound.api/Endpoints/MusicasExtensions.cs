using Microsoft.AspNetCore.Mvc;
using ScreenSound.api.Requests;
using ScreenSound.Bancos;
using ScreenSound.Modelos;

namespace ScreenSound.api.Endpoints
{
    public static class MusicasExtensions
    {
        public static void AddEndpointsMusicas(this WebApplication app) {
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

            app.MapPost("/Musicas", ([FromServices] DAL<Musica> dal, [FromBody] MusicaRequest musicaRequest) =>
            {
                var musica = new Musica(musicaRequest.nome);
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
                var musica = new Musica(musicaRequestEdit.nome) { Id = musicaRequestEdit.id, AnoLancamento = musicaRequestEdit.anoLancamento,  };
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
    }
}