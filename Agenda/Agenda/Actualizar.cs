using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda
{
    public partial class Actualizar : Form
    {
        ConnectionClass con = new ConnectionClass();
        public Actualizar()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string nombreABuscar = txtBoxNombre.Text;
            string nombreNuevo = txtBoxNombreNuevo.Text;
            string telefonoNuevo = txtBoxTelefonoNuevo.Text;

            con.OpenConection();
            con.ExecuteQueries("UPDATE AGENDA SET NOMBRE='" + nombreNuevo + "', TELEFONO= '" + telefonoNuevo + "' WHERE NOMBRE = '" + nombreABuscar + "'");
            con.CloseConnection();
            MessageBox.Show("Contacto actualizado con éxito");

        }

        private void txtBoxTelefonoNuevo_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
