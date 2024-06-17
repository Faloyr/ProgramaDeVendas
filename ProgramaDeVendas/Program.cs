using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaDeVendas
{
    internal class Program
    {


        static int i = 0, id = 1, fim = 5, vendas = 0, idsell;
        static string[,] cadastrop = new string[4, 10];
        static string[] employee = { "Gabriel", "Luis" };
        static int[,] sells = new int[3, 40];
        static double[,] tips = new double[4, 40];
        static string empsell;


        static void Main(string[] args)

        {
            Program.Menu();

            while (fim != 0)
            {

                switch (fim)
                {
                    case 1:
                        Program.RCadastro();
                        break;
                    case 2:
                        Program.Vendas();
                        break;
                    case 3:
                        Program.pvendedores();
                        break;
                    case 4:
                        Program.relatorio();
                        break;
                }
                Program.Menu();


            }



        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("     Bem vindo ao menu");
            Console.WriteLine("========================================");
            Console.WriteLine("1 - Cadastrar produtos ");
            Console.WriteLine("2 - Realizar uma venda ");
            Console.WriteLine("3 - Relatorio de vendas ");
            Console.WriteLine("4 - Relatorio de vendas por funcionarios ");
            Console.WriteLine("0 - Sair ");
            Console.WriteLine("========================================");
            Console.WriteLine("Selecione uma opcao: ");
            fim = int.Parse(Console.ReadLine());

        }
        static void RCadastro()
        {
            Console.Clear();
            string endregister = "";



            while (endregister != "0")
            {
                string convID = id.ToString();
                Console.WriteLine("Me diga o nome do produto");
                if (cadastrop[1, i] == null)
                {
                    cadastrop[1, i] = Console.ReadLine();

                }

                Console.WriteLine("Qual o valor do produto? ");
                if (cadastrop[2, i] == null)
                {
                    cadastrop[2, i] = Console.ReadLine();
                }

                Console.WriteLine("Quantos produtos ha disponivel? ");
                if (cadastrop[3, i] == null)
                {
                    cadastrop[3, i] = Console.ReadLine();
                }
                if (cadastrop[0, i] == null)
                {
                    cadastrop[0, i] = convID;
                }
                Console.Clear();

                Console.WriteLine("   Ultimo Produto Cadastrado ");
                Console.WriteLine($"id = {cadastrop[0, i]}  Produto = {cadastrop[1, i]}  Valor = R${cadastrop[2, i]}  Quantidade = {cadastrop[3, i]}");

                i++; id++;
                Console.WriteLine("Caso queira cadastrar outro digite 1 \nCaso Queria Sair digite 0");
                endregister = Console.ReadLine();
                Console.Clear();


            }

        }
        static void Vendas()
        {
            int line = 0;
            //Line == Y       C == Columns  X  id
            //sell == product id that will be purchase   buyn == number of products that will be purchase

            int c = 0;
            Console.Clear();
            Console.WriteLine("Quem e o vendedor? 1 - Gabriel 2 - Luis");
            empsell = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine("               Produtos Cadastrados   ");
            for (; line != i; line++)
            {
                if (cadastrop[3, c] == "0")
                {
                    cadastrop[3, c] = "Fora de estoque ";
                    Console.WriteLine($"id = {cadastrop[0, c]}  Produto = {cadastrop[1, c]}  Valor = R${cadastrop[2, c]}  Quantidade = {cadastrop[3, c]}");

                    c++;
                }
                else
                {
                    Console.WriteLine($"id = {cadastrop[0, c]}  Produto = {cadastrop[1, c]}  Valor = R${cadastrop[2, c]}  Quantidade = {cadastrop[3, c]}");

                    c++;

                }
            }
            Console.WriteLine("================================================");


            if (empsell == "1")
            {
                sells[1, vendas] = 1;
                Console.WriteLine($"Bem vindo {employee[0]}");

            }
            else if (empsell == "2")
            {
                sells[1, vendas] = 2;
                Console.WriteLine($"Bem vindo {employee[1]}");

            }

            Console.WriteLine("Digite o ID do produto que voce deseja vender\n 0 para voltar ao menu");
            idsell = int.Parse(Console.ReadLine());
            if (idsell != 0)
            {

                string lei = "";
                sells[0, vendas] = idsell; //quantidade                  

                if (cadastrop[3, idsell - 1] == null)
                {

                    cadastrop[3, idsell - 1] = cadastrop[3, idsell];

                }

                Console.WriteLine($" Temos {cadastrop[3, idsell - 1]} quantos serao vendidas? ");
                lei = Console.ReadLine();



                sells[2, vendas] = int.Parse(lei);
                int convertbuy = int.Parse(cadastrop[3, idsell - 1]);

                if (cadastrop[2, vendas] == null)
                {

                    cadastrop[2, vendas] = cadastrop[2, vendas - 1];

                }

                tips[3, vendas] = (double.Parse(cadastrop[2, vendas])) * 0.10 * sells[2, vendas];




                if (sells[2, vendas] > convertbuy)
                {
                    Console.WriteLine("Esta quantidade excede nosso estoque tente outro valor ");

                }
                else
                {
                    Console.WriteLine($"Foram vendidas {sells[2, vendas]} {cadastrop[1, idsell - 1]} agora restao {convertbuy - sells[2, vendas]}");
                    cadastrop[3, idsell - 1] = (convertbuy - sells[2, vendas]).ToString();
                    vendas++;
                }


                Console.ReadKey();


            }
        }
        static void pvendedores()
        {
            int line = 0;
            int c = 0;
            Console.Clear();

            Console.WriteLine("Aqui esta as ultimas vendas da loja: ");
            Console.WriteLine("=======================================");
            for (; line != vendas; line++)
            {
                Console.WriteLine($"idProduto = {sells[0, c]}  CodFuncionario = {sells[1, c]}  Quantidade = {sells[2, c]} ");
                c++;
            }
            Console.WriteLine("=======================================");
            Console.ReadKey();

        }
        static void relatorio()
        {
            int line = 0;
            int c = 0;
            double soma1 = 0, soma2 = 0;


            Console.Clear();
            Console.WriteLine("   Aqui esta o relatorio da loja: ");
            Console.WriteLine("=======================================");
            for (; line != vendas; line++)
            {
                tips[0, c] = sells[2, c];
                tips[1, c] = sells[0, c];
                tips[2, c] = sells[1, c];

                Console.WriteLine($"Vendas = {tips[0, c]} CodProduto = {tips[1, c]}  CodFuncionario = {tips[2, c]} porcentagem por venda = R${tips[3, c]} ");
                if (tips[2, c] == 1)
                {

                    soma1 += tips[3, c];

                }
                else
                {
                    soma2 += tips[3, c];
                }
                c++;
            }
            Console.WriteLine("ID 1 = Gabriel ID 2 = Luis");
            Console.WriteLine($"{employee[0]} recebera R${soma1} de comissao");
            Console.WriteLine($"{employee[1]} recebera R${soma2} de comissao");

            Console.WriteLine("=======================================");
            Console.ReadKey();

        }
    }
}
