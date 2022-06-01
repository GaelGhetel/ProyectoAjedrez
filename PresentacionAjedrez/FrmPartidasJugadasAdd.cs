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
    public partial class FrmPartidasJugadasAdd : Form
    {
        ManejadorPartidasJugadas mpj;
        public FrmPartidasJugadasAdd()
        {
            InitializeComponent();
            mpj = new ManejadorPartidasJugadas();
            mpj.ExtaerPartida(cmbFkcod_p);
            mpj.ExtaerJugadores(cmbJugadores);
            if (FrmPartidasJugadas.partidasjugadas.Idjugada > 0)
            {
                cmbColoficha.Text = FrmPartidasJugadas.partidasjugadas.Coloficha;
                cmbFkcod_p.Text = FrmPartidasJugadas.partidapj;
                cmbJugadores.Text = FrmPartidasJugadas.jugadorespj;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var valida =mpj.ValidarUsuario(cmbColoficha.Text, cmbJugadores.Text, cmbFkcod_p.Text);
            if (valida.Item1)
            {
                mpj.Guardar(new Partidasjugadas(FrmPartidasJugadas.partidasjugadas.Idjugada,
                 cmbColoficha.Text,
                 int.Parse(cmbFkcod_p.SelectedValue.ToString()),
                 int.Parse(cmbJugadores.SelectedValue.ToString())
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
