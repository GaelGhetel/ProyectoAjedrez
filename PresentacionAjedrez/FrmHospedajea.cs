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
    public partial class FrmHospedajea : Form
    {
        ManejadorHospedajea mha;
        public static Hospedajea hospedajea = new Hospedajea(0, "", "", 0, 0);
        public static string hotela = "";
        public static string arbitrosa = "";
        int fila = 0, col = 0;
        public FrmHospedajea()
        {
            InitializeComponent();
            mha = new ManejadorHospedajea();
        }
        private void dtgHospedajea_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (col)
            {
                case 5:
                    {
                        FrmHospedajeaAdd hade = new FrmHospedajeaAdd();
                        hade.ShowDialog();
                        txtBuscar.Text = "";
                        Actualizar();
                    }
                    break;
                case 6:
                    {
                        mha.Borrar(hospedajea);
                        txtBuscar.Text = "";
                        Actualizar();
                    }
                    break;
            }
        }

        private void dtgHospedajea_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            col = e.ColumnIndex;
            hospedajea.Idhospedajea = int.Parse(dtgHospedajea.Rows[fila].
                Cells[0].Value.ToString());
            hospedajea.Fechallegada = dtgHospedajea.Rows[fila].
                Cells[1].Value.ToString();
            hospedajea.Fechasalida = dtgHospedajea.Rows[fila].
                Cells[2].Value.ToString();
            hotela = dtgHospedajea.Rows[fila].
                Cells[3].Value.ToString();
            arbitrosa = dtgHospedajea.Rows[fila].
                Cells[4].Value.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            hospedajea.Idhospedajea = -1;
            FrmHospedajeaAdd hade = new FrmHospedajeaAdd();
            hade.ShowDialog();
            Actualizar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmHospedajea_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        void Actualizar()
        {
            mha.Mostrar(dtgHospedajea, txtBuscar.Text);
        }

    }
}
