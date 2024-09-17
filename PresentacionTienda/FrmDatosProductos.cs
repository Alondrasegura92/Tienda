using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manejador;

namespace PresentacionTienda
{
    public partial class FrmDatosProductos : Form
    {
        ManejadorProducto mp;
        public FrmDatosProductos()
        {
            InitializeComponent();
            mp = new ManejadorProducto();
            if (Form1.id > 0)
            {
                txtNombre.Text = Form1.nombre;
                txtDescripcion.Text = Form1.descripcion;
                txtPrecio.Text = Form1.precio.ToString();

            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Form1.id > 0)
            {
                mp.Modificar(txtNombre, txtDescripcion, txtPrecio, Form1.id);
            }
            else
            {
                mp.Guardar(txtNombre, txtDescripcion, txtPrecio);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
