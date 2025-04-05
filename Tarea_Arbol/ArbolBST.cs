using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_Arbol
{
    public class ArbolBST
    {
        private NodoBST raiz;

        public ArbolBST()
        {
            raiz = null;
        }

        
        public void Insertar(int valor)
        {
            raiz = InsertarNodo(raiz, valor);
        }

        
        private NodoBST InsertarNodo(NodoBST nodo, int valor)
        {
            
            if (nodo == null)
                return new NodoBST(valor);

            
            int resultadoComparacion = valor.CompareTo(nodo.Valor);

            
            if (resultadoComparacion < 0)
                nodo.Izquierdo = InsertarNodo(nodo.Izquierdo, valor);
            else if (resultadoComparacion > 0)
                nodo.Derecho = InsertarNodo(nodo.Derecho, valor);
            

            return nodo;
        }

        
        public bool Contiene(int valor)
        {
            return BuscarNodo(raiz, valor);
        }

        
        private bool BuscarNodo(NodoBST nodo, int valor)
        {
            
            if (nodo == null)
                return false;

            
            int resultadoComparacion = valor.CompareTo(nodo.Valor);

           
            if (resultadoComparacion == 0)
                return true;
            
            else if (resultadoComparacion < 0)
                return BuscarNodo(nodo.Izquierdo, valor);
            
            else
                return BuscarNodo(nodo.Derecho, valor);
        }

        
        public int EncontrarMinimo()
        {
            if (raiz == null)
                throw new InvalidOperationException("El árbol está vacío");

            NodoBST nodoMinimo = EncontrarNodoMinimo(raiz);
            return nodoMinimo.Valor;
        }

        
        private NodoBST EncontrarNodoMinimo(NodoBST nodo)
        {
            
            NodoBST actual = nodo;
            while (actual.Izquierdo != null)
                actual = actual.Izquierdo;

            return actual;
        }

        public int EncontrarMaximo()
        {
            if (raiz == null)
                throw new InvalidOperationException("El árbol está vacío");

            NodoBST nodoMaximo = EncontrarNodoMaximo(raiz);
            return nodoMaximo.Valor;
        }

        
        private NodoBST EncontrarNodoMaximo(NodoBST nodo)
        {
            
            NodoBST actual = nodo;
            while (actual.Derecho != null)
                actual = actual.Derecho;

            return actual;
        }

        
        public void Eliminar(int valor)
        {
            raiz = EliminarNodo(raiz, valor);
        }

        
        private NodoBST EliminarNodo(NodoBST nodo, int valor)
        {
            
            if (nodo == null)
                return null;

            
            int resultadoComparacion = valor.CompareTo(nodo.Valor);

            
            if (resultadoComparacion < 0)
            {
                nodo.Izquierdo = EliminarNodo(nodo.Izquierdo, valor);
            }
            
            else if (resultadoComparacion > 0)
            {
                nodo.Derecho = EliminarNodo(nodo.Derecho, valor);
            }
            
            else
            {
                
                if (nodo.Izquierdo == null && nodo.Derecho == null)
                    return null;

                
                if (nodo.Izquierdo == null)
                    return nodo.Derecho;
                if (nodo.Derecho == null)
                    return nodo.Izquierdo;

                
                nodo.Valor = EncontrarNodoMinimo(nodo.Derecho).Valor;

               
                nodo.Derecho = EliminarNodo(nodo.Derecho, nodo.Valor);
            }

            return nodo;
        }

       
        public int ObtenerAltura()
        {
            return CalcularAltura(raiz);
        }

        private int CalcularAltura(NodoBST nodo)
        {
            if (nodo == null)
                return 0;

            int alturaIzquierda = CalcularAltura(nodo.Izquierdo);
            int alturaDerecha = CalcularAltura(nodo.Derecho);

            return Math.Max(alturaIzquierda, alturaDerecha) + 1;
        }

        
       
    }
}
