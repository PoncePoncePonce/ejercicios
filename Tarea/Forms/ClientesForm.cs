using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tarea.Clases;

namespace Tarea.Forms
{
    public partial class ClientesForm : Form
    {
        public List<Clientes> ListaClientes = new List<Clientes>();
        public ClientesForm()
        {
            InitializeComponent();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                var cliente = new Clientes(txt_nombre.Text,
                            txt_Apellido.Text,
                            txt_edad.Text,
                            txt_direccion.Text);

                cliente.Agregar_Cliente();

                ListaClientes.Add(cliente);

                LimpiarFormulario();

                dtg_clientes.DataSource = null;
                dtg_clientes.DataSource = ListaClientes;
                dtg_clientes.Refresh();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error.", "Informativo");

            }
        }
        private void Clientes_Shown(object sender, EventArgs e)
        {
            try
            {
                var cliente = new Clientes();
                ListaClientes = cliente.Cargar_Clientes();
                dtg_clientes.DataSource = ListaClientes;
                //dtg_clientes.Refresh();
            }
            catch (Exception)
            {

                MessageBox.Show("Ha ocurrido un error.", "Informativo");

            }

        }
        private void LimpiarFormulario()
        {
            try
            {
                txt_nombre.Text = string.Empty;
                txt_Apellido.Text = string.Empty;
                txt_edad.Text = string.Empty;
                txt_direccion.Text = string.Empty;

            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error.", "Informativo");
            }
            finally
            {
                txt_nombre.Text = string.Empty;
                txt_Apellido.Text = string.Empty;
                txt_edad.Text = string.Empty;
                txt_direccion.Text = string.Empty;
            }

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
