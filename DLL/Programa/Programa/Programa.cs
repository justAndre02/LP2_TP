using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intermedio;
using CarroDLL;

namespace Programa
{
    class Programa
    {
        static void Main()
        {
            Inter.Benfica();
            Menu();
        }
        /// <summary>
        /// O menu principal aonde o utilizador decide o que fazer no programa
        /// </summary>
        static void Menu()
        {
            int opcao = -1;

            do
            {
                Console.Clear();

                Console.WriteLine("==== IPCA ====");

                Console.WriteLine("\n1 - Estacionar carro.");
                Console.WriteLine("2 - Verificar lugares livres.");
                Console.WriteLine("3 - Remover estacionamento.");
                Console.WriteLine("4 - Imprimir estacionamentos.");
                Console.WriteLine("5 - Imprimir ficheiro com histórico do parque.");
                Console.WriteLine("6 - Alterar dados do carro.");
                Console.WriteLine("0 - Sair.");
                Console.Write("\n\nIntroduza uma opção: ");

                string aux;
                do
                {
                    aux = Console.ReadLine();
                } while (!int.TryParse(aux, out opcao));

                switch (opcao)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        Decisao1();
                        Menu();
                        break;
                    case 2:
                        Decisao2();
                        Menu();
                        break;
                    case 3:
                        Decisao3();
                        Menu();
                        break;
                    case 4:
                        Decisao4();
                        Menu();
                        break;
                    case 5:
                        Decisao5();
                        Menu();
                        break;
                    case 6:
                        Decisao6();
                        Menu();
                        break;
                    default:
                        opcao = -1;
                        break;
                }

            } while (opcao == -1);
        }
        /// <summary>
        /// O método que permite o utilizador estacionar qualquer tipo de veículo com matrícula
        /// </summary>
        static void Decisao1()
        {
            Console.Clear();
            bool aux = Inter.Lugares();

            if(aux == false)
            {
                Console.WriteLine("Parque atualmente cheio!");
                Console.ReadKey();
                Menu();
            }

            Console.Write("Insira a matrícula do carro: ");
            string matricula = Console.ReadLine();

            aux = Inter.Estacionamento(matricula);

            if(aux == true)
            {
                Console.Write("Insira a marca do carro: ");
                string marca = Console.ReadLine();
                Console.Write("Insira o numero do aluno: ");
                int numero;
                string aux2;
                do
                {
                    aux2 = Console.ReadLine();
                } while (!int.TryParse(aux2, out numero));
                bool inserir = Inter.Estacionar(new Carro(matricula, marca, "IPCA", numero, 1));
                if (inserir == true)
                {
                    Console.WriteLine("Carro estacionado com sucesso!");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Carro já se encontra estacionado!");
            }
        }
        /// <summary>
        /// A função que determina quantos lugares ainda se encontram disponíveis
        /// </summary>
        static void Decisao2()
        {
            Console.Clear();
            int lugares = Inter.Livres();

            Console.WriteLine("Número de lugares livres: {0}", lugares);
            Console.ReadKey();
        }
        /// <summary>
        /// Função que deixa escolher um carro e removê-lo de seguida
        /// </summary>
        static void Decisao3()
        {
            Console.Clear();
            Console.Write("Insira a matrícula do carro: ");
            string matricula = Console.ReadLine();

            bool aux = Inter.Remover(matricula);

            if (aux == true)
            {
                Console.WriteLine("Carro removido com sucesso!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Carro não encontrado!");
                Console.ReadKey();
            }

        }
        /// <summary>
        /// Método que lista todos os veículos estacionados anteriormente
        /// </summary>
        static void Decisao4()
        {
            Console.Clear();
            List<Carro> aux = Inter.Imprime();

            foreach (Carro x in aux)
            {
                Console.WriteLine("{0} | {1} | {2} | {3} | {4} |", x.NumeroAluno, x.Matricula, x.Marca, x.Parque, x.Estacionado);
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Criação de um ficheiro binério com a mesma listagem da função acima
        /// </summary>
        static void Decisao5()
        {
            Console.Clear();
            Inter.Ficheiro();
            Console.WriteLine("Ficheiro criado com sucesso!");
            Console.ReadKey();
        }
        /// <summary>
        /// Função que permite mudar os dados de um veículo sejam eles matrícula, marca ou número de aluno
        /// </summary>
        static void Decisao6()
        {
            Console.Clear();
            Console.WriteLine("Insira a matrícula do carro que deseja alterar: ");
            string matricula = Console.ReadLine();

            int contador = Inter.Matricula(matricula);

            if(contador != 0)
            {
                Console.Clear();
                Console.WriteLine("Qual dos dados deseja alterar:");
                Console.WriteLine("1 - Matrícula.");
                Console.WriteLine("2 - Marca.");
                Console.WriteLine("3 - Número de aluno.");
                Console.Write("Insira uma opção: ");
                int opcao;
                string aux;
                do
                {
                    aux = Console.ReadLine();
                } while (!int.TryParse(aux, out opcao));

                Console.Clear();
                switch (opcao)
                {
                    case 1:
                        Console.Write("Insira a nova matrícula: ");
                        string novaMatricula = Console.ReadLine();
                        Inter.AlterarMT(matricula, novaMatricula);
                        Console.WriteLine("Dados alterados com sucesso!");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Write("Insira a nova marca: ");
                        string novaMarca = Console.ReadLine();
                        Inter.AlterarM(matricula, novaMarca);
                        Console.WriteLine("Dados alterados com sucesso!");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Write("Insira o novo número: ");
                        int novoNumero;
                        do
                        {
                            aux = Console.ReadLine();
                        } while (!int.TryParse(aux, out novoNumero));
                        Inter.AlterarN(matricula, novoNumero);
                        Console.WriteLine("Dados alterados com sucesso!");
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                Console.WriteLine("O carro não se encontra no sistema!");
            }
        }
    }
}
