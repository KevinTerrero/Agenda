using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda
{
    public partial class Agenda : Form
    {

        public Agenda()
        {
            InitializeComponent();
        }

        private void btnGestionar_Click(object sender, EventArgs e)
        {
            Gestionar gestionar = new Gestionar();
            gestionar.Show();
            this.Hide();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Agregar agregar = new Agregar();
            agregar.Show();
            this.Hide();
        }
    }
}
