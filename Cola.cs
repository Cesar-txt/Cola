using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cola
{
    internal class Cola
    {
        private int[] elementos;
        private int frente;
        private int final;
        private int contador;
        private int max;


        public Cola(int tamaño)
        {
            max = tamaño;
            elementos = new int[max];
            frente = 0;
            final = -1;
            contador = 0;
        }

        public bool Enqueue(int dato)
        {
            if (contador < max)
            {
                final = (final + 1) % max;
                elementos[final] = dato;
                contador++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Dequeue()
        {
            if (contador > 0)
            {
                int elemento = elementos[frente];
                frente = (frente + 1) % max;
                contador--;
                return elemento;
            }
            else
            {
                return -1;
            }
        }

        public int Peek()
        {
            return (contador > 0) ? elementos[frente] : -1;
        }

        public bool EstaVacia()
        {
            return contador == 0;
        }

        public bool EstaLlena()
        {
            return contador == max;
        }

        public int Tamaño()
        {
            return contador;
        }

        public int ObtenerFrente()
        {
            return frente;
        }

        public int ObtenerMax()
        {
            return max;
        }

        public int ObtenerElemento(int indice)
        {
            return elementos[indice];
        }

        public string MostrarCola()
        {
            if (EstaVacia())
                return "Cola vacía";

            string resultado = "Cola: [";
            for (int i = 0; i < contador; i++)
            {
                int indice = (frente + i) % max;
                resultado += elementos[indice];
                if (i < contador - 1)
                    resultado += ", ";
            }
            resultado += "]";
            return resultado;
        }
    }
}
