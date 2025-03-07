using ScreenSound.Bancos;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuRegistrarMusica : Menu
{
    public override void Executar(DAL<Artista> ArtistaDAL)
    {
        base.Executar(ArtistaDAL);
        ExibirTituloDaOpcao("Registro de músicas");
        Console.Write("Digite o artista cuja música deseja registrar: ");
        string nomeDoArtista = Console.ReadLine()!;
        var artistasRegistrados = ArtistaDAL.Buscar(a => a.Nome.Equals(nomeDoArtista));

        if (artistasRegistrados is not null && artistasRegistrados.Any())
        {
            var artista = artistasRegistrados.First();
            Console.Write("Agora digite o título da música: ");
            string tituloDaMusica = Console.ReadLine()!;
            Console.Write("Agora digite o ano de lançamento da musica: ");
            string anoLancamento= Console.ReadLine()!;
            artista.AdicionarMusica(new Musica(tituloDaMusica) { AnoLancamento = Convert.ToInt32(anoLancamento) });
            Console.WriteLine($"A música {tituloDaMusica} de {nomeDoArtista} foi registrada com sucesso!");
            ArtistaDAL.Atualizar(artista);
            Thread.Sleep(4000);
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nO artista {nomeDoArtista} não foi encontrado!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
