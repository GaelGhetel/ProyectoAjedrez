using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManejadorAjedrez;
using EntidadAjedrez;

namespace PresentacionAjedrez
{
    public partial class FrmArbitrosAdd : Form
    {
        ManejadorArbitros ma;
        public FrmArbitrosAdd()
        {
            InitializeComponent();
            ma = new ManejadorArbitros();
            ma.ExtaerPais(cmbPais);
            if (FrmArbitros.arbitros.Nasociado > 0)
            {
                txtNombre.Text = FrmArbitros.arbitros.Nombre;
                txtDireccion.Text = FrmArbitros.arbitros.Direccion;
                txtTelefono.Text = FrmArbitros.arbitros.Telefono;
                txtCampeonatos.Text = FrmArbitros.arbitros.Campeonatos.ToString();
                cmbPais.Text = FrmArbitros.paisa;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var valida=ma.ValidarUsuario(txtNombre.Text, txtDireccion.Text, txtTelefono.Text, txtCampeonatos.Text, cmbPais.Text);
            if (valida.Item1)
            {
                ma.Guardar(new Arbitros(FrmArbitros.arbitros.Nasociado,
                txtNombre.Text,
                txtDireccion.Text,
                txtTelefono.Text,
                int.Parse(txtCampeonatos.Text),
                int.Parse(cmbPais.SelectedValue.ToString())
                ));
                Close();
            }
            else
            {
                MessageBox.Show(valida.Item2, "Ocurrio un error", MessageBoxButtons.OK);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
