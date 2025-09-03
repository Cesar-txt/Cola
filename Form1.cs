using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cola
{
    public partial class Form1 : Form
    {
        private Cola cola;

        public Form1()
        {
            InitializeComponent();
            cola = new Cola(5);

        }
        private void ActualizarVisualizacion()
        {
            listBox1.Items.Clear();

            if (cola.EstaVacia())
            {
                listBox1.Items.Add("Cola vacía");
            }
            else
            {

                for (int i = 0; i < cola.Tamaño(); i++)
                {
                    int indice = (cola.ObtenerFrente() + i) % cola.ObtenerMax();
                    int elemento = cola.ObtenerElemento(indice);

                    if (i == 0)
                        listBox1.Items.Add($"{elemento}");
                    else
                        listBox1.Items.Add($"{elemento}");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int tamaño = int.Parse(textBox1.Text);
                if (tamaño > 0)
                {
                    cola = new Cola(tamaño);
                    label4.Text = $"Nueva cola creada con tamaño {tamaño}";
                    ActualizarVisualizacion();
                }
                else
                {
                    label4.Text = "El tamaño debe ser mayor a 0";
                }
            }
            catch (FormatException)
            {
                label4.Text = "Por favor ingrese un número válido para el tamaño";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int elemento = int.Parse(textBox2.Text);
                if (cola.Enqueue(elemento))
                {
                    label4.Text = $"Elemento {elemento} encolado exitosamente";
                    textBox2.Clear();
                }
                else
                {
                    label4.Text = "La cola está llena";
                }
                ActualizarVisualizacion();
            }
            catch (FormatException)
            {
                label4.Text = "Por favor ingrese un número válido";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int elemento = cola.Dequeue();
            if (elemento != -1)
            {
                label4.Text = $"Elemento desencolado: {elemento}";
            }
            else
            {
                label4.Text = "La cola está vacía";
            }
            ActualizarVisualizacion();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int elemento = cola.Peek();
            if (elemento != -1)
            {
                label4.Text = $"Primer elemento (Peek): {elemento}";
            }
            else
            {
                label4.Text = "La cola está vacía";
            }
        }
    }
    
}
