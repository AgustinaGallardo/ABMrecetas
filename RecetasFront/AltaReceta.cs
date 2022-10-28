using Newtonsoft.Json;
using RecetaBack.dominio;
using RecetaBack.Negocio.Implementacion;
using RecetaBack.Negocio.Interfaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecetasFront
{
    public partial class AltaReceta : Form
    {
        private IAplicacion gestor;
        private Receta  nueva;
        public AltaReceta()
        {
            InitializeComponent();
            gestor = new Aplicacion();
            nueva = new Receta();
        }
        private  async void AltaReceta_Load(object sender, EventArgs e)
        {
          //ObtenerProximo();
          //CargarTipo();
           await CargarComboAsync();
        }

        private async Task CargarComboAsync()
        {
            string URL = "https://localhost:7164/api/Recetas/Ingredientes";
            HttpClient Cliente = new HttpClient();
           var result = await Cliente.GetAsync(URL);

           var bodyJSON = await result.Content.ReadAsStringAsync();
            List<Ingrediente> lst = JsonConvert.DeserializeObject<List<Ingrediente>>(bodyJSON);
            
         //cargarCombo   
            cboIngredientes.DataSource = lst;
            cboIngredientes.DisplayMember = "Nombre";
            cboIngredientes.ValueMember = "IngredienteId";
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
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboIngredientes.Text.Equals(string.Empty))
            {
                MessageBox.Show("Debe seleccionar un ingrediente", "Error",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            }
            if (nuvCantidad.Value <= 0)
            {
                MessageBox.Show("Debe ingresar la cantidad de ingredientes", "error",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            }

            foreach (DataGridViewRow row in dgvRecetas.Rows) //VALIDAR QUE UN MISMO INGREDIENTE NO PUEDE ESTAR
            {
                if (row.Cells["colIngrediente"].Value.ToString().Equals(cboIngredientes.Text))
                {
                    MessageBox.Show("Igredientes: " + cboIngredientes.Text + "ya se encuentra en la lista", "Control",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            Ingrediente i = (Ingrediente)cboIngredientes.SelectedItem;
            int cantidad = Convert.ToInt32(nuvCantidad.Value);

            DetalleReceta detalle = new DetalleReceta(i,cantidad);
            nueva.AgregarDetalle(detalle);

            dgvRecetas.Rows.Add(detalle.Ingrediente.IngredienteId, detalle.Ingrediente.Nombre, detalle.Cantidad);

            CalcularIngredientes();         
        }

        private void CalcularIngredientes()
        {
            int total = nueva.CalcularIngredientes();
            txtTotalIngredientes.Text = total.ToString(); 
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text == "")
            {
                MessageBox.Show("Tiene que colocar el nombre de la receta para continuar", "Stop",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            }
            if(txtCheff.Text == string.Empty)
            {
                MessageBox.Show("Tiene que colocar el Cheff para continuar", "Stop",
                   MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            }
            if(int.Parse(txtTotalIngredientes.Text) < 3)
            {
                MessageBox.Show("Ha olvidado ingredientes ? ", "Stop",
                  MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            }
            GuardarReceta();
        }
        private void GuardarReceta()
        {

            TipoReceta t = (TipoReceta)cboTipoRecetas.SelectedItem;
            nueva.Nombre = txtNombre.Text;
            nueva.Cheff = txtCheff.Text;
            nueva.TipoReceta =t;

            //if(Helper.ObtenerInstancia().ConfirmarReceta(nueva))
            //{
            //    MessageBox.Show("Receta agregada con exito!!!!!!","Registro",MessageBoxButtons.YesNo,
            //        MessageBoxIcon.Exclamation);
            //}
            //else
            //{
            //    MessageBox.Show("NO SE PUEDO REGISTRAR LA RECETA", "ERROR", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            //}

            //LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Text=string.Empty;
            cboIngredientes.SelectedIndex= -1;
            cboIngredientes.SelectedIndex= -1;
            txtCheff.Text=string.Empty;
            nuvCantidad.Value=0;
            dgvRecetas.Rows.Clear();
            txtTotalIngredientes.Text=string.Empty;
        }
    }
}
