using System;
using System.Collections.Generic;
using System.IO;
using ProjetoEPlayers.Interfaces;

namespace ProjetoEPlayers.Models
{
    public class Noticias : EplayersBase , INoticias
    {
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }

        private const string PATH = "Database/noticias.csv";

        public Noticias(){
            CreateFolderAndFile(PATH);
        }

        /// <summary>
        /// Cria uma notícia
        /// </summary>
        /// <param name="n">Noticia a ser criada</param>
        public void Create(Noticias n)
        {
            string[] linhas = { PrepararLinha(n) };
            File.AppendAllLines(PATH, linhas);
        }

        /// <summary>
        /// Deleta uma linha do CSV
        /// </summary>
        /// <param name="IdNoticias">Termo que será usado para excluir uma linha do CSV</param>
        public void Delete(int IdNoticias)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == IdNoticias.ToString());
            RewriteCSV(PATH, linhas);
        }

        /// <summary>
        /// Lê as linhas de notícia do CSV
        /// </summary>
        /// <returns>Linhas de notícia do CSV</returns>
        public List<Noticias> ReadAll()
        {
            List<Noticias> noticia = new List<Noticias>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Noticias noticias = new Noticias();
                noticias.IdNoticia = Int32.Parse(linha[0]);
                noticias.Titulo = linha[1];
                noticias.Texto = linha[2];
                noticias.Imagem = linha[3];

                noticia.Add(noticias);
            }
            return noticia;
        }

        /// <summary>
        /// Atualiza alguma linha do CSV
        /// </summary>
        /// <param name="n">Noticia que será atualizada</param>
        public void Update(Noticias n)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == n.IdNoticia.ToString());
            linhas.Add(PrepararLinha(n));
            RewriteCSV(PATH, linhas);
        }

        /// <summary>
        /// Prepara a linha para ir ao CSV
        /// </summary>
        /// <param name="n">Noticia que terá a linha preparada</param>
        /// <returns>Linha preparada para o CSV</returns>
        private string PrepararLinha(Noticias n){
            return $"{n.IdNoticia};{n.Titulo};{n.Texto};{n.Imagem}";
        }
    }
}