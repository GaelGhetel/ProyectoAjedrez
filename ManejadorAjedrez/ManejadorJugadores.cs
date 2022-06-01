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
    public class ManejadorJugadores : IManejador
    {
        AccesoJugadores aj = new AccesoJugadores();
        AccesoPais ap = new AccesoPais();
        Grafico g = new Grafico();
        public void Borrar(dynamic Entidad)
        {
            DialogResult rs = MessageBox.Show(String.Format(String.Format(
                "Estas seguro de borrar: {0}", Entidad.Nombre)
                ), "!Atencion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                        if (rs == DialogResult.Yes)
                            aj.Borrar(Entidad);
        }

        public void Exportar(DataGridView tabla)
        {
            throw new NotImplementedException();
        }

        public void Guardar(dynamic Entidad)
        {
            aj.Guardar(Entidad);
            g.Mensaje("Jugador Guardado", "!Atención",
            MessageBoxIcon.Information);
        }

        public void Mostrar(DataGridView tabla, string filtro)
        {
            tabla.Columns.Clear();
            tabla.RowTemplate.Height = 30;
            tabla.DataSource = aj.Mostrar(filtro).Tables["jugadores"];
            tabla.Columns.Insert(7, g.Boton(
                "Editar", Color.Green));
            tabla.Columns.Insert(8, g.Boton(
                "Borrar", Color.Red));
            tabla.Columns[0].Visible = false;
        }
        public void ExtaerPais(ComboBox caja)
        {
            caja.DataSource = ap.Mostrar("").Tables["pais"];
            caja.DisplayMember = "Nombre";
            caja.ValueMember = "Ncorrelativo";
        }
        public Tuple<bool, string> ValidarUsuario(string uno, string dos, string tres, string cuatro, string cinco, string seis)
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
            if (cuatro.Length == 0 || cuatro == null)
            {
                cadenaErrores = cadenaErrores + "El campo Campeonato no puede ser vacio. ";
                error = false;
            }

            if (cinco.Length == 0 || cinco == null)
            {
                cadenaErrores = cadenaErrores + "El campo Pais no puede ser vacio. ";
                error = false;
            }

            if (cinco == "0")
            {
                cadenaErrores = cadenaErrores + "pais  debe ser mayor a 0. ";
                error = false;

            }
            if (seis.Length == 0 || seis == null)
            {
                cadenaErrores = cadenaErrores + "El campo Nivel de Juego no puede ser vacio. ";
                error = false;
            }

            if (seis == "0")
            {
                cadenaErrores = cadenaErrores + "Nivel de Juego  debe ser mayor a 0. ";
                error = false;

            }

            var valida = new Tuple<bool, string>(error, cadenaErrores);
            return valida;
        }
    }
}
