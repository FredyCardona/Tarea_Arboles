using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_Arbol
{
    public class NodoBST
    {
        public int Valor { get; set; }
        public NodoBST Izquierdo { get; set; }
        public NodoBST Derecho { get; set; }

        public NodoBST(int valor)
        {
            Valor = valor;
            Izquierdo = null;
            Derecho = null;
        }
    }
}
