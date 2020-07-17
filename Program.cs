using System;
using System.Collections.Generic;

namespace _27_28_29_30_DadosExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p = new Produto();
            p.Codigo = 1;
            p.Nome ="SPcolors";
            p.Preco = 10f;

            p.Cadastrar(p);
            p.Remover("SPcolors");

            Produto alterado = new Produto();
            alterado.Codigo =2;
            alterado.Nome = "Ruby";
            alterado.Preco = 25f;

            p.Alterar(alterado);

            List<Produto> lista = p.Ler();
            
            foreach (Produto item in lista)
            {

                Console.ForegroundColor = ConsoleColor.Blue; 
                Console.WriteLine($"RS{item.Preco} \t {item.Nome}"); 
                Console.ResetColor();
            }
        }
        
    }
}
