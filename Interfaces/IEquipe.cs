using System.Collections.Generic;
using ProjetoEPlayers.Models;

namespace ProjetoEPlayers.Interfaces
{
    public interface IEquipe
    {
        /// <summary>
        /// Cria uma equipe
        /// </summary>
        /// <param name="e">Equipe a ser criada</param>
        void Create(Equipe e);

        /// <summary>
        /// Lê as linhas de equipe no CSV
        /// </summary>
        /// <returns>Linhas de equipe do CSV</returns>
        List<Equipe> ReadAll();

        /// <summary>
        /// Atualiza alguma linha do CSV
        /// </summary>
        /// <param name="e">Equipe que será atualizada</param>
        void Update(Equipe e);

        /// <summary>
        /// Deleta uma linha do CSV
        /// </summary>
        /// <param name="IdEquipe">Termo que será usado para excluir uma linha do CSV</param>
        void Delete(int IdEquipe);
    }
}