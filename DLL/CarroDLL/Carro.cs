using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarroDLL
{/// <summary>
/// Estrutura que contém todos os dados de um veículo
/// </summary>
    public class Carro
    {
        private string matricula;
        private string marca;
        private string parque;
        private int numeroAluno;
        private int estacionado;

        public Carro(string matricula, string marca, string parque, int numeroAluno, int estacionado)
        {
            this.matricula = matricula;
            this.marca = marca;
            this.parque = parque;
            this.numeroAluno = numeroAluno;
            this.estacionado = estacionado;
        }

        public string Matricula { get => matricula; set => matricula = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Parque { get => parque; set => parque = value; }
        public int NumeroAluno { get => numeroAluno; set => numeroAluno = value; }
        public int Estacionado { get => estacionado; set => estacionado = value; }
    }
}
