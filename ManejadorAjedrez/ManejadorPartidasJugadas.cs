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
    public class ManejadorPartidasJugadas : IManejador
    {
        AccesoPartidasjugadas apj = new AccesoPartidasjugadas();
        AccesoJugadores aj = new AccesoJugadores();
        AccesoPartida apa = new AccesoPartida();
        Grafico g = new Grafico();
        public void Borrar(dynamic Entidad)
        {
            DialogResult rs = MessageBox.Show(String.Format(String.Format(
            "Estas seguro de borrar: {0}", Entidad.Idjugadas)
            ), "!Atencion",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
                        if (rs == DialogResult.Yes)
                            apj.Borrar(Entidad);
        }

        public void Exportar(DataGridView tabla)
        {
            throw new NotImplementedException();
        }

        public void Guardar(dynamic Entidad)
        {
            apj.Guardar(Entidad);
            g.Mensaje("Partida jugada Guardadada", "!Atención",
            MessageBoxIcon.Information);
        }

        public void Mostrar(DataGridView tabla, string filtro)
        {
            tabla.Columns.Clear();
            tabla.RowTemplate.Height = 30;
            tabla.DataSource = apj.Mostrar(filtro).Tables["partidasjugadas"];
            tabla.Columns.Insert(4, g.Boton(
                "Editar", Color.Green));
            tabla.Columns.Insert(5, g.Boton(
                "Borrar", Color.Red));
            tabla.Columns[0].Visible = false;
        }
        public void ExtaerJugadores(ComboBox caja)
        {
            caja.DataSource = aj.Mostrar("").Tables["jugadores"];
            caja.DisplayMember = "Nombre";
            caja.ValueMember = "Numasociado";
        }
        public void ExtaerPartida(ComboBox caja)
        {
            caja.DataSource = apa.Mostrar("").Tables["partida"];
            caja.DisplayMember = "fkcod_p";
            caja.ValueMember = "cod_p";
        }
        public Tuple<bool, string> ValidarUsuario(string uno, string dos, string tres)
        {
            bool error = true;
            string cadenaErrores = "";

            if (uno.Length == 0 || uno == null)
            {
                cadenaErrores = cadenaErrores + "El campo Color de ficha no puede ser vacio";
                error = false;
            }
            if (uno.Length > 19)
            {
                cadenaErrores = cadenaErrores + "Se sobrepaso el numero de caracteres";
                error = false;

            }
            if (dos.Length == 0 || dos == null)
            {
                cadenaErrores = cadenaErrores + "El campo Jugador no puede ser vacio";
                error = false;
            }

            if (dos == "0")
            {
                cadenaErrores = cadenaErrores + "Jugador debe ser mayor a 0";
                error = false;

            }
            if (tres.Length == 0 || tres == null)
            {
                cadenaErrores = cadenaErrores + "El campo Partida no puede ser vacio";
                error = false;
            }

            if (tres == "0")
            {
                cadenaErrores = cadenaErrores + "Partida debe ser mayor a 0";
                error = false;

            }

            var valida = new Tuple<bool, string>(error, cadenaErrores);
            return valida;
        }
    }
}
