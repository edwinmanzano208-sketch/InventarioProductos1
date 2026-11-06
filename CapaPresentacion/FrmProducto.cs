using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmProducto : Form
    {
        ProductoNegocio productoNegocio = new ProductoNegocio();        
        CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
        int idSeleccionado = 0;

        public FrmProducto()
        {
            InitializeComponent();

            Load += FrmProducto_Load;
            btnGuardar.Click += btnGuardar_Click;
            btnModificar.Click += btnModificar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            btnBuscar.Click += btnBuscar_Click;
            btnStockBajo.Click += btnStockBajo_Click;
            btnMostrarTodos.Click += btnMostrarTodos_Click;
            dgvProductos.CellClick += dgvProductos_CellClick;
        }

        void CargarProductos()
        {
            dgvProductos.DataSource = productoNegocio.Listar();
            lblValorTotal.Text = "Valor total del inventario: " + productoNegocio.ValorTotalInventario();
        }

        void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            cboCategoria.SelectedIndex = -1;
            idSeleccionado = 0;
        }

        void FrmProducto_Load(object sender, EventArgs e)
        {
            try
            {
                cboCategoria.DisplayMember = "Nombre";
                cboCategoria.ValueMember = "IdCategoria";
                cboCategoria.DataSource = categoriaNegocio.Listar();
                cboCategoria.SelectedIndex = -1;
                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int idCategoria = Convert.ToInt32(cboCategoria.SelectedValue);
                string mensaje = productoNegocio.Insertar(txtCodigo.Text, txtNombre.Text, txtPrecio.Text, txtStock.Text, idCategoria);

                if (mensaje != "")
                {
                    MessageBox.Show(mensaje);
                }
                else
                {
                    MessageBox.Show("Producto guardado.");
                    LimpiarCampos();
                    CargarProductos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int idCategoria = Convert.ToInt32(cboCategoria.SelectedValue);
                string mensaje = productoNegocio.Modificar(idSeleccionado, txtCodigo.Text, txtNombre.Text, txtPrecio.Text, txtStock.Text, idCategoria);

                if (mensaje != "")
                {
                    MessageBox.Show(mensaje);
                }
                else
                {
                    MessageBox.Show("Producto modificado.");
                    LimpiarCampos();
                    CargarProductos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar: " + ex.Message);
            }
        }

        void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = productoNegocio.Eliminar(idSeleccionado);

                if (mensaje != "")
                {
                    MessageBox.Show(mensaje);
                }
                else
                {
                    MessageBox.Show("Producto eliminado.");
                    LimpiarCampos();
                    CargarProductos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvProductos.DataSource = productoNegocio.Buscar(txtBuscar.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message);
            }
        }

        void btnStockBajo_Click(object sender, EventArgs e)
        {
            try
            {
                dgvProductos.DataSource = productoNegocio.ListarStockBajo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar: " + ex.Message);
            }
        }

        void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                txtBuscar.Clear();
                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar: " + ex.Message);
            }
        }

        void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];
                idSeleccionado = Convert.ToInt32(fila.Cells["IdProducto"].Value);
                txtCodigo.Text = Convert.ToString(fila.Cells["Codigo"].Value);
                txtNombre.Text = Convert.ToString(fila.Cells["Nombre"].Value);
                txtPrecio.Text = Convert.ToString(fila.Cells["Precio"].Value);
                txtStock.Text = Convert.ToString(fila.Cells["Stock"].Value);
                cboCategoria.SelectedValue = Convert.ToInt32(fila.Cells["IdCategoria"].Value);
            }
        }
    }
}