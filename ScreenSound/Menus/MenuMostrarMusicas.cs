using ScreenSound.Bancos;
using ScreenSound.Modelos;
using System.Data;

namespace ScreenSound.Menus;

internal class MenuMostrarMusicas : Menu
{
    public override void Executar(ArtistaDAL ArtistaDAL)
    {
        base.Executar(ArtistaDAL);
        ExibirTituloDaOpcao("Exibir detalhes do artista");
        Console.Write("Digite o nome do artista que deseja conhecer melhor: ");
        string nomeDoArtista = Console.ReadLine()!;
        var artistasRegistrados = ArtistaDAL.Buscar(nomeDoArtista);
        if (artistasRegistrados is not null && artistasRegistrados.Any())
        {
            Console.WriteLine("\nDiscografia:");
            foreach (var artista in artistasRegistrados)
            {
                artista.ExibirDiscografia();
            }
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
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
