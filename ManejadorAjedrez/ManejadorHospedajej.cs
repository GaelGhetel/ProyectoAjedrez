﻿using System;
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
    public class ManejadorHospedajej : IManejador
    {
        AccesoHospedajej ahj = new AccesoHospedajej();
        AccesoJugadores aj = new AccesoJugadores();
        AccesoHotel ah = new AccesoHotel();
        Grafico g = new Grafico();
        public void Borrar(dynamic Entidad)
        {
            DialogResult rs = MessageBox.Show(String.Format(String.Format(
            "Estas seguro de borrar: {0}", Entidad.Idhospedajej)
            ), "!Atencion",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
                    if (rs == DialogResult.Yes)
                        ahj.Borrar(Entidad);
        }

        public void Exportar(DataGridView tabla)
        {
            throw new NotImplementedException();
        }

        public void Guardar(dynamic Entidad)
        {
            ahj.Guardar(Entidad);
            g.Mensaje("Hospedaje Guardado", "!Atención",
            MessageBoxIcon.Information);
        }

        public void Mostrar(DataGridView tabla, string filtro)
        {
            tabla.Columns.Clear();
            tabla.RowTemplate.Height = 30;
            tabla.DataSource = ahj.Mostrar(filtro).Tables["hospedajej"];
            tabla.Columns.Insert(5, g.Boton(
                "Editar", Color.Green));
            tabla.Columns.Insert(6, g.Boton(
                "Borrar", Color.Red));
            tabla.Columns[0].Visible = false;
        }
        public void ExtaerJugadores(ComboBox caja)
        {
            caja.DataSource = aj.Mostrar("").Tables["jugadores"];
            caja.DisplayMember = "Nombre";
            caja.ValueMember = "Numasociado";
        }
        public void ExtaerHotel(ComboBox caja)
        {
            caja.DataSource = ah.Mostrar("").Tables["hotel"];
            caja.DisplayMember = "Nombre";
            caja.ValueMember = "Idhotel";
        }
        public Tuple<bool, string> ValidarUsuario(string uno, string dos, string tres, string cuatro)
        {
            bool error = true;
            string cadenaErrores = "";
            if (uno.Length == 0 || uno == null)
            {
                cadenaErrores = cadenaErrores + "El campo fecha de entrada no puede ser vacio";
                error = false;
            }
            if (uno.Length > 19)
            {
                cadenaErrores = cadenaErrores + "Se sobrepaso el numero de caracteres";
                error = false;

            }
            if (dos.Length == 0 || dos == null)
            {
                cadenaErrores = cadenaErrores + "El campo fecha de salida no puede ser vacio";
                error = false;
            }
            if (dos.Length > 19)
            {
                cadenaErrores = cadenaErrores + "Se sobrepaso el numero de caracteres";
                error = false;

            }
            if (tres.Length == 0 || tres == null)
            {
                cadenaErrores = cadenaErrores + "El campo Arbitro no puede ser vacio";
                error = false;
            }

            if (tres == "0")
            {
                cadenaErrores = cadenaErrores + "Jugador debe ser mayor a 0";
                error = false;

            }
            if (cuatro.Length == 0 || cuatro == null)
            {
                cadenaErrores = cadenaErrores + "El campo Hotel no puede ser vacio";
                error = false;
            }

            if (cuatro == "0")
            {
                cadenaErrores = cadenaErrores + "Hotel debe ser mayor a 0";
                error = false;

            }

            var valida = new Tuple<bool, string>(error, cadenaErrores);
            return valida;
        }
    }
}
