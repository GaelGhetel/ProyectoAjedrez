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
    public partial class FrmHotelAdd : Form
    {
        ManejadorHotel mh;
        public FrmHotelAdd()
        {
            InitializeComponent();
            mh = new ManejadorHotel();
            if (FrmHotel.hotel.Idhotel > 0)
            {
                txtNombre.Text = FrmHotel.hotel.Nombre;
                txtDireccion.Text = FrmHotel.hotel.Direccion;
                txtTelefono.Text = FrmHotel.hotel.Telefono;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var valida = mh.ValidarUsuario(txtNombre.Text, txtDireccion.Text, txtTelefono.Text);
            if (valida.Item1)
            {
                mh.Guardar(new Hotel(FrmHotel.hotel.Idhotel,
                txtNombre.Text, txtDireccion.Text, txtTelefono.Text));
                Close();
            }
            else
            {
                MessageBox.Show(valida.Item2, "Ocurrio un error", MessageBoxButtons.OK);
            }
        }
    }
}
