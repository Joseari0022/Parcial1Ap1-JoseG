using Parcial1Ap1_JoseG.BLL;
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
            if (validarId("Favor ingresar el id del empleado") && ValidarBuscar())
                LlenarUsuario(EmpleadosBll.Buscar(u.String(IdtextBox.Text)));
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
            Empleados empleado = new Empleados();
            LlenarClase(empleado);
            if (ValidTextB() && ValidarExistente(NombretextBox.Text))
            {
                EmpleadosBll.Guardar(empleado);
                MessageBox.Show("Guardado con exito!!!!");
            }
        }

        public void LlenarClase(Empleados e)
        {
            e.Nombres = NombretextBox.Text;
            e.FechaNacimiento = FechaIngresodateTimePicker.Value;
            e.Sueldo = Convert.ToInt32(SueldotextBox.Text);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
                EmpleadosBll.Eliminar(u.String(IdtextBox.Text));
                MessageBox.Show("Empleado Eliminado");              
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

        private bool ValidarExistente(string aux)
        {
            if (EmpleadosBll.GetListaNombreEmpleado(aux).Count() > 0)
            {
                MessageBox.Show("Este empleado existe....");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool validarId(string message)
        {
            if (string.IsNullOrEmpty(IdtextBox.Text))
            {
                IderrorProvider.SetError(IdtextBox, "Ingresar el ID");
                MessageBox.Show(message);
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool ValidarBuscar()
        {
            if (EmpleadosBll.Buscar(u.String(IdtextBox.Text)) == null)
            {
                MessageBox.Show("Este Empleado no existe");
                return false;
            }
            return true;
        }
    }
}
