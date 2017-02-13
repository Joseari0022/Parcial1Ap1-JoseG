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

namespace Parcial1Ap1_JoseG.UI.Consultas
{
    public partial class ConsultasEmpleados : Form
    {
        public ConsultasEmpleados()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            if (ValidarConsul() == true)
                BuscarSelecCombo();
        }

        Utilidades u = new Utilidades();
        public List<Entidades.Empleados> lista = new List<Empleados>();
        private void BuscarSelecCombo()
        {
            if (FiltrarcomboBox.SelectedIndex == 0)
            {
                if (!String.IsNullOrEmpty(FiltrotextBox.Text))
                {
                    lista = EmpleadosBll.GetListaId(u.String(FiltrotextBox.Text));
                }
                else
                {
                    lista = EmpleadosBll.GetLista();
                }
                ConsultaEmpleadosdataGridView.DataSource = lista;
            }
            if (FiltrarcomboBox.SelectedIndex == 1)
            {
                if (!String.IsNullOrEmpty(FiltrotextBox.Text))
                {
                    lista = EmpleadosBll.GetListaNombreEmpleado(FiltrotextBox.Text);
                }
                else
                {
                    lista = EmpleadosBll.GetLista();
                }
                ConsultaEmpleadosdataGridView.DataSource = lista;
            }
            if (FiltrarcomboBox.SelectedIndex == 2)
            {
                if (!String.IsNullOrEmpty(FiltrotextBox.Text))
                {
                    lista = EmpleadosBll.GetListaSueldo(Convert.ToInt32(FiltrotextBox.Text));
                }
                else
                {
                    lista = EmpleadosBll.GetLista();
                }
                ConsultaEmpleadosdataGridView.DataSource = lista;
            }
            if (FiltrarcomboBox.SelectedIndex == 3)
            {
                if (!String.IsNullOrEmpty(FiltrotextBox.Text))
                {
                    lista = EmpleadosBll.GetListaFecha(DesdeDateTimePicke.Value, HastadateTimePicker.Value);
                }
                else
                {
                    lista = EmpleadosBll.GetLista();
                }

                ConsultaEmpleadosdataGridView.DataSource = lista;
            }
        }

        private bool ValidarConsul()
        {
            if (FiltrarcomboBox.SelectedIndex == 3)
            {
                if (DesdeDateTimePicke.Value == HastadateTimePicker.Value)
                {
                    MessageBox.Show("Favor definir una fecha entre las fechas ");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            if (string.IsNullOrEmpty(FiltrotextBox.Text))
            {
                BuscarerrorProvider.SetError(FiltrotextBox, "Ingrese el campo....");
                return false;
            }
            if (FiltrarcomboBox.SelectedIndex == 0 && EmpleadosBll.GetListaId(int.Parse(FiltrotextBox.Text)).Count == 0)
            {
                MessageBox.Show("No existe registro con este campo de filtro intertar con otro por favor");
                return false;
            }
            if (FiltrarcomboBox.SelectedIndex == 1 && EmpleadosBll.GetListaNombreEmpleado(FiltrotextBox.Text).Count == 0)
            {
                MessageBox.Show("No existe registro con este campo de filtro intertar con otro por favor");
                return false;
            }
            if (FiltrarcomboBox.SelectedIndex == 2 && EmpleadosBll.GetListaSueldo(int.Parse(FiltrotextBox.Text)).Count == 0)
            {
                MessageBox.Show("No existe registro con este campo de filtro intertar con otro por favor");
                return false;
            }
            BuscarerrorProvider.Clear();
            return true;
        }

        private void Cargar()
        {
            FiltrarcomboBox.Items.Insert(0, "EmpleadoId");
            FiltrarcomboBox.Items.Insert(1, "Nombre");
            FiltrarcomboBox.Items.Insert(2, "Sueldo");
            FiltrarcomboBox.Items.Insert(3, "Fecha Nacimiento");
            FiltrarcomboBox.DataSource = FiltrarcomboBox.Items;
            FiltrarcomboBox.DisplayMember = "Id";
            ConsultaEmpleadosdataGridView.DataSource = EmpleadosBll.GetLista();
        }

        private void ConsultasEmpleados_Load(object sender, EventArgs e)
        {
            Cargar();
        }
    }
  }

