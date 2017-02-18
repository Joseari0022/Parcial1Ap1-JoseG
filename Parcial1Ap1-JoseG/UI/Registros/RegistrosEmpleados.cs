using Parcial1Ap1_JoseG.BLL;
using Parcial1Ap1_JoseG.DAL;
using Parcial1Ap1_JoseG.Entidades;
using SistemaGonzalez;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1Ap1_JoseG.UI.Registros
{
    public partial class principal : Form
    {
        public principal()
        {
            InitializeComponent();
        }

        Utilidades u = new Utilidades();

        private void Idbutton_Click(object sender, EventArgs e)
        {
            int id = int.Parse(IdtextBox.Text);
            Empleados empleado;
            using (var db = new BLL.Repositorio<Empleados>())
            {
                empleado = db.Buscar(p => p.EmpleadoId == id);
                
                if(empleado != null)
                {
                    NombretextBox.Text = empleado.Nombres;
                    SueldotextBox.Text = empleado.Sueldo.ToString();
                    FechaIngresodateTimePicker.Value = empleado.FechaNacimiento;
                }
                else
                {
                    MessageBox.Show("No existe el empleado");
                }
            }
        }

        private void LlenarUsuario(Empleados emp)
        {
            IdtextBox.Text = emp.EmpleadoId.ToString();
            NombretextBox.Text = emp.Nombres;
            FechaIngresodateTimePicker.Value = emp.FechaNacimiento;
            SueldotextBox.Text = emp.Sueldo.ToString();
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            IdtextBox.Clear();
            NombretextBox.Clear();
            SueldotextBox.Clear();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            var pas = new Empleados();
            pas.Nombres = NombretextBox.Text;
            pas.FechaNacimiento = FechaIngresodateTimePicker.Value;
            pas.Sueldo = Convert.ToInt32(SueldotextBox.Text);
            if (RepositorioBLL.Guardar(pas))
            {
                MessageBox.Show("Guardado con exito");
            }
            else if (ValidTextB())
            {
                MessageBox.Show("Por favor rellenar campos");
            }
        }

        

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {      
            int id = int.Parse(IdtextBox.Text);
            using (var db = new BLL.Repositorio<Empleados>())
            { 
                if (db.Eliminar(db.Buscar(p => p.EmpleadoId == id)))
                {
                    MessageBox.Show("Empleado eliminado");
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar");
                }
            }
        }

        public bool ValidTextB()
        {
            if (string.IsNullOrEmpty(NombretextBox.Text) && string.IsNullOrEmpty(SueldotextBox.Text))
            {
                NombreerrorProvider.SetError(NombretextBox, "Ingrese el nombre");
                SueldoerrorProvider.SetError(SueldotextBox, "Ingrese el sueldo");
                MessageBox.Show("Llenar todos los campos");
            }
            if (string.IsNullOrEmpty(NombretextBox.Text))
            {
                NombreerrorProvider.SetError(NombretextBox, "Ingrese el nombre");
                return false;
            }
            if (string.IsNullOrEmpty(SueldotextBox.Text))
            {
                NombreerrorProvider.Clear();
                SueldoerrorProvider.SetError(SueldotextBox, "Ingrese el sueldo");
                return false;
            }
            return true;
        }
    }
}
