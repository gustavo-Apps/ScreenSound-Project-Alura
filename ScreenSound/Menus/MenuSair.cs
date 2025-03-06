using ScreenSound.Bancos;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuSair : Menu
{
    public override void Executar(DAL<Artista> ArtistaDAL)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}
