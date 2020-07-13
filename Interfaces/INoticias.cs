using System.Collections.Generic;
using ProjetoEPlayers.Models;

namespace ProjetoEPlayers.Interfaces
{
    public interface INoticias
    {
        /// <summary>
        /// Cria uma notícia
        /// </summary>
        /// <param name="n">Noticia a ser criada</param>
        void Create(Noticias n);

        /// <summary>
        /// Lê as linhas de notícia do CSV
        /// </summary>
        /// <returns>Linhas de notícia do CSV</returns>
        List<Noticias> ReadAll();

        /// <summary>
        /// Atualiza alguma linha do CSV
        /// </summary>
        /// <param name="n">Noticia que será atualizada</param>
        void Update(Noticias n);

        /// <summary>
        /// Deleta uma linha do CSV
        /// </summary>
        /// <param name="IdNoticias">Termo que será usado para excluir uma linha do CSV</param>
        void Delete(int IdNoticias);

    }
}