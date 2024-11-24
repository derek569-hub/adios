using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjDeJson
{
    public partial class Form1 : Form
    {
        private List<Estudiante> estudiantes = new List<Estudiante>();
        private const string RutaJson = "estudiantes.json";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregarEstudiante_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtMatricula.Text, out int matricula) &&
        int.TryParse(txtEdad.Text, out int edad) &&
        !string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                estudiantes.Add(new Estudiante { Matricula = matricula, Nombre = txtNombre.Text, Edad = edad });
                CargarEstudiantesEnGrid();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese datos válidos.");
            }
        }

        private void CargarEstudiantesEnGrid()
        {
            dgvEstudiantes.DataSource = null;
            dgvEstudiantes.DataSource = estudiantes;
        }

        private void LimpiarCampos()
        {
            txtMatricula.Clear();
            txtNombre.Clear();
            txtEdad.Clear();
        }

        private void btnGuardarJson_Click(object sender, EventArgs e)
        {
            ManejoJson.GuardarEnJson(estudiantes, RutaJson);
            MessageBox.Show("Datos guardados en JSON.");
        }

        private void btnLeerJson_Click(object sender, EventArgs e)
        {

            estudiantes = ManejoJson.LeerDesdeJson(RutaJson);
            CargarEstudiantesEnGrid();
            MessageBox.Show("Datos cargados desde JSON.");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
