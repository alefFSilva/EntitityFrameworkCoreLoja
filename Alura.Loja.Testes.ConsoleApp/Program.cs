using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // GravarUsandoAdoNet();
            RecuperandoProdutos();
            ExcluirProdutos();
            RecuperandoProdutos();
        }

        private static void ExcluirProdutos()
        {
            using(var context = new LojaContext())
            {
                List<Produto> produtos = context.Produtos.ToList();
                
                foreach(Produto p in produtos)
                {
                    context.Remove(p);
                }

                context.SaveChanges();

            }
        }

        private static void RecuperandoProdutos()
        {
            using ( var context = new LojaContext())
            {
                List<Produto> produtos = context.Produtos.ToList();

                Console.WriteLine("Foram encontrados {0} produtos", produtos.Count());
                foreach(Produto p in produtos)
                {
                    Console.WriteLine(p.Nome);

                }

                Console.ReadKey();

            }

        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "A batalha do Apocalypse.";
            p.Categoria = "Livros";
            p.Preco = 34.90;

            //using (var repo = new ProdutoDAO())
            //{
            //    repo.Adicionar(p);
            //}

            using (var context = new LojaContext())
            {
                context.Add(p);
                context.SaveChanges();

            }

        }
    }
}
