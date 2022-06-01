using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntidadAjedrez;
using ManejadorAjedrez;

namespace PresentacionAjedrez
{
    public partial class FrmMovimientosAdd : Form
    {
        ManejadorMovimientos mm;
        public FrmMovimientosAdd()
        {
            InitializeComponent();
            mm = new ManejadorMovimientos();
            mm.ExtaerPartida(cmbPartida);
            if (FrmMovimientos.movimientos.Norden > 0)
            {
                txtJugada.Text = FrmMovimientos.movimientos.Jugada;
                txtComentario.Text = FrmMovimientos.movimientos.Comentario;
                cmbPartida.Text = FrmMovimientos.partidamo;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var valida = mm.ValidarUsuario(txtJugada.Text, cmbPartida.Text, txtJugada.Text);
            if (valida.Item1)
            {
                mm.Guardar(new Movimientos(FrmMovimientos.movimientos.Norden,
                   txtJugada.Text,
                   txtComentario.Text,
                   int.Parse(cmbPartida.SelectedValue.ToString())
                      ));
                Close();
            }
            else
            {
                MessageBox.Show(valida.Item2, "Ocurrio un error", MessageBoxButtons.OK);
            }
        }
    }
}
