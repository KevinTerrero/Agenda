using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda
{
    public partial class Agregar : Form
    {
        Agenda agenda = new Agenda();
        ConnectionClass con = new ConnectionClass();
        public Agregar()
        {
            InitializeComponent();
           
        }

        private void txtBoxTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void btnAgregarContact_Click(object sender, EventArgs e)
        {
            string nombre = txtBoxNombre.Text;
            string telefono = txtBoxTelefono.Text;
            try
            {
                if (txtBoxNombre.Text != "" && txtBoxTelefono.Text != "")
                {
                    con.OpenConection();
                    con.ExecuteQueries("INSERT INTO AGENDA(NOMBRE, TELEFONO) VALUES ('" + nombre + "','" + telefono + "')");
                    con.CloseConnection();
                    MessageBox.Show("Contacto añadido con éxito.");
                    txtBoxNombre.Text = "";
                    txtBoxTelefono.Text = "";
                }
                else
                {
                    MessageBox.Show("Dejó un campo vacío.");
                }
                
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            agenda.Show();
            this.Close();
        }
    }
}
