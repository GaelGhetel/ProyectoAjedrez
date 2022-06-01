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
    public partial class FrmHospedajejAdd : Form
    {
        ManejadorHospedajej mhj;
        public FrmHospedajejAdd()
        {
            InitializeComponent();
            mhj = new ManejadorHospedajej();
            mhj.ExtaerJugadores(cmbJugadores);
            mhj.ExtaerHotel(cmbHotel);
            if (FrmHospedajej.hospedajej.Idhospedajej > 0)
            {
                txtFechallegada.Text = FrmHospedajej.hospedajej.Fechallegada;
                txtFechasalida.Text = FrmHospedajej.hospedajej.Fechasalida;
                cmbJugadores.Text = FrmHospedajej.jugadoresj;
                cmbHotel.Text = FrmHospedajej.hotelj;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var valida = mhj.ValidarUsuario(txtFechallegada.Text, txtFechasalida.Text, cmbHotel.Text, cmbJugadores.Text);
            if (valida.Item1)
            {
                mhj.Guardar(new Hospedajej(FrmHospedajej.hospedajej.Idhospedajej,
                 txtFechallegada.Text,
                 txtFechasalida.Text,
                 int.Parse(cmbJugadores.SelectedValue.ToString()),
                 int.Parse(cmbHotel.SelectedValue.ToString())
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
