using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionAjedrez
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void optSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void optPais_Click(object sender, EventArgs e)
        {
            FrmPais p = new FrmPais();
            p.ShowDialog();
        }

        private void optJugadores_Click(object sender, EventArgs e)
        {
            FrmJugadores j = new FrmJugadores();
            j.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmArbitros a = new FrmArbitros();
            a.ShowDialog();
        }

        private void optHotel_Click(object sender, EventArgs e)
        {
            FrmHotel h = new FrmHotel();
            h.ShowDialog();
        }

        private void optHospedajej_Click(object sender, EventArgs e)
        {
            FrmHospedajej hj = new FrmHospedajej();
            hj.ShowDialog();
        }

        private void optHospedajea_Click(object sender, EventArgs e)
        {
            FrmHospedajea ha = new FrmHospedajea();
            ha.ShowDialog();
        }

        private void optSalas_Click(object sender, EventArgs e)
        {
            FrmSalas fs = new FrmSalas();
            fs.ShowDialog();
        }

        private void optPartida_Click(object sender, EventArgs e)
        {
            FrmPartida fpar = new FrmPartida();
            fpar.ShowDialog();
        }

        private void optPartidasjugadas_Click(object sender, EventArgs e)
        {
            FrmPartidasJugadas fpar = new FrmPartidasJugadas();
            fpar.ShowDialog();
        }

        private void optMovimientos_Click(object sender, EventArgs e)
        {
            FrmMovimientos fm = new FrmMovimientos();
            fm.ShowDialog();
        }
    }
}
