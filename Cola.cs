using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1
{
	internal class Cola
	{
		NodoCola primero;
		NodoCola ultimo;
		int totnodos;

		public Cola()
		{
			primero = ultimo = null;
			totnodos = 0;
		}

		public int TotNodos()
		{
			return this.totnodos; 
		}

		public bool EstaVacia()
		{
			if (primero == null)
			{
				return true;
			}
			else
				return false;
		}


		public void VerContenido()
		{
			NodoCola aux; 
			if(EstaVacia())
			{
				Console.WriteLine("La cola esta vacia, no tiene nodos");
			}
			else
			{
				Console.Write("Primero");
				aux = primero; 
				do
				{
					Console.Write("<- {0}", aux.pedido);
					aux = aux.siguiente; 
				}while(aux != null);
				Console.WriteLine("<- Ultimo"); 
			}
		}


		public void Encolar(NodoCola nodo)
		{
			if (EstaVacia())
			{
				primero = ultimo = nodo; 
			}
			else
			{
				ultimo.siguiente = nodo;
				ultimo = nodo; 
			}
			totnodos++;
		}

		public NodoCola Desencolar()
		{
			NodoCola aux = null;
			if (!EstaVacia())
			{
				aux = primero;
				primero = primero.siguiente;
				totnodos--;
			}
			return aux; 
		}
	}
}
