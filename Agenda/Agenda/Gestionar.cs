using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda
{
    public partial class Gestionar : Form
    {
        ConnectionClass con = new ConnectionClass();
        Actualizar actualizar = new Actualizar();
        Agenda agenda = new Agenda();
        public Gestionar()
        {
            InitializeComponent();
            Cargar();
        }

        private void Cargar()
        {
            con.OpenConection();
            dataGridContactos.DataSource = con.ShowDataInGridView("SELECT * FROM AGENDA");
            con.CloseConnection();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nameOperation = txtBoxOperation.Text;           
            con.OpenConection();
            dataGridContactos.DataSource = con.ShowDataInGridView("SELECT * FROM AGENDA WHERE NOMBRE = '"+nameOperation + "'");
            con.CloseConnection();
        }

        private void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            actualizar.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string nameOperation = txtBoxOperation.Text;

            con.OpenConection();
            con.ExecuteQueries("DELETE FROM AGENDA WHERE NOMBRE='" + nameOperation + "'");
            con.CloseConnection();
            Cargar();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            agenda.Show();
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }
