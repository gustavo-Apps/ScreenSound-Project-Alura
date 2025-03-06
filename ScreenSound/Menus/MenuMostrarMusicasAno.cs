using ScreenSound.Bancos;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Menus;
internal class MenuMostrarMusicasAno : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Músicas por ano de lançamento");
        Console.Write("Digite o ano de lançamento da música: ");
        string anoLancamento = Console.ReadLine()!;
        var musicaDAL = new DAL<Musica>(new ScreenSoundContext());
        var musicaAno = musicaDAL.ListarPor(a => a.AnoLancamento == Convert.ToInt32(anoLancamento));

        if (musicaAno != null && musicaAno.Any())
        {
            Console.WriteLine($"\nMusicas referentes ao ano de: {anoLancamento}");
            foreach (var musica in musicaAno)
            {
                musica.ExibirFichaTecnica();
            }
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nNenhuma música para o ano de {anoLancamento}!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}