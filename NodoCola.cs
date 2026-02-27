using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1
{
	internal class NodoCola
	{
		public string pedido;
		public NodoCola siguiente;


		public NodoCola(string valor)
		{
			pedido = valor;
			siguiente = null; 
		}
	}
}
