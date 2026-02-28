using System;

namespace Desafio1
{
	public class Pedido
	{
		public string cliente { get; set; }
		public string descripcion { get; set; }
		public string prioridad { get; set; }
		public DateTime horaPedido { get; set; }
		public int tiempoEstimado { get; set; }

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
