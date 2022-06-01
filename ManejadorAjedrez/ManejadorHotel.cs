using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadAjedrez;
using AccesoDatosAjedrez;
using Crud;
using System.Windows.Forms;
using System.Drawing;

namespace ManejadorAjedrez
{
    public class ManejadorHotel : IManejador
    {
        AccesoHotel ah = new AccesoHotel();
        Grafico g = new Grafico();
        public void Borrar(dynamic Entidad)
        {
            DialogResult rs = MessageBox.Show(String.Format(String.Format(
            "Estas seguro de borrar: {0}", Entidad.Nombre)
            ), "!Atencion",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
                    if (rs == DialogResult.Yes)
                        ah.Borrar(Entidad);
        }

        public void Exportar(DataGridView tabla)
        {
            throw new NotImplementedException();
        }

        public void Guardar(dynamic Entidad)
        {
            ah.Guardar(Entidad);
            g.Mensaje("Hotel Guardado", "!Atencion",
                MessageBoxIcon.Information);
        }

        public void Mostrar(DataGridView tabla, string filtro)
        {
            tabla.Columns.Clear();
            tabla.RowTemplate.Height = 30;
            tabla.DataSource = ah.Mostrar(filtro).Tables["hotel"];
            tabla.Columns.Insert(4, g.Boton(
                "Editar", Color.Green));
            tabla.Columns.Insert(5, g.Boton("Borrar", Color.Red));
            tabla.Columns[0].Visible = false;
        }
        public Tuple<bool, string> ValidarUsuario(string uno, string dos, string tres)
        {
            bool error = true;
            string cadenaErrores = "";
            if (uno.Length == 0 || uno == null)
            {
                cadenaErrores = cadenaErrores + "El campo nombre no puede ser vacio. ";
                error = false;
            }
            if (uno.Length > 99)
            {
                cadenaErrores = cadenaErrores + "Se sobrepaso el numero de caracteres. ";
                error = false;

            }
            if (dos.Length == 0 || dos == null)
            {
                cadenaErrores = cadenaErrores + "El campo Direccion no puede ser vacio. ";
                error = false;
            }
            if (dos.Length > 99)
            {
                cadenaErrores = cadenaErrores + "Se sobrepaso el numero de caracteres. ";
                error = false;

            }
            if (tres.Length == 0 || tres == null)
            {
                cadenaErrores = cadenaErrores + "El campo Telefono no puede ser vacio";
                error = false;
            }
            if (tres.Length > 9)
            {
                cadenaErrores = cadenaErrores + "Se sobrepaso el numero de caracteres";
                error = false;

            }
            var valida = new Tuple<bool, string>(error, cadenaErrores);
            return valida;
        }
    }
}
