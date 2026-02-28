using System;
using System.Drawing;
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
		Timer timerCocinero;
		ListBox lstCola;
		Panel estadoPanel; 
		
		// constructor
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
			this.estadoPanel.Paint += DibujarEstado;
			// reinicia el panel
			this.estadoPanel.Invalidate();

			// evento timer
			this.timerCocinero.Tick += FinalizarPedido;
		}

		public void EncolarPedido(Pedido pedido)
		{
			NodoCola nodo = new NodoCola(pedido);
			this.colaPedidos.Encolar(nodo);
			this.colaPedidos.VerContenido(this.lstCola);
		}

		public void PrepararPedido()
		{
			this.pedidoActual = colaPedidos.Desencolar().pedido;
			this.disponible = false;
			this.estadoPanel.Invalidate();
			this.timerCocinero.Interval = pedidoActual.tiempoEstimado * 1000;
			this.timerCocinero.Start();
		}

		public void FinalizarPedido(object sender, EventArgs e)
		{
			this.timerCocinero.Stop();
			this.colaPedidos.VerContenido(this.lstCola);
			this.disponible = true;
			this.estadoPanel.Invalidate();

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

		// dibuja el circulo de color en el panel
		private void DibujarEstado(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			
			Brush colorCirculo = Brushes.Green; // disponible

			if (!this.disponible)
			{
				colorCirculo = Brushes.Red; // preparando
			}

			g.FillEllipse(colorCirculo, 1, 1, 12, 12);
			g.DrawEllipse(Pens.Black, 1, 1, 12, 12);
		}


	}
}
