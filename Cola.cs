using System;
using System.Windows.Forms;

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


		public void VerContenido(System.Windows.Forms.ListBox lstBox)
		{
			lstBox.Items.Clear(); 

			NodoCola puntero = primero; 

			while (puntero != null)
			{
				lstBox.Items.Add(puntero.pedido.descripcion);
				puntero = puntero.siguiente;
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
