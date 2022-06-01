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
    public class ManejadorSalas : IManejador
    {
        AccesoSalas asa = new AccesoSalas();
        AccesoHotel ah = new AccesoHotel();
        Grafico g = new Grafico();
        public void Borrar(dynamic Entidad)
        {
            DialogResult rs = MessageBox.Show(String.Format(String.Format(
            "Estas seguro de borrar: {0}", Entidad.Idsalas)
            ), "!Atencion",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
                    if (rs == DialogResult.Yes)
                        asa.Borrar(Entidad);
        }

        public void Exportar(DataGridView tabla)
        {
            throw new NotImplementedException();
        }

        public void Guardar(dynamic Entidad)
        {
            asa.Guardar(Entidad);
            g.Mensaje("Sala Guardada", "!Atencion",
                MessageBoxIcon.Information);
        }

        public void Mostrar(DataGridView tabla, string filtro)
        {
            tabla.Columns.Clear();
            tabla.RowTemplate.Height = 30;
            tabla.DataSource = asa.Mostrar(filtro).Tables["salas"];
            tabla.Columns.Insert(5, g.Boton(
                "Editar", Color.Green));
            tabla.Columns.Insert(6, g.Boton("Borrar", Color.Red));
            tabla.Columns[0].Visible = false;
        }
        public void ExtaerHotel(ComboBox caja)
        {
            caja.DataSource = ah.Mostrar("").Tables["hotel"];
            caja.DisplayMember = "Nombre";
            caja.ValueMember = "Idhotel";
        }
    }
}
