using System.ComponentModel.DataAnnotations;

namespace ScreenSound.api.Requests;
    public record ArtistaRequest([Required] string nome,[Required] string bio, string? FotoPerfil);