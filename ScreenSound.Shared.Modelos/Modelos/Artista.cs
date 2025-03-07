namespace ScreenSound.Modelos;

/// <summary>
/// Represents an artist.
/// </summary>
public class Artista
{
    /// <summary>
    /// Gets or sets the collection of music associated with the artist.
    /// </summary>
    public virtual ICollection<Musica> Musicas { get; set; } = new List<Musica>();

    /// <summary>
    /// Initializes a new instance of the <see cref="Artista"/> class.
    /// </summary>
    /// <param name="nome">The name of the artist.</param>
    /// <param name="bio">The biography of the artist.</param>
    public Artista(string nome, string bio, int id, string fotoPerfil)
    {
        Nome = nome;
        Bio = bio;
        Id = id;
        FotoPerfil = fotoPerfil;
        FotoPerfil = "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png";
    }

    public Artista(string nome, string bio)
    {
        Nome = nome;
        Bio = bio;
    }

    /// <summary>
    /// Gets or sets the name of the artist.
    /// </summary>
    public string Nome { get; set; }

    /// <summary>
    /// Gets or sets the profile picture URL of the artist.
    /// </summary>
    public string FotoPerfil { get; set; }

    /// <summary>
    /// Gets or sets the biography of the artist.
    /// </summary>
    public string Bio { get; set; }

    /// <summary>
    /// Gets or sets the ID of the artist.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Adds a music to the artist's collection.
    /// </summary>
    /// <param name="musica">The music to add.</param>
    public void AdicionarMusica(Musica musica)
    {
        Musicas.Add(musica);
    }

    /// <summary>
    /// Displays the artist's discography.
    /// </summary>
    public void ExibirDiscografia()
    {
        Console.WriteLine($"Discografia do artista {Nome}");
        foreach (var musica in Musicas)
        {
            Console.WriteLine($"Música: {musica.Nome} - Ano de Lançamento: {musica.AnoLancamento}");
        }
    }

    /// <summary>
    /// Returns a string representation of the artist.
    /// </summary>
    /// <returns>A string representation of the artist.</returns>
    public override string ToString()
    {
        return $@"Id: {Id}
            Nome: {Nome}
            Foto de Perfil: {FotoPerfil}
            Bio: {Bio}";
    }
}