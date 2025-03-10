using ScreenSound.Shared.Modelos.Modelos;
namespace ScreenSound.Modelos;

/// <summary>
/// Represents a music track.
/// </summary>
public class Musica
{
    /// <summary>
    /// Gets or sets the collection of music tracks.
    /// </summary>
    public virtual ICollection<Musica> Musicas { get; set; } = new List<Musica>();

    /// <summary>
    /// Initializes a new instance of the <see cref="Musica"/> class.
    /// </summary>
    /// <param name="nome">The name of the music track.</param>
    public Musica(string nome)
    {
        Nome = nome;
    }

    /// <summary>
    /// Gets or sets the name of the music track.
    /// </summary>
    public string Nome { get; set; }

    /// <summary>
    /// Gets or sets the ID of the music track.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the release year of the music track.
    /// </summary>
    public int? AnoLancamento { get; set; }

    /// <summary>
    /// Gets or sets the link to the music track.
    /// </summary>
    public string? Link { get; set; }

    /// <summary>
    /// Gets or sets the artist associated with the music track.
    /// </summary>
    public virtual Artista? Artista { get; set; }

    public virtual ICollection<Genero> Generos { get; set; }
    /// <summary>
    /// Displays the technical details of the music track.
    /// </summary>
    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
    }

    /// <summary>
    /// Returns a string representation of the music track.
    /// </summary>
    /// <returns>A string representation of the music track.</returns>
    public override string ToString()
    {
        return @$"Id: {Id}
        Nome: {Nome}";
    }
}