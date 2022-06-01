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
    public class ManejadorPartida : IManejador
    {
        AccesoPartida apt = new AccesoPartida();
        AccesoJugadores aj = new AccesoJugadores();
        AccesoArbitros aa = new AccesoArbitros();
        AccesoSalas asa = new AccesoSalas();
        Grafico g = new Grafico();
        public void Borrar(dynamic Entidad)
        {
            DialogResult rs = MessageBox.Show(String.Format(String.Format(
            "Estas seguro de borrar: {0}", Entidad.Cod_p)
            ), "!Atencion",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
                        if (rs == DialogResult.Yes)
                            apt.Borrar(Entidad);
        }

        public void Exportar(DataGridView tabla)
        {
            throw new NotImplementedException();
        }

        public void Guardar(dynamic Entidad)
        {
            apt.Guardar(Entidad);
            g.Mensaje("Partida Guardada", "!Atención",
            MessageBoxIcon.Information);
        }

        public void Mostrar(DataGridView tabla, string filtro)
        {
            tabla.Columns.Clear();
            tabla.RowTemplate.Height = 30;
            tabla.DataSource = apt.Mostrar(filtro).Tables["partida"];
            tabla.Columns.Insert(6, g.Boton(
                "Editar", Color.Green));
            tabla.Columns.Insert(7, g.Boton(
                "Borrar", Color.Red));
            tabla.Columns[0].Visible = false;
        }
        public void ExtaerJugadores(ComboBox caja)
        {
            caja.DataSource = aj.Mostrar("").Tables["jugadores"];
            caja.DisplayMember = "Nombre";
            caja.ValueMember = "Numasociado";
        }
        public void ExtaerArbitros(ComboBox caja)
        {
            caja.DataSource = aa.Mostrar("").Tables["arbitros"];
            caja.DisplayMember = "Nombre";
            caja.ValueMember = "Nasociado";
        }
        public void ExtaerSalas(ComboBox caja)
        {
            caja.DataSource = asa.Mostrar("").Tables["salas"];
            caja.DisplayMember = "Nombre";
            caja.ValueMember = "Idsalas";
        }
        public Tuple<bool, string> ValidarUsuario(string uno, string dos, string tres, string cuatro, string cinco)
        {
            bool error = true;
            string cadenaErrores = "";
            if (uno.Length == 0 || uno == null)
            {
                cadenaErrores = cadenaErrores + "El campo Jugador Izquierdo no puede ser vacio";
                error = false;
            }

            if (uno == "0")
            {
                cadenaErrores = cadenaErrores + "Jugador Izquierdo debe ser mayor a 0";
                error = false;

            }
            if (dos.Length == 0 || dos == null)
            {
                cadenaErrores = cadenaErrores + "El campo Jugador derecho no puede ser vacio";
                error = false;
            }

            if (dos == "0")
            {
                cadenaErrores = cadenaErrores + "Jugador Derecho debe ser mayor a 0";
                error = false;

            }
            if (tres.Length == 0 || tres == null)
            {
                cadenaErrores = cadenaErrores + "El campo Arbitro no puede ser vacio";
                error = false;
            }

            if (tres == "0")
            {
                cadenaErrores = cadenaErrores + "Arbitro debe ser mayor a 0";
                error = false;

            }
            if (cuatro.Length == 0 || cuatro == null)
            {
                cadenaErrores = cadenaErrores + "El campo Jornada no puede ser vacio";
                error = false;
            }
            if (cuatro.Length > 19)
            {
                cadenaErrores = cadenaErrores + "Se sobrepaso el numero de caracteres";
                error = false;

            }
            if (cinco.Length == 0 || cinco == null)
            {
                cadenaErrores = cadenaErrores + "El campo Sala no puede ser vacio";
                error = false;
            }

            if (cinco == "0")
            {
                cadenaErrores = cadenaErrores + "Sala debe ser mayor a 0";
                error = false;

            }

            var valida = new Tuple<bool, string>(error, cadenaErrores);
            return valida;
        }
    }
}
