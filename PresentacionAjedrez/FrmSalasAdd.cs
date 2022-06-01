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
    public partial class FrmSalasAdd : Form
    {
        ManejadorSalas ms;
        public FrmSalasAdd()
        {
            InitializeComponent();
            ms = new ManejadorSalas();
            ms.ExtaerHotel(cmbHotel);
            if (FrmSalas.salas.Idsalas > 0)
            {
                txtNentradas.Text = FrmSalas.salas.Nentradas.ToString() ;
                txtCapacidad.Text = FrmSalas.salas.Capacidad.ToString();
                txtMedio.Text = FrmSalas.salas.Medio;
                cmbHotel.Text = FrmSalas.hotels;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ms.Guardar(new Salas(FrmSalas.salas.Idsalas,
            int.Parse(txtNentradas.Text.ToString()),
            int.Parse(txtCapacidad.Text.ToString()),
            txtMedio.Text,
            int.Parse(cmbHotel.SelectedValue.ToString())
            ));
            Close();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
