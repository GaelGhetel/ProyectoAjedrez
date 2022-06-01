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
    public partial class FrmHospedajeaAdd : Form
    {
        ManejadorHospedajea mha;
        public FrmHospedajeaAdd()
        {
            InitializeComponent();
            mha = new ManejadorHospedajea();
            mha.ExtaerArbitros(cmbArbitros);
            mha.ExtaerHotel(cmbHotel);
            if (FrmHospedajea.hospedajea.Idhospedajea > 0)
            {
                txtFechallegada.Text = FrmHospedajea.hospedajea.Fechallegada;
                txtFechasalida.Text = FrmHospedajea.hospedajea.Fechasalida;
                cmbArbitros.Text = FrmHospedajea.arbitrosa;
                cmbHotel.Text = FrmHospedajea.hotela;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var valida = mha.ValidarUsuario(txtFechallegada.Text, txtFechasalida.Text, cmbArbitros.Text, cmbHotel.Text);
            if (valida.Item1)
            {
                mha.Guardar(new Hospedajea(FrmHospedajea.hospedajea.Idhospedajea,
                 txtFechallegada.Text,
                 txtFechasalida.Text,
                 int.Parse(cmbArbitros.SelectedValue.ToString()),
                 int.Parse(cmbHotel.SelectedValue.ToString())
                    ));
                Close();
            }
            else
            {
                MessageBox.Show(valida.Item2,"Ocurrio un error", MessageBoxButtons.OK);
            }
        }
    }
}
