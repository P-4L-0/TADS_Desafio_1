using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desafio1
{
	internal class Cocinero
	{
		int numero;
		string nombre, especialidad;
		Cola colaPedidos;
		bool disponible;
		Pedido pedidoActual;
		System.Windows.Forms.Timer timerCocinero; //IA
		System.Windows.Forms.ListBox lstCola; //IA

		public Cocinero(int numero, string nombre, string especialidad, ListBox lstCola)
		{
			disponible = true;
			this.numero = numero; 
			this.nombre = nombre;
			this.especialidad = especialidad;
			this.colaPedidos = new Cola();
			this.lstCola = lstCola;

		}

		public void EncolarPedido()
		{

		}

		public void PrepararPedido()
		{

		}

		public void FinalizarPedido()
		{

		}
	}
}
