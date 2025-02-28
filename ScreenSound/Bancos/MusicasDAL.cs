﻿using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//DAO - Data Access Object
//DAL - Data Access Layer

namespace ScreenSound.Bancos
{
    internal class MusicaDAL
    {
        private readonly ScreenSoundContext context;

        public MusicaDAL(ScreenSoundContext context)
        {
            this.context = context;
        }

        public IEnumerable<Musica> Listar()
        {

            return context.Musicas.ToList();

        }

        public void Adicionar(Musica musica)
        {
            context.Musicas.Add(musica);
            context.SaveChanges();

        }

        public void Atualizar(Musica musica)
        {
            context.Musicas.Update(musica);
            context.SaveChanges();

        }

        public void Deletar(Musica musica)
        {
            context.Musicas.Remove(musica);
            context.SaveChanges();

        }

        public Musica? RecuperarPeloNome(string nome)
        {
            return context.Musicas.FirstOrDefault(a => a.Nome.Equals(nome));

        }
    }
}