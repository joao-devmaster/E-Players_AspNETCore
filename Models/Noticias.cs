using System.Collections.Generic;
using E_Players_AspNETCore.Interface;
using System;
using System.IO;



namespace E_Players_AspNETCore.Models
{
    public class Noticias : EPlayersBase , INoticias
    {
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }
        private const string PATH = "Database/noticia.csv";

           public Noticias()
        {
            CreateFolderAndFile(PATH);
        }

        public void Create(Noticias n)
        {
             string[] linha = { Prepare(n) };
            File.AppendAllLines(PATH, linha);
            
        }

         private string Prepare(Noticias n)
        {
            return $" {n.IdNoticia};{n.Titulo};{n.Texto};{n.Imagem}";
        }


/// <summary>
/// Deletar arquivo usando ID como parametro.
/// </summary>
/// <param name="id"></param>
        public void Delete(int IdNoticia)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
           linhas.RemoveAll(x => x.Split(";")[0] == IdNoticia.ToString());
           RewriteCSV(PATH, linhas);
            
        }

        public List<Noticias> ReadAll()
        {
             List<Noticias> news = new List<Noticias>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Noticias noticia = new Noticias();
                noticia.IdNoticia = Int32.Parse(linha[0]);
                noticia.Titulo = linha[1];
                noticia.Texto = linha[2];
                noticia.Imagem = linha[3];

                news.Add(noticia);
                
            }
            return news;
            
        }

        public void Update(Noticias n)
        {
             List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == n.IdNoticia.ToString());
            linhas.Add(Prepare (n) );
            RewriteCSV(PATH, linhas);
            
        }
    }
}