using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1
{
	internal class Pedido
	{
		string cliente, descripcion, prioridad;
		DateTime horaPedido;
		int tiempoEstimado;

		public Pedido(string cliente, string descripcion,
			string prioridad, DateTime horaPedido, int tiempoEstimado)
		{
			this.cliente = cliente;
			this.descripcion = descripcion;
			this.prioridad = prioridad;
			this.horaPedido = horaPedido;
			this.tiempoEstimado = tiempoEstimado;
		}
	}
}
