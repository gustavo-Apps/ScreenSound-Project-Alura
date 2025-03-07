using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Shared.Modelos.Modelos
{
    class Genero
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        public string? Descricao { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"Nome: {Nome} - Descrição: {Descricao}";
        }

    }
}
