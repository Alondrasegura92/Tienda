using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using System.Windows.Forms;
using System.Drawing;

namespace Manejador
{
    public class ManejadorProducto
    {
        Funciones f = new Funciones();
        public void Guardar(TextBox nombre, TextBox descripcion, TextBox precio)
        {

            MessageBox.Show(f.guardar($"Insert into productos values(null,'{nombre.Text}','{descripcion.Text}',{precio.Text})"),
               "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void borrar(int id, string dato)
        {
            DialogResult rs = MessageBox.Show($"Estas seguro de borrar {dato}",
                "!Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                f.borrar($"delete from productos where idproducto = {id}");
                MessageBox.Show("Registro Eliminado", "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        public void Modificar(TextBox nombre, TextBox descripcion, TextBox precio, int id)
        {
            MessageBox.Show(f.modificar($"update productos set nombre  = '{nombre.Text}',descripcion ='{descripcion.Text}', precio = {precio.Text} where idproducto = {id}"),
                "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        DataGridViewButtonColumn Boton(string t, Color co)
        {
            DataGridViewButtonColumn bo = new DataGridViewButtonColumn();
            bo.Text = t;
            bo.UseColumnTextForButtonValue = true;
            bo.FlatStyle = FlatStyle.Popup;
            bo.DefaultCellStyle.BackColor = co;
            bo.DefaultCellStyle.ForeColor = Color.White;
            return bo;

        }
        public void Mostrar(DataGridView tabla, string filtro)
        {
            tabla.Columns.Clear();
            tabla.DataSource = f.Mostrar($"select * from productos where nombre like '%{filtro}%'",
                "productos").Tables[0];
            tabla.Columns.Insert(4, Boton("Borrar", Color.Red));
            tabla.Columns.Insert(5, Boton("Modificar", Color.Green));
            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();


        }
    }
}
