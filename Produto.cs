
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _27_28_29_30_DadosExcel
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }

        private const string PATH = "Database/produto.csv";

        public Produto()
        {
            //........desafio..............................
            string pasta = PATH.Split('/')[0];

            if(!Directory.Exists(pasta)){
                Directory.CreateDirectory(pasta);
            }
            
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }
        //...........desafio...............................
        public void Cadastrar(Produto prod)
        {
            var linha = new string[] { PrepararLinha(prod) };
            File.AppendAllLines(PATH, linha);
        }

        public List<Produto> Ler()
        {
            List<Produto> produtos = new List<Produto>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach(string linha in linhas){


                string[] dado = linha.Split(";");

                Produto produto   = new Produto();
                
                produto.Codigo    = Int32.Parse( Separar(dado[0]) );
                produto.Nome      = Separar(dado[1]);
                produto.Preco     = float.Parse( Separar(dado[2]) );

                produtos.Add(produto);
            }

            produtos = produtos.OrderBy(y => y.Nome).ToList();
            return produtos; 
        }
        public void Remover(string _termo){

            List<string> linhas = new List<string>();


            using(StreamReader arquivo = new StreamReader(PATH))
            {
                string linha;
                while((linha = arquivo.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }

            linhas.RemoveAll(l => l.Contains(_termo));

            ReescreverCSV(linhas);
        }
        
        public void Alterar(Produto _produtoAlterado){

            List<string> linhas = new List<string>();


            using(StreamReader arquivo = new StreamReader(PATH))
            {
                string linha;
                while((linha = arquivo.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            };
            

            linhas.RemoveAll(z => z.Split(";")[0].Split("=")[1] == _produtoAlterado.Codigo.ToString());
            linhas.Add( PrepararLinha(_produtoAlterado) );


            ReescreverCSV(linhas);         
        }


        private void ReescreverCSV(List<string> lines){
      
            using(StreamWriter output = new StreamWriter(PATH))
            {
                foreach(string ln in lines)
                {
                    output.Write(ln + "\n");
                }
            }   
        }

        public List<Produto> Filtrar(string _nome)
        {
            return Ler().FindAll(x => x.Nome == _nome);
        }

        private string Separar(string _coluna)
        {
            return _coluna.Split("=")[1];
        }

        private string PrepararLinha(Produto p)
        {
            return $"codigo={p.Codigo};nome={p.Nome};preco={p.Preco}";
        }

    }
}