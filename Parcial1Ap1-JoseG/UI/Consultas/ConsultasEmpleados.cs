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
            Selecionar();
        }
        
        private void Cargar()
        {
           
            FiltrarcomboBox.Items.Insert(0, "Nombre");
            FiltrarcomboBox.Items.Insert(1, "Fecha Nacimiento");
            FiltrarcomboBox.Items.Insert(2, "Todo");
            FiltrarcomboBox.DataSource = FiltrarcomboBox.Items;
            FiltrarcomboBox.DisplayMember = "Nombre";
        }

        public void Selecionar()
        {
            using (var db = new BLL.Repositorio<Empleados>())
            {
                if (FiltrarcomboBox.SelectedIndex == 0)
                {
                    ConsultaEmpleadosdataGridView.DataSource = db.GetListNombre(p => p.Nombres == FiltrotextBox.Text);
                }

                if (FiltrarcomboBox.SelectedIndex == 1)
                {
                    if (DesdeDateTimePicke.Value.Date <= HastadateTimePicker.Value.Date)
                    {
                        ConsultaEmpleadosdataGridView.DataSource = db.GetListFecha(p => p.FechaNacimiento >= DesdeDateTimePicke.Value.Date && p.FechaNacimiento <= HastadateTimePicker.Value.Date);
                    }
                }
                if (FiltrarcomboBox.SelectedIndex == 2)
                {
                    ConsultaEmpleadosdataGridView.DataSource = db.GetList();
                }
            }

        }
        private void ConsultasEmpleados_Load(object sender, EventArgs e)
        {
            Cargar();
        }
    }
  }

