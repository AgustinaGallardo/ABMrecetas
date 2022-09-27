namespace RecetasSLN.presentación
{
    partial class AltaReceta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNext = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCheff = new System.Windows.Forms.TextBox();
            this.cboTipoRecetas = new System.Windows.Forms.ComboBox();
            this.cboIngredientes = new System.Windows.Forms.ComboBox();
            this.nuvCantidad = new System.Windows.Forms.NumericUpDown();
            this.dgvRecetas = new System.Windows.Forms.DataGridView();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCcancelar = new System.Windows.Forms.Button();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIngrediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAcciones = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtTotalIngredientes = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nuvCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecetas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNext
            // 
            this.lblNext.AutoSize = true;
            this.lblNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNext.Location = new System.Drawing.Point(24, 22);
            this.lblNext.Name = "lblNext";
            this.lblNext.Size = new System.Drawing.Size(137, 25);
            this.lblNext.TabIndex = 0;
            this.lblNext.Text = "Receta Nro ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(305, 400);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Total de ingredientes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tipo de Receta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(76, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Cheff:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(423, 191);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(127, 68);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(218, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // txtCheff
            // 
            this.txtCheff.Location = new System.Drawing.Point(127, 107);
            this.txtCheff.Name = "txtCheff";
            this.txtCheff.Size = new System.Drawing.Size(218, 20);
            this.txtCheff.TabIndex = 2;
            // 
            // cboTipoRecetas
            // 
            this.cboTipoRecetas.FormattingEnabled = true;
            this.cboTipoRecetas.Location = new System.Drawing.Point(127, 148);
            this.cboTipoRecetas.Name = "cboTipoRecetas";
            this.cboTipoRecetas.Size = new System.Drawing.Size(218, 21);
            this.cboTipoRecetas.TabIndex = 3;
            // 
            // cboIngredientes
            // 
            this.cboIngredientes.FormattingEnabled = true;
            this.cboIngredientes.Location = new System.Drawing.Point(44, 193);
            this.cboIngredientes.Name = "cboIngredientes";
            this.cboIngredientes.Size = new System.Drawing.Size(216, 21);
            this.cboIngredientes.TabIndex = 4;
            // 
            // nuvCantidad
            // 
            this.nuvCantidad.Location = new System.Drawing.Point(279, 193);
            this.nuvCantidad.Name = "nuvCantidad";
            this.nuvCantidad.Size = new System.Drawing.Size(120, 20);
            this.nuvCantidad.TabIndex = 5;
            // 
            // dgvRecetas
            // 
            this.dgvRecetas.AllowUserToAddRows = false;
            this.dgvRecetas.AllowUserToDeleteRows = false;
            this.dgvRecetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecetas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colIngrediente,
            this.colCantidad,
            this.colAcciones});
            this.dgvRecetas.Location = new System.Drawing.Point(27, 231);
            this.dgvRecetas.Name = "dgvRecetas";
            this.dgvRecetas.ReadOnly = true;
            this.dgvRecetas.Size = new System.Drawing.Size(496, 150);
            this.dgvRecetas.TabIndex = 7;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(154, 438);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCcancelar
            // 
            this.btnCcancelar.Location = new System.Drawing.Point(259, 438);
            this.btnCcancelar.Name = "btnCcancelar";
            this.btnCcancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCcancelar.TabIndex = 10;
            this.btnCcancelar.Text = "Cancelar";
            this.btnCcancelar.UseVisualStyleBackColor = true;
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            this.colID.Width = 150;
            // 
            // colIngrediente
            // 
            this.colIngrediente.HeaderText = "Ingredientes";
            this.colIngrediente.Name = "colIngrediente";
            this.colIngrediente.ReadOnly = true;
            this.colIngrediente.Width = 150;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            this.colCantidad.Width = 150;
            // 
            // colAcciones
            // 
            this.colAcciones.HeaderText = "Acciones";
            this.colAcciones.Name = "colAcciones";
            this.colAcciones.ReadOnly = true;
            this.colAcciones.Text = "Eliminar";
            this.colAcciones.UseColumnTextForButtonValue = true;
            this.colAcciones.Width = 150;
            // 
            // txtTotalIngredientes
            // 
            this.txtTotalIngredientes.Location = new System.Drawing.Point(417, 397);
            this.txtTotalIngredientes.Name = "txtTotalIngredientes";
            this.txtTotalIngredientes.Size = new System.Drawing.Size(106, 20);
            this.txtTotalIngredientes.TabIndex = 11;
            // 
            // AltaReceta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 482);
            this.Controls.Add(this.txtTotalIngredientes);
            this.Controls.Add(this.btnCcancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dgvRecetas);
            this.Controls.Add(this.nuvCantidad);
            this.Controls.Add(this.cboIngredientes);
            this.Controls.Add(this.cboTipoRecetas);
            this.Controls.Add(this.txtCheff);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNext);
            this.Name = "AltaReceta";
            this.Text = "AltaReceta";
            this.Load += new System.EventHandler(this.AltaReceta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nuvCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecetas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCheff;
        private System.Windows.Forms.ComboBox cboTipoRecetas;
        private System.Windows.Forms.ComboBox cboIngredientes;
        private System.Windows.Forms.NumericUpDown nuvCantidad;
        private System.Windows.Forms.DataGridView dgvRecetas;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCcancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIngrediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewButtonColumn colAcciones;
        private System.Windows.Forms.TextBox txtTotalIngredientes;
    }
}