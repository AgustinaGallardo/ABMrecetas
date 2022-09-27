using RecetasSLN.datos;
using RecetasSLN.dominio;
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
        private Receta  nueva;
        public AltaReceta()
        {
            InitializeComponent();
            gestor = new Servicio();
            nueva = new Receta();
        }
        private void AltaReceta_Load(object sender, EventArgs e)
        {
            ObtenerProximo();
            CargarTipo();
            CargarIngredientes();
        }

        private void CargarIngredientes()
        {
            cboIngredientes.ValueMember = "IngredienteId";
            cboIngredientes.DisplayMember = "Nombre";
            cboIngredientes.DataSource = gestor.ObtenerIngredientes();   
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

            //DataRowView item = (DataRowView)cboIngredientes.SelectedItem;

            //int idIngrediente = Convert.ToInt32(item.Row.ItemArray[0]);
            //string ingrediente = (item.Row.ItemArray[1].ToString());

            //Ingrediente Ing = new Ingrediente(idIngrediente, ingrediente);

            //int cantidad = Convert.ToInt32(nuvCantidad.Value);

            //DetalleReceta detalle = new DetalleReceta(Ing, cantidad);

            //nueva.AgregarDetalle(detalle);

            //dgvRecetas.Rows.Add(new object[]
            //{
            //   Ing.IngredienteId,
            //   Ing.Nombre,
            //   detalle.Cantidad
            //});

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

             //TipoReceta t = (TipoReceta)cboTipoRecetas.SelectedItem;
            //t.NombreTipo = Convert.ToString(cboTipoRecetas.SelectedValue);
            //t.IdTipo = Convert.ToInt32(cboTipoRecetas.SelectedValue);
             //nueva.TipoReceta= t;

            if(Helper.ObtenerInstancia().ConfirmarReceta(nueva))
            {
                MessageBox.Show("Receta agregada con exito!!!!!!","Registro",MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("NO SE PUEDO REGISTRAR LA RECETA", "ERROR", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }

            LimpiarCampos();
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
