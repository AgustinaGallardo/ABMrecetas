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
    public partial class AltaReceta : Form
    {
        private iServicio gestor;
        public AltaReceta()
        {
            InitializeComponent();
            gestor = new Servicio();
        }
        private void AltaReceta_Load(object sender, EventArgs e)
        {
            ObtenerProximo();
            CargarTipo();
            CargarIngredientes();
        }

        private void CargarIngredientes()
        {
            cboIngredientes.DataSource = gestor.ObtenerIngredientes();
            cboIngredientes.ValueMember = "IngredienteId";
            cboIngredientes.DisplayMember = "Nombre";
            cboIngredientes.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void CargarTipo()
        {
            cboTipoRecetas.DataSource=gestor.ObtenerTipos();
            cboTipoRecetas.DisplayMember="NombreTipo";
            cboTipoRecetas.ValueMember="IdTipo";
            cboTipoRecetas.DropDownStyle=ComboBoxStyle.DropDownList;
        }
        private void ObtenerProximo()
        {
            int next = gestor.ObtenerProximo();
            if (next > 0)
            {
                lblNext.Text = "Receta Nro: " + next.ToString();
            }
            else
            {
                MessageBox.Show("Nose puede cargar la siguente receta", "Error",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            }





















        }
    }
}
