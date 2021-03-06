using System;
using System.Collections.Generic;
using System.IO;
using ProjetoEPlayers.Interfaces;

namespace ProjetoEPlayers.Models
{
    public class Equipe : EplayersBase , IEquipe
    {
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }

        private const string PATH = "Database/equipe.csv";

        public Equipe(){
            CreateFolderAndFile(PATH);
        }

        /// <summary>
        /// Cria uma equipe
        /// </summary>
        /// <param name="e">Equipe a ser criada</param>
        public void Create(Equipe e)
        {
            string[] linhas = { PrepararLinha(e) };
            File.AppendAllLines(PATH, linhas);
        }

        /// <summary>
        /// Deleta uma linha do CSV
        /// </summary>
        /// <param name="IdEquipe">Termo que será usado para excluir uma linha do CSV</param>
        public void Delete(int IdEquipe)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == IdEquipe.ToString());
            RewriteCSV(PATH, linhas);
        }

        /// <summary>
        /// Lê as linhas de equipe no CSV
        /// </summary>
        /// <returns>Linhas de equipe do CSV</returns>
        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();
                equipe.IdEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }

        /// <summary>
        /// Atualiza alguma linha do CSV
        /// </summary>
        /// <param name="e">Equipe que será atualizada</param>
        public void Update(Equipe e)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == e.IdEquipe.ToString());
            linhas.Add(PrepararLinha(e));
            RewriteCSV(PATH, linhas);
        }
        
        /// <summary>
        /// Prepara a linha para ir ao CSV
        /// </summary>
        /// <param name="e">Equipe que terá a linha preparada</param>
        /// <returns>Linha preparada para o CSV</returns>
        private string PrepararLinha(Equipe e){
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }
    }
}