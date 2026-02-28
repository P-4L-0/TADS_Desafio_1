namespace Desafio1
{
	internal class NodoCola
	{
		public Pedido pedido;
		public NodoCola siguiente;


		public NodoCola(Pedido pedido)
		{
			this.pedido = pedido;
			siguiente = null;
		}
	}
}
