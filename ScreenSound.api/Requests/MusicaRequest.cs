using System.ComponentModel.DataAnnotations;

namespace ScreenSound.api.Requests;
    public record MusicaRequest([Required] string nome, [Required] int artistaId, int? anoLancamento );
