using System;
namespace CapaPresentacion
{
    partial class FrmProducto
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblCodigo = new Label();
            lblNombre = new Label();
            lblPrecio = new Label();
            lblStock = new Label();
            lblCategoria = new Label();
            txtCodigo = new TextBox();
            txtNombre = new TextBox();
            txtPrecio = new TextBox();
            txtStock = new TextBox();
            cboCategoria = new ComboBox();
            btnGuardar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            btnStockBajo = new Button();
            btnMostrarTodos = new Button();
            dgvProductos = new DataGridView();
            lblValorTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();

            // Etiquetas
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(20, 23);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Text = "Código:";

            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(20, 58);
            lblNombre.Name = "lblNombre";
            lblNombre.Text = "Nombre:";

            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(20, 93);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Text = "Precio:";

            lblStock.AutoSize = true;
            lblStock.Location = new Point(20, 128);
            lblStock.Name = "lblStock";
            lblStock.Text = "Stock:";

            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(20, 163);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Text = "Categoría:";

            // Campos de datos
            txtCodigo.Location = new Point(100, 20);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(200, 23);

            txtNombre.Location = new Point(100, 55);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 23);

            txtPrecio.Location = new Point(100, 90);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(200, 23);

            txtStock.Location = new Point(100, 125);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(200, 23);

            cboCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategoria.Location = new Point(100, 160);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(200, 23);

            // Botones de acciones
            btnGuardar.Location = new Point(20, 200);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(70, 30);
            btnGuardar.Text = "Guardar";

            btnModificar.Location = new Point(100, 200);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(70, 30);
            btnModificar.Text = "Modificar";

            btnEliminar.Location = new Point(180, 200);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(70, 30);
            btnEliminar.Text = "Eliminar";

            btnLimpiar.Location = new Point(260, 200);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(70, 30);
            btnLimpiar.Text = "Limpiar";

            // Búsqueda y consultas
            txtBuscar.Location = new Point(400, 20);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(200, 23);

            btnBuscar.Location = new Point(610, 18);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 27);
            btnBuscar.Text = "Buscar";

            btnStockBajo.Location = new Point(400, 60);
            btnStockBajo.Name = "btnStockBajo";
            btnStockBajo.Size = new Size(190, 30);
            btnStockBajo.Text = "Stock bajo (menos de 5)";

            btnMostrarTodos.Location = new Point(600, 60);
            btnMostrarTodos.Name = "btnMostrarTodos";
            btnMostrarTodos.Size = new Size(110, 30);
            btnMostrarTodos.Text = "Mostrar todos";

            // Tabla
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.Location = new Point(20, 250);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(860, 250);

            // Total del inventario
            lblValorTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblValorTotal.AutoSize = true;
            lblValorTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblValorTotal.Location = new Point(20, 515);
            lblValorTotal.Name = "lblValorTotal";
            lblValorTotal.Text = "Valor total del inventario: 0.00";

            // Formulario
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 550);
            Controls.Add(lblCodigo);
            Controls.Add(lblNombre);
            Controls.Add(lblPrecio);
            Controls.Add(lblStock);
            Controls.Add(lblCategoria);
            Controls.Add(txtCodigo);
            Controls.Add(txtNombre);
            Controls.Add(txtPrecio);
            Controls.Add(txtStock);
            Controls.Add(cboCategoria);
            Controls.Add(btnGuardar);
            Controls.Add(btnModificar);
            Controls.Add(btnEliminar);
            Controls.Add(btnLimpiar);
            Controls.Add(txtBuscar);
            Controls.Add(btnBuscar);
            Controls.Add(btnStockBajo);
            Controls.Add(btnMostrarTodos);
            Controls.Add(dgvProductos);
            Controls.Add(lblValorTotal);
            Name = "FrmProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inventario de productos";
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblCodigo;
        private Label lblNombre;
        private Label lblPrecio;
        private Label lblStock;
        private Label lblCategoria;
        private TextBox txtCodigo;
        private TextBox txtNombre;
        private TextBox txtPrecio;
        private TextBox txtStock;
        private ComboBox cboCategoria;
        private Button btnGuardar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private Button btnStockBajo;
        private Button btnMostrarTodos;
        private DataGridView dgvProductos;
        private Label lblValorTotal;
    }
}