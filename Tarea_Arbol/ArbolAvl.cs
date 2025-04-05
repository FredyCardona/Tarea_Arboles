using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tarea_Arbol
{
    public class ArbolAvl
    {
        private NodoAVL raiz;

       
        private int ObtenerAltura(NodoAVL nodo)
        {
            return nodo == null ? 0 : nodo.Altura;
        }

        public int ObtenerAltura()
        {
            return ObtenerAltura(raiz);
        }


        private int ObtenerFactorBalance(NodoAVL nodo)
        {
            if (nodo == null)
                return 0;
            return ObtenerAltura(nodo.Izquierdo) - ObtenerAltura(nodo.Derecho);
        }

        
        private void ActualizarAltura(NodoAVL nodo)
        {
            if (nodo != null)
            {
                nodo.Altura = Math.Max(ObtenerAltura(nodo.Izquierdo), ObtenerAltura(nodo.Derecho)) + 1;
            }
        }

        
        private NodoAVL RotarDerecha(NodoAVL y)
        {
            NodoAVL x = y.Izquierdo;
            NodoAVL z = x.Derecho;

            
            x.Derecho = y;
            y.Izquierdo = z;

            
            ActualizarAltura(y);
            ActualizarAltura(x);

            return x;
        }

        
        private NodoAVL RotarIzquierda(NodoAVL x)
        {
            NodoAVL y = x.Derecho;
            NodoAVL z = y.Izquierdo;

            
            y.Izquierdo = x;
            x.Derecho = z;

            
            ActualizarAltura(x);
            ActualizarAltura(y);

            return y;
        }

        
        private NodoAVL Balancear(NodoAVL nodo)
        {
            if (nodo == null)
                return null;

            ActualizarAltura(nodo);

            int factorBalance = ObtenerFactorBalance(nodo);

            
            if (factorBalance > 1 && ObtenerFactorBalance(nodo.Izquierdo) >= 0)
                return RotarDerecha(nodo);

            
            if (factorBalance < -1 && ObtenerFactorBalance(nodo.Derecho) <= 0)
                return RotarIzquierda(nodo);

            
            if (factorBalance > 1 && ObtenerFactorBalance(nodo.Izquierdo) < 0)
            {
                nodo.Izquierdo = RotarIzquierda(nodo.Izquierdo);
                return RotarDerecha(nodo);
            }

            
            if (factorBalance < -1 && ObtenerFactorBalance(nodo.Derecho) > 0)
            {
                nodo.Derecho = RotarDerecha(nodo.Derecho);
                return RotarIzquierda(nodo);
            }

            return nodo;
        }

        
        public void Insertar(int valor)
        {
            raiz = InsertarNodo(raiz, valor);
        }

        
        private NodoAVL InsertarNodo(NodoAVL nodo, int valor)
        {
            
            if (nodo == null)
                return new NodoAVL(valor);

            int resultadoComparacion = valor.CompareTo(nodo.Valor);

            if (resultadoComparacion < 0)
                nodo.Izquierdo = InsertarNodo(nodo.Izquierdo, valor);
            else if (resultadoComparacion > 0)
                nodo.Derecho = InsertarNodo(nodo.Derecho, valor);
            else
                return nodo; 

            
            return Balancear(nodo);
        }

        
        private NodoAVL EncontrarMinimo(NodoAVL nodo)
        {
            if (nodo == null)
                return null;

            while (nodo.Izquierdo != null)
                nodo = nodo.Izquierdo;

            return nodo;
        }

        
        public void Eliminar(int valor)
        {
            raiz = EliminarNodo(raiz, valor);
        }

        
        private NodoAVL EliminarNodo(NodoAVL nodo, int valor)
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
                
                if (nodo.Izquierdo == null)
                    return nodo.Derecho;
                else if (nodo.Derecho == null)
                    return nodo.Izquierdo;

               
                NodoAVL temp = EncontrarMinimo(nodo.Derecho);
                nodo.Valor = temp.Valor;
                nodo.Derecho = EliminarNodo(nodo.Derecho, temp.Valor);
            }

            
            return Balancear(nodo);
        }

        
        public bool Contiene(int valor)
        {
            return BuscarNodo(raiz, valor) != null;
        }

        
        private NodoAVL BuscarNodo(NodoAVL nodo, int valor)
        {
            if (nodo == null)
                return null;

            int resultadoComparacion = valor.CompareTo(nodo.Valor);

            if (resultadoComparacion < 0)
                return BuscarNodo(nodo.Izquierdo, valor);
            else if (resultadoComparacion > 0)
                return BuscarNodo(nodo.Derecho, valor);
            else
                return nodo;
        }

        
        

        

        
        
    }


}
