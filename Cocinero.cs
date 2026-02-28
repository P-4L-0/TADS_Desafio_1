using System;
using System.Windows.Forms;

namespace Desafio1
{
	internal class Cocinero
	{
		int numero;
		string nombre, especialidad;
		public Cola colaPedidos;
		public bool disponible;
		Pedido pedidoActual;
		Timer timerCocinero; //IA
		ListBox lstCola; //IA
		Panel estadoPanel; 


		public Cocinero(int numero, string nombre, string especialidad, ListBox lstCola, Panel panel)
		{
			disponible = true;
			this.numero = numero;
			this.nombre = nombre;
			this.especialidad = especialidad;
			this.colaPedidos = new Cola();
			this.lstCola = lstCola;
			timerCocinero = new Timer();
			this.estadoPanel = panel;
			this.estadoPanel.BackColor = System.Drawing.Color.Green;
			this.timerCocinero.Tick += FinalizarPedido;
		}

		public void EncolarPedido(Pedido pedido)
		{
			NodoCola nodo = new NodoCola(pedido);
			this.colaPedidos.Encolar(nodo);
			colaPedidos.VerContenido(this.lstCola);
		}

		public void PrepararPedido()
		{
			this.estadoPanel.BackColor = System.Drawing.Color.Yellow;
			this.pedidoActual = colaPedidos.Desencolar().pedido;
			this.disponible = false;
			this.timerCocinero.Interval = pedidoActual.tiempoEstimado * 1000;
			this.timerCocinero.Start();
		}

		public void FinalizarPedido(object sender, EventArgs e)
		{
			this.estadoPanel.BackColor = System.Drawing.Color.Green;
			this.timerCocinero.Stop();
			this.lstCola.Items.RemoveAt(0);
			this.disponible = true;
			
			Form1 formulario = (Form1)Application.OpenForms["Form1"];

			if (formulario != null && this.pedidoActual != null)
			{
				formulario.pedidosTerminados.InsertarF(this.pedidoActual);
				formulario.ActualizarGrid();
			}
			if (!this.colaPedidos.EstaVacia())
			{
				this.PrepararPedido();
			}
		}


	}
}
