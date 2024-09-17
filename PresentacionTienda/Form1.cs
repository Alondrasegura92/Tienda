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
    public partial class Form1 : Form
    {
        ManejadorProducto mp;
        int fila = 0, columna = 0;
        public static string nombre = "", descripcion = "";
        public static int id = 0, precio = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            id = 0; nombre = ""; descripcion = ""; precio = 0;
            FrmDatosProductos dp = new FrmDatosProductos();
            dp.ShowDialog();
            txtProducto.Focus();
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            dtgvProducto.Visible = true;
            mp.Mostrar(dtgvProducto, txtProducto.Text);
        }

        private void dtgvProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex; columna = e.ColumnIndex;
            switch (columna)
            {
                case 4:
                    {
                        id = int.Parse(dtgvProducto.Rows[fila].Cells[0].Value.ToString());
                        mp.borrar(id, dtgvProducto.Rows[fila].Cells[1].Value.ToString());
                        dtgvProducto.Visible = false;
                    }
                    break;
                case 5:
                    {

                        id = int.Parse(dtgvProducto.Rows[fila].Cells[0].Value.ToString());
                        nombre = dtgvProducto.Rows[fila].Cells[1].Value.ToString();
                        descripcion = dtgvProducto.Rows[fila].Cells[2].Value.ToString();
                        precio = int.Parse(dtgvProducto.Rows[fila].Cells[3].Value.ToString());



                        FrmDatosProductos dp = new FrmDatosProductos();
                        dp.ShowDialog();
                        dtgvProducto.Visible = false;

                    }
                    break;
            }

        }

       
        public Form1()
        {
            InitializeComponent();
            mp = new ManejadorProducto();
        }
    }
}
