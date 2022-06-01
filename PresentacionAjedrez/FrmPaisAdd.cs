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
    public partial class FrmPaisAdd : Form
    {
        ManejadorPais mp;
        ManejadorPais _mp;
        public FrmPaisAdd()
        {
            InitializeComponent();
            mp = new ManejadorPais();
            if(FrmPais.paises.Ncorrelativo>0)
            {
                txtNombre.Text = FrmPais.paises.Nombre;
                txtNclubes.Text = FrmPais.paises.Nclubes.ToString();
            }
            _mp = new ManejadorPais();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            var validar = mp.ValidarUsuario(txtNombre.Text, txtNclubes.Text);
            if(validar.Item1)
            { 
            mp.Guardar(new Pais(FrmPais.paises.Ncorrelativo,
                txtNombre.Text, int.Parse(txtNclubes.Text)));
                Close();
            }
            else
            {
                MessageBox.Show(validar.Item2, "Ocurrio un error", MessageBoxButtons.OK);
            }

            
        }
    }
}
