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
    public partial class FrmJugadoresAdd : Form
    {
        ManejadorJugadores mj;
        public FrmJugadoresAdd()
        {
            InitializeComponent();
            mj = new ManejadorJugadores();
            mj.ExtaerPais(cmbPais);
            if(FrmJugadores.jugadores.Numasociado>0)
            {
                txtNombre.Text = FrmJugadores.jugadores.Nombre;
                txtDireccion.Text = FrmJugadores.jugadores.Direccion;
                txtTelefono.Text = FrmJugadores.jugadores.Telefono;
                txtCampeonatos.Text = FrmJugadores.jugadores.Campeonatos.ToString();
                cmbNiveljuego.Text = FrmJugadores.jugadores.Niveljuego.ToString();
                cmbPais.Text = FrmJugadores.paisj;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var valida = mj.ValidarUsuario(txtNombre.Text, txtDireccion.Text, txtTelefono.Text, txtCampeonatos.Text, cmbPais.Text, cmbNiveljuego.Text);
            if (valida.Item1)
            {
                mj.Guardar(new Jugadores(FrmJugadores.jugadores.Numasociado,
                    txtNombre.Text,
                    txtDireccion.Text,
                    txtTelefono.Text,
                    int.Parse(txtCampeonatos.Text),
                    int.Parse(cmbNiveljuego.Text),
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

        private void FrmJugadoresAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
