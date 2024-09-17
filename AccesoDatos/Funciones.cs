using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexion;
using System.Data;

namespace AccesoDatos
{
    public class Funciones
    {
        Base b = new Base("localhost", "root", "", "Tienda");
        public string guardar(string q)
        {
            return b.Comando(q);
        }
        public DataSet Mostrar(string q, string tabla)
        {
            return b.Mostrar(q, tabla);
        }
        public string borrar(string q)
        {
            return b.Comando(q);
        }
        public string modificar(string q)
        {
            return b.Comando(q);
        }
        public string obtenerdato(string q, string tabla, string campo)
        {
            return b.ObtenerDatos(q, tabla, campo);
        }
    }
}
