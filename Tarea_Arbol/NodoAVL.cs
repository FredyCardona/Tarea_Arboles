using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_Arbol
{
    public class NodoAVL
    {
        public int Valor { get; set; }
        public NodoAVL Izquierdo { get; set; }
        public NodoAVL Derecho { get; set; }
        public int Altura { get; set; }

        public NodoAVL(int valor)
        {
            Izquierdo = null;
            Derecho = null;
            Valor = valor;
            Altura = 1;
        }
    }
}
