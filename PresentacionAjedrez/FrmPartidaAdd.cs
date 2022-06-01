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
    public partial class FrmPartidaAdd : Form
    {
        ManejadorPartida mpa;
        public FrmPartidaAdd()
        {
            InitializeComponent();
            mpa = new ManejadorPartida();
            mpa.ExtaerJugadores(cmbFknumasociado);
            mpa.ExtaerJugadores(cmbFknumasociado2);
            mpa.ExtaerArbitros(cmbArbitro);
            
            mpa.ExtaerSalas(cmbSalas);
            if (FrmPartida.partida.Cod_p > 0)
            {
                cmbFknumasociado.Text = FrmPartida.jugadoresp;
                cmbFknumasociado2.Text = FrmPartida.jugadoresp2;
                cmbArbitro.Text = FrmPartida.arbitrosp;
                txtJornada.Text = FrmPartida.partida.Jornada;
                cmbSalas.Text = FrmPartida.salasp;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           var valida= mpa.ValidarUsuario(cmbFknumasociado.Text, cmbFknumasociado2.Text, cmbArbitro.Text, txtJornada.Text, cmbSalas.Text);
            if (valida.Item1)
            {
                mpa.Guardar(new Partida(FrmPartida.partida.Cod_p,
                int.Parse(cmbFknumasociado.SelectedValue.ToString()),
                int.Parse(cmbFknumasociado2.SelectedValue.ToString()),
                int.Parse(cmbArbitro.SelectedValue.ToString()),
                txtJornada.Text,
                int.Parse(cmbSalas.SelectedValue.ToString())
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
