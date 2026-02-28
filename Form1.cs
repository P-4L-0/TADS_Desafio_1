using System;
using System.Linq;
using System.Windows.Forms;

namespace Desafio1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			//para que inicio desactivado
			button1.Enabled = false;
		}

		// globals
		Cocinero[] cocineros = new Cocinero[4];
		Random rndm = new Random();
		public ListaPedidosListos pedidosTerminados = new ListaPedidosListos();
		int cantPedidos = 0;

		
		// boton registrar, registra xd
		private void button1_Click(object sender, EventArgs e)
		{
			//comprueva si esta activo
			if (this.Enabled == true)
			{

				string clt = textBox1.Text; //cliente
				string dsp = textBox2.Text; //descripcion
				string prd = comboBox1.Text;//prioridad

				// validacion de campos
				if (clt.Length == 0)
				{
					MessageBox.Show("Por favor ingrese su nombre");
					textBox1.Focus();
					return;
				}

				if (dsp.Length == 0)
				{
					MessageBox.Show("Por favor ingrese la descripcion de su pedido");
					textBox2.Focus();
					return;
				}

				if (prd.Length == 0)
				{
					MessageBox.Show("Por favor ingrese la prioridad de su pedido");
					comboBox1.Focus();
					return;
				}

				//calculo de tiempos
				int tiempo = 0;
				switch (prd)
				{
					case "Alta":
						tiempo = rndm.Next(5, 11);
						break;

					case "Media":
						tiempo = rndm.Next(10, 21);
						break;

					case "Baja":
						tiempo = rndm.Next(20, 31);
						break;
				}

				// creacion del pedido y asignacion a cocinero
				Pedido newPedido = new Pedido(clt, dsp, prd, DateTime.Now, tiempo);

				Cocinero defaultChef = cocineros[0];
				for (int i = 1; i < cocineros.Length; i++)
				{
					if(cocineros[i].colaPedidos.TotNodos() < defaultChef.colaPedidos.TotNodos())
					{
						defaultChef = cocineros[i];
					}
				}

				defaultChef.EncolarPedido(newPedido);

				// retrasa la preparacion
				if (defaultChef.disponible)
				{
					System.Threading.Thread.Sleep(800);
					Application.DoEvents();
					defaultChef.PrepararPedido();
				}

				// limpia los campos del form
				textBox1.Clear();
				textBox2.Clear();
				comboBox1.SelectedIndex = -1;
				textBox1.Focus();

			}
			else
				MessageBox.Show("La jornada aun no ha empezado");


		}

		// boton iniciar jornda, creaa los 4 cocineros
		private void button2_Click(object sender, EventArgs e)
		{
			button1.Enabled = true;
			cocineros[0] = new Cocinero(1, "Juan", "Reposteria", listBox1, panel1);
			cocineros[1] = new Cocinero(2, "Victor", "Banquetes", listBox2, panel2);
			cocineros[2] = new Cocinero(3, "Amilcar", "Mariscos", listBox3, panel3);
			cocineros[3] = new Cocinero(4, "Jorge", "Parrilla", listBox4, panel4);

			// Datos de prueba
			/*
			string[] nombres = { "Ana", "Luis", "Pedro", "Marta", "Jose", "Elena", "Carlos" };
			string[] platos = { "Pastel", "Pasta", "Ceviche", "Puyazo", "Tacos", "Sopa", "Pizza" };
			string[] prio = { "Alta", "Media", "Baja" };

			for (int i = 0; i < 7; i++)
			{
				
				int t = (i % 2 == 0) ? 5 : 10; // tiempos
				Pedido p = new Pedido(nombres[i], platos[i], prio[i % 3], DateTime.Now, t);

				Cocinero defaultChef = cocineros[0];
				for (int j = 1; j < cocineros.Length; j++)
				{
					if (cocineros[j].colaPedidos.TotNodos() < defaultChef.colaPedidos.TotNodos())
					{
						defaultChef = cocineros[j];
					}
				}

				defaultChef.EncolarPedido(p);
				//retraso para ver en form
				if (defaultChef.disponible)
				{
					System.Threading.Thread.Sleep(1000);
					Application.DoEvents();
					defaultChef.PrepararPedido();
				}
			}*/


		}

		// boton limpiar campos
		private void button3_Click(object sender, EventArgs e)
		{
			textBox1.Clear();
			textBox2.Clear();
			comboBox1.SelectedIndex = -1;
			textBox1.Focus();
		}


		// actualizar el dataview grid
		public void ActualizarGrid()
		{
			if (dataGridView1.InvokeRequired)
			{
				dataGridView1.Invoke(new Action(ActualizarGrid));
				return;
			}

			dataGridView1.Columns.Clear();
			dataGridView1.DataSource = null;
			dataGridView1.DataSource = pedidosTerminados.VerListos();
			this.cantPedidos++;
			lblCant.Text = this.cantPedidos.ToString();
		}
	}
}
