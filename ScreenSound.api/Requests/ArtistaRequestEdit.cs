using ScreenSound.api.Requests;
namespace ScreenSound.API.Requests;

public record ArtistaRequestEdit(int Id, string nome, string bio, string? FotoPerfil)
    : ArtistaRequest(nome, bio, FotoPerfil);
