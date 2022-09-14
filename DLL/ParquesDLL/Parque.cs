using System;
using System.Collections.Generic;
using System.IO;
using CarroDLL;
using System.Runtime.Serialization.Formatters.Binary;

namespace ParquesDLL
{/// <summary>
///     Estrutura que contém todos os dados de um parque de estacionamento
/// </summary>
    public class Parque
    {
        private static int lugaresLivres;
        private static int lugaresOcupados;
        protected static List<Carro> carro = new List<Carro>();

        public Parque()
        {
            lugaresLivres = 100;
            lugaresOcupados = 0;
        }

        public int LugaresLivres1 { get => lugaresLivres; set => lugaresLivres = value; }
        public int LugaresOcupados { get => lugaresOcupados; set => lugaresOcupados = value; }

        /// <summary>
        /// Função que nos indica se o parque já está ou não cheio
        /// </summary>
        /// <returns>false se o parque estiver cheio</returns>
        /// <returns>true se existerem lugares livres</returns>
        public static bool VerificarLugares()
        {
            if (lugaresOcupados == lugaresLivres)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Método de verificação se um veículo está estacionado ou não
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns></returns>
        public static bool VericarEstacionamento(string matricula)
        {
            Carro c = carro.Find(x => x.Matricula == matricula);

            if (c != null && c.Estacionado == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Estaciona um veículo
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool EstacionarCarro(Carro c)
        {
            lugaresOcupados++;
            carro.Add(c);
            return true;
        }
        /// <summary>
        /// Determina o número de lugares livres
        /// </summary>
        /// <returns></returns>
        public static int LugaresLivres()
        {
            int lugares;

            lugares = lugaresLivres - lugaresOcupados;

            return lugares;
        }
        /// <summary>
        /// Remove um veículo
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns></returns>
        public static bool RemoverCarro(string matricula)
        {
            int index = carro.FindIndex(x => x.Matricula == matricula);
            
            if(index > -1)
            {
                carro[index].Estacionado = 0;
                lugaresOcupados--;
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Lista todos veículos estacionados
        /// </summary>
        /// <returns></returns>
        public static List<Carro> ImprimirCarros()
        {
            List<Carro> auxiliar = new List<Carro>(carro);
            Console.WriteLine(auxiliar);

            return auxiliar;
        }
        /// <summary>
        /// Permite modificar uma matrícula
        /// </summary>
        /// <param name="matricula"></param>
        /// <param name="novaMatricula"></param>
        public static void AlterarMatricula(string matricula, string novaMatricula)
        {
            int index = carro.FindIndex(x => x.Matricula == matricula);

            carro[index].Matricula = novaMatricula;
        }
        /// <summary>
        /// Permite alterar a marca
        /// </summary>
        /// <param name="matricula"></param>
        /// <param name="novaMarca"></param>
        public static void AlterarMarca(string matricula, string novaMarca)
        {
            int index = carro.FindIndex(x => x.Matricula == matricula);

            carro[index].Marca = novaMarca;
        }
        /// <summary>
        /// Permite mudar o número de aluno
        /// </summary>
        /// <param name="matricula"></param>
        /// <param name="novoNumero"></param>
        public static void AlterarNumero(string matricula, int novoNumero)
        {
            int index = carro.FindIndex(x => x.Matricula == matricula);

            carro[index].NumeroAluno = novoNumero;
        }
        /// <summary>
        /// Cria um ficheiro .bin com todos os estacionamentos realizados
        /// </summary>
        public static void FicheiroRegistos()
        {
            using (BinaryWriter binWriter = new BinaryWriter(File.Open("registo.bin", FileMode.Create)))
            {
                foreach (Carro c in carro)
                {
                    binWriter.Write(c.NumeroAluno);
                    binWriter.Write(c.Matricula);
                    binWriter.Write(c.Marca);
                    binWriter.Write(c.Estacionado);
                    binWriter.Write(c.Parque);
                }
            }
        }
        /// <summary>
        /// Verifica se uma matrícula já existe
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns></returns>
        public static int VerificarMatricula(string matricula)
        {
            int contador = 0;

            foreach (Carro c in carro)
            {
                if(c.Matricula == matricula)
                {
                    contador++;
                }
            }

            return contador;
        }
    }
}
