using System.Diagnostics;
using Tarea_Arbol;

const int TAMANIO = 10000;


int[] numerosAleatorios = new int[TAMANIO];


Random rand = new Random();
for (int i = 0; i < TAMANIO; i++)
{
    numerosAleatorios[i] = rand.Next(1, 1000000); 
}

Console.WriteLine($"Generados {TAMANIO} números aleatorios.");


ArbolBST arbolBST = new ArbolBST();
ArbolAvl arbolAVL = new ArbolAvl();


Console.WriteLine("\n===== CASO 1: INSERCIÓN DE TODOS LOS ELEMENTOS =====");


Stopwatch cronometroBST = new Stopwatch();
cronometroBST.Start();

foreach (int numero in numerosAleatorios)
{
    arbolBST.Insertar(numero);
}

cronometroBST.Stop();


Stopwatch cronometroAVL = new Stopwatch();
cronometroAVL.Start();

foreach (int numero in numerosAleatorios)
{
    arbolAVL.Insertar(numero);
}

cronometroAVL.Stop();


Console.WriteLine($"BST: {cronometroBST.ElapsedMilliseconds} ms");
Console.WriteLine($"AVL: {cronometroAVL.ElapsedMilliseconds} ms");


Console.WriteLine($"Altura BST: {arbolBST.ObtenerAltura()} niveles");
Console.WriteLine($"Altura AVL: {arbolAVL.ObtenerAltura()} niveles");


Console.WriteLine("\n===== CASO 2: BÚSQUEDA DE ELEMENTOS EN DISTINTAS POSICIONES =====");


Array.Sort(numerosAleatorios);


int elementoInicio = numerosAleatorios[0]; 
int elementoMedio = numerosAleatorios[TAMANIO / 2]; 
int elementoFinal = numerosAleatorios[TAMANIO - 1]; 

Console.WriteLine($"Buscando elementos: {elementoInicio} (inicio), {elementoMedio} (medio), {elementoFinal} (final)");


Console.WriteLine("\nBúsqueda en BST:");


cronometroBST.Reset();
cronometroBST.Start();
bool encontradoBSTInicio = arbolBST.Contiene(elementoInicio);
cronometroBST.Stop();
Console.WriteLine($"Elemento inicio: {cronometroBST.ElapsedTicks} ticks - Encontrado: {encontradoBSTInicio}");


cronometroBST.Reset();
cronometroBST.Start();
bool encontradoBSTMedio = arbolBST.Contiene(elementoMedio);
cronometroBST.Stop();
Console.WriteLine($"Elemento medio: {cronometroBST.ElapsedTicks} ticks - Encontrado: {encontradoBSTMedio}");


cronometroBST.Reset();
cronometroBST.Start();
bool encontradoBSTFinal = arbolBST.Contiene(elementoFinal);
cronometroBST.Stop();
Console.WriteLine($"Elemento final: {cronometroBST.ElapsedTicks} ticks - Encontrado: {encontradoBSTFinal}");


Console.WriteLine("\nBúsqueda en AVL:");


cronometroAVL.Reset();
cronometroAVL.Start();
bool encontradoAVLInicio = arbolAVL.Contiene(elementoInicio);
cronometroAVL.Stop();
Console.WriteLine($"Elemento inicio: {cronometroAVL.ElapsedTicks} ticks - Encontrado: {encontradoAVLInicio}");


cronometroAVL.Reset();
cronometroAVL.Start();
bool encontradoAVLMedio = arbolAVL.Contiene(elementoMedio);
cronometroAVL.Stop();
Console.WriteLine($"Elemento medio: {cronometroAVL.ElapsedTicks} ticks - Encontrado: {encontradoAVLMedio}");


cronometroAVL.Reset();
cronometroAVL.Start();
bool encontradoAVLFinal = arbolAVL.Contiene(elementoFinal);
cronometroAVL.Stop();
Console.WriteLine($"Elemento final: {cronometroAVL.ElapsedTicks} ticks - Encontrado: {encontradoAVLFinal}");


Console.WriteLine("\n===== CASO 3: ELIMINACIÓN DE UN ELEMENTO =====");


int elementoEliminar = numerosAleatorios[TAMANIO / 2]; 
Console.WriteLine($"Eliminando elemento: {elementoEliminar}");


cronometroBST.Reset();
cronometroBST.Start();
arbolBST.Eliminar(elementoEliminar);
cronometroBST.Stop();
Console.WriteLine($"BST: {cronometroBST.ElapsedTicks} ticks");


cronometroAVL.Reset();
cronometroAVL.Start();
arbolAVL.Eliminar(elementoEliminar);
cronometroAVL.Stop();
Console.WriteLine($"AVL: {cronometroAVL.ElapsedTicks} ticks");


Console.WriteLine($"Elemento {elementoEliminar} existe en BST: {arbolBST.Contiene(elementoEliminar)}");
Console.WriteLine($"Elemento {elementoEliminar} existe en AVL: {arbolAVL.Contiene(elementoEliminar)}");

