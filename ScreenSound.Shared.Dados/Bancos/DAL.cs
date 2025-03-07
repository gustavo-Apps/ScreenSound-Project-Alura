using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Bancos
{
    /// <summary>
    /// Data Access Layer (DAL) class for performing CRUD operations on the database.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public class DAL<T> where T : class
    {
        private readonly ScreenSoundContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DAL{T}"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public DAL(ScreenSoundContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Lists all entities of type <typeparamref name="T"/>.
        /// </summary>
        /// <returns>An enumerable collection of entities.</returns>
        public IEnumerable<T> Listar()
        {
            return context.Set<T>().ToList();
        }

        /// <summary>
        /// Adds a new entity to the database.
        /// </summary>
        /// <param name="objeto">The entity to add.</param>
        public void Adicionar(T objeto)
        {
            context.Set<T>().Add(objeto);
            context.SaveChanges();
        }

        /// <summary>
        /// Updates an existing entity in the database.
        /// </summary>
        /// <param name="objeto">The entity to update.</param>
        public void Atualizar(T objeto)
        {
            context.Set<T>().Update(objeto);
            context.SaveChanges();
        }

        /// <summary>
        /// Deletes an entity from the database.
        /// </summary>
        /// <param name="objeto">The entity to delete.</param>
        public void Deletar(T objeto)
        {
            context.Set<T>().Remove(objeto);
            context.SaveChanges();
        }

        /// <summary>
        /// Searches for entities that match the specified condition.
        /// </summary>
        /// <param name="condicao">The condition to match.</param>
        /// <returns>An enumerable collection of matching entities.</returns>
        public IEnumerable<T> Buscar(Func<T, bool> condicao)
        {
            return context.Set<T>().Where(condicao).ToList();
        }

        /// <summary>
        /// Lists entities that match the specified condition.
        /// </summary>
        /// <param name="condicao">The condition to match.</param>
        /// <returns>An enumerable collection of matching entities.</returns>
        public IEnumerable<T> ListarPor(Func<T, bool> condicao)
        {
            return context.Set<T>().Where(condicao);
        }
    }
}