using RecetasSLN.Servicios.Implementacion;
using RecetasSLN.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecetasSLN.presentación
{
    public partial class FrmConsultarRecetas : Form
    {
        private iServicio gestor;
        public FrmConsultarRecetas()
        {
            InitializeComponent();
            gestor = new Servicio();
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void FrmConsultarRecetas_Load(object sender, EventArgs e)
        {
            CargarComboTipos();
        }

        private void CargarComboTipos()
        { 
            cboTipoReceta.DataSource = gestor.ObtenerTipos();
            cboTipoReceta.ValueMember="IdTipo";
            cboTipoReceta.DisplayMember="NombreTipo";
            cboTipoReceta.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            new AltaReceta().ShowDialog();
        }
    }
}
