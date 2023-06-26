using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using UsandoBanco.Interfaces;

namespace UsandoBanco
{
    internal class Menu
    {
        private int _CurrentID = 1;
        private List<Produto> _Produtos = new List<Produto>();

        public void ChamarMenu()
        {
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("     Olá Sr. Usuário     ");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=");

            Console.WriteLine("1 - Listar (Read/Select)");
            Console.WriteLine("2 - Adicionar (Create/Insert)");
            Console.WriteLine("3 - Deletar (Delete)");
            Console.WriteLine("4 - Atualizar (Update)");

            switch (Console.ReadLine())
            {
                case "1":
                    List<IMenuItem> produtos = Produto.GetAll();
                    ListarItens(produtos);

                    Console.ReadLine();

                    Console.Clear();
                    ChamarMenu();
                    break;
                case "2":
                    Produto produto = new Produto();
                    produto.Save();

                    Console.WriteLine("Produto adicionado!");

                    Thread.Sleep(3000);

                    Console.Clear();
                    ChamarMenu();
                    break;
                    case"3":
                    Console.Write("Informe o ID que deseja deletar: ");
                    var idDeletar = long.Parse(Console.ReadLine());
                    var produtoDeletar = new Produto(idDeletar);

                    if (produtoDeletar.IsValid())
                    {
                        produtoDeletar.Delete();
                        Console.WriteLine("Produto excluído!");
                    }
                    else
                    {
                        Console.WriteLine($"Não existe produto com o ID {idDeletar}!");
                    }

                    Thread.Sleep(3000);

                    Console.Clear();
                    ChamarMenu();
                    break;
                    case "4":
                    Console.Write("Informe o ID do produto: ");
                    var idUpdate = long.Parse(Console.ReadLine());
                    var produtoUpdate = new Produto(idUpdate);

                    if (produtoUpdate.IsValid()) 
                    {
                        AlterarItem(produtoUpdate);
                    }
                    else
                    {
                        Console.WriteLine($"Não existe produto com o ID {idUpdate}!");
                    }

                    Thread.Sleep(3000);

                    Console.Clear();
                    ChamarMenu();
                    break;
                default:
                    Console.WriteLine("Opção inválida");

                    // Espera 3 segundos
                    Thread.Sleep(3000);

                    Console.Clear();
                    ChamarMenu();
                    break;
            }
        }

        private void AdicionarItem(Produto produto)
        {
            _Produtos.Add(produto);
        }

        private void AlterarItem(Produto produto)
        {
            Console.Clear();
            Console.WriteLine($"Menu de alteração");
            Console.WriteLine($"1 - Nome");
            Console.WriteLine($"2 - Código");
            Console.WriteLine($"3 - Valor");
            Console.WriteLine($"4 - Descrição");
            Console.WriteLine($"'Salvar' para salvar as alterações");

            Console.Write("\nInforme o campo que deseja alterar: ");
            var entrada = Console.ReadLine().ToUpper();

            while (entrada != "SALVAR")
            {
                if (entrada != "1" && entrada != "2" && entrada != "3" && entrada != "4")
                {
                    Console.WriteLine("Campo inválido!");
                }
                else
                {
                    Console.Write("Informe o valor que será aplicado: ");
                    var valor = Console.ReadLine();

                    switch (entrada)
                    {
                        case "1":
                            produto.Nome = valor;
                            break;
                        case "2":
                            produto.Codigo = valor;
                            break;
                        case "3":
                            produto.Valor = decimal.Parse(valor);
                            break;
                        case "4":
                            produto.Descricao = valor;
                            break;
                    }
                }

                Console.Clear();
                Console.WriteLine($"Menu de alteração");
                Console.WriteLine($"1 - Nome");
                Console.WriteLine($"2 - Código");
                Console.WriteLine($"3 - Valor");
                Console.WriteLine($"4 - Descrição");
                Console.WriteLine($"'Salvar' para salvar as alterações");

                Console.Write("\nInforme o campo que deseja alterar: ");
                entrada = Console.ReadLine().ToUpper();
            }

            produto.Update();
        }

        private void DeletarItem(int id)
        {
            _Produtos.RemoveAll(produto => produto.Id == id);
            //foreach(var produto in _Produtos)
            //{
            //    if (produto.Id == id)
            //    {
            //        _Produtos.Remove(produto);
            //    }
            //}
        }

        //private void AcharNome()
        //{
        //    var listaNomes = new List<string>()
        //    {
        //        "Pedro",
        //        "Pedrinho",
        //        "Joãozinho"
        //    };

        //    foreach(var nome in listaNomes)            {
        //        if (nome.StartsWith("P"))
        //        {
        //            Console.WriteLine($"O nome {nome} começa com P!");
        //        }
        //    }

        //    var nomesComJ = listaNomes.Where(nome => nome.StartsWith("J"));
        //}

        private void ListarItens(List<IMenuItem> items)
        {
            Console.Clear();

            if (!items.Any())
            {
                Console.WriteLine("Sem itens para exibir!");
            }

            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}