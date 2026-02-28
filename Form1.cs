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
			button1.Enabled = false;
		}

		Cocinero[] cocineros = new Cocinero[4];
		Random rndm = new Random();
		public ListaPedidosListos pedidosTerminados = new ListaPedidosListos();

		//int[] tiempos = new int[];

		private void button1_Click(object sender, EventArgs e)
		{
			if (this.Enabled == true)
			{

				string clt = textBox1.Text; //cliente
				string dsp = textBox2.Text; //descripcion
				string prd = comboBox1.Text;//prioridad

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

				if (defaultChef.disponible)
				{
					System.Threading.Thread.Sleep(800);
					Application.DoEvents();
					defaultChef.PrepararPedido();
				}

				textBox1.Clear();
				textBox2.Clear();
				comboBox1.SelectedIndex = -1;
				textBox1.Focus();

			}
			else
				MessageBox.Show("La jornada aun no ha empezado");


		}
		private void button2_Click(object sender, EventArgs e)
		{
			button1.Enabled = true;
			cocineros[0] = new Cocinero(1, "Juan", "Reposteria", listBox1, panel1);
			cocineros[1] = new Cocinero(2, "Victor", "Banquetes", listBox2, panel2);
			cocineros[2] = new Cocinero(3, "Amilcar", "Mariscos", listBox3, panel3);
			cocineros[3] = new Cocinero(4, "Jorge", "Parrilla", listBox4, panel4);
		}


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
		}

	}
}
