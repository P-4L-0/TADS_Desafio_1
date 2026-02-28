using System;

namespace Desafio1
{
	public class ListaPedidosListos
	{
		Nodo inicio;
		int totalnodos;

		public ListaPedidosListos()
		{
			inicio = null;
			totalnodos = 0;
		}

		public int TotalNodos() { return totalnodos; }

		public void Mostrar()
		{
			if (inicio == null)
				Console.WriteLine("Lista esta vacia");
			else
			{
				Nodo puntero = inicio;
				int tmp = 1;
				while (puntero != null)
				{
					Console.Write("{0}:{1} -> \t", tmp, puntero.pedido);
					puntero = puntero.siguiente;
					tmp++;
				}
			}
			Console.WriteLine();
		}

		public void InsertarI(Pedido item)
		{
			Nodo puntero;
			Nodo auxiliar = new Nodo(item);

			if (inicio == null) inicio = auxiliar;
			else
			{
				puntero = inicio;
				inicio = auxiliar;

				auxiliar.siguiente = puntero;
			}

			this.totalnodos++;
		}

		public void InsertarF(Pedido item)
		{
			Nodo auxiliar = new Nodo(item);
			if (inicio == null) inicio = auxiliar;
			else
			{
				Nodo puntero;
				puntero = inicio;
				while (puntero.siguiente != null)
				{
					puntero = puntero.siguiente;
				}

				puntero.siguiente = auxiliar;
			}
			this.totalnodos++;
		}

		public void InsertarP(Pedido item, int pos)
		{
			Nodo auiliar = new Nodo(item);
			if (inicio == null)
			{
				Console.WriteLine("La lista esta vacia, se insertara en posicion 1");
				inicio = auiliar;
			}
			else
			{
				Nodo puntero;
				puntero = inicio;

				if (pos == 1)
				{
					inicio = auiliar;
					auiliar.siguiente = inicio;
				}
				else
				{
					for (int i = 1; i < pos - 1; i++)
					{
						puntero = puntero.siguiente;
						if (puntero.siguiente == null) break;
					}

					Nodo punteronext;
					punteronext = puntero.siguiente;
					puntero.siguiente = auiliar;
					auiliar.siguiente = punteronext;
				}
			}
			this.totalnodos++;
		}

		public Nodo EliminarI()
		{
			Nodo nodotemp = null;
			if (inicio == null)
				Console.WriteLine("Lista esta vacia, no contiene nodos para borrar");
			else
			{
				nodotemp = inicio;

				inicio = inicio.siguiente;
				this.totalnodos--;
			}
			return nodotemp;
		}

		public Nodo EliminarF()
		{
			Nodo nodotemp = null;
			Nodo punteroant;
			Nodo punteropost;

			if (inicio == null)
				Console.WriteLine("Lista esta vacia, no contiene nodos para borrar");
			else
			{
				punteroant = inicio;
				punteropost = inicio;

				while (punteropost.siguiente != null)
				{
					punteroant = punteropost;
					punteropost = punteropost.siguiente;
				}

				nodotemp = punteropost;
				punteroant.siguiente = null;
				this.totalnodos--;
			}
			return (nodotemp);
		}

		public Nodo EliminarP(int pos)
		{
			Nodo nodoE;
			Nodo nodoPos, nodoAnt;

			int i = 1;
			if (pos > 0 && pos <= totalnodos)
			{
				nodoPos = inicio;
				nodoAnt = null;

				for (i = 1; i < pos; i++)
				{
					nodoAnt = nodoPos;
					nodoPos = nodoPos.siguiente;
				}

				nodoE = nodoPos;

				if (pos == 1)
					inicio = inicio.siguiente; 
				else
					nodoAnt.siguiente = nodoPos.siguiente;

				totalnodos--;
				return nodoE;
			}
			return null;
		}

		public Nodo VerNodo(int pos)
		{
			Nodo aux;
			int i = 1;
			if (pos > 0 && pos <= totalnodos)
			{
				aux = inicio;
				for (i = 1; i != pos; i++)
				{
					aux = aux.siguiente;
				}

				return aux;
			}

			return null;
		}

		public Pedido[] VerListos()
		{
			Pedido[] pedidos = new Pedido[this.totalnodos];
			Nodo puntero = inicio;
			int i = 0;

			while (puntero != null)
			{
				pedidos[i] = puntero.pedido;
				puntero = puntero.siguiente;
				i++;
			}

			return pedidos;
		}

	}
}
