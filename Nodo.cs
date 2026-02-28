namespace Desafio1
{
	public class Nodo
	{
		public Pedido pedido;
		public Nodo siguiente;

		public Nodo(Pedido pedido)
		{
			this.pedido = pedido;
			siguiente = null;
		}
	}
}
