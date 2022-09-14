using System;
using System.Collections.Generic;
using ParquesDLL;
using CarroDLL;

namespace Intermedio
{
    public class Inter
    {
        public static void Benfica()
        {
            Parque A = new Parque();
        }

        public static bool Lugares()
        {
            return Parque.VerificarLugares();
        }

        public static bool Estacionamento(string matricula)
        {
            return Parque.VericarEstacionamento(matricula);
        }

        public static bool Estacionar(Carro c)
        {
            return Parque.EstacionarCarro(c);
        }

        public static int Livres()
        {
            int x = Parque.LugaresLivres();

            return x;
        }

        public static bool Remover(string matricula)
        {
            return Parque.RemoverCarro(matricula);
        }

        public static List<Carro> Imprime()
        {
            return Parque.ImprimirCarros();
        }

        public static void AlterarMT(string matricula, string novaMatricula)
        {
            Parque.AlterarMatricula(matricula, novaMatricula);
        }

        public static void AlterarM(string matricula, string novaMarca)
        {
            Parque.AlterarMarca(matricula, novaMarca);
        }

        public static void AlterarN(string matricula, int novoNumero)
        {
            Parque.AlterarNumero(matricula, novoNumero);
        }

        public static void Ficheiro()
        {
            Parque.FicheiroRegistos();
        }

        public static int Matricula(string matricula)
        {
            return Parque.VerificarMatricula(matricula);
        }
    }

}
