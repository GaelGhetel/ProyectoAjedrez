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
    public partial class FrmHospedajej : Form
    {
        ManejadorHospedajej mhj;
        public static Hospedajej hospedajej = new Hospedajej(0,"","",0,0);
        public static string hotelj= "";
        public static string jugadoresj = "";
        int fila = 0, col = 0;
        public FrmHospedajej()
        {
            InitializeComponent();
            mhj = new ManejadorHospedajej();
        }

        private void dtgHospedajej_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (col)
            {
                case 5:
                    {
                        FrmHospedajejAdd hjde = new FrmHospedajejAdd();
                        hjde.ShowDialog();
                        txtBuscar.Text = "";
                        Actualizar();
                    }
                    break;
                case 6:
                    {
                        mhj.Borrar(hospedajej);
                        txtBuscar.Text = "";
                        Actualizar();
                    }
                    break;
            }
        }

        private void dtgHospedajej_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            col = e.ColumnIndex;
            hospedajej.Idhospedajej = int.Parse(dtgHospedajej.Rows[fila].
                Cells[0].Value.ToString());
            hospedajej.Fechallegada = dtgHospedajej.Rows[fila].
                Cells[1].Value.ToString();
            hospedajej.Fechasalida = dtgHospedajej.Rows[fila].
                Cells[2].Value.ToString();
            hotelj = dtgHospedajej.Rows[fila].
                Cells[3].Value.ToString();
            jugadoresj = dtgHospedajej.Rows[fila].
                Cells[4].Value.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            hospedajej.Idhospedajej = -1;
            FrmHospedajejAdd hjde = new FrmHospedajejAdd();
            hjde.ShowDialog();
            Actualizar();
        }
        void Actualizar()
        {
            mhj.Mostrar(dtgHospedajej, txtBuscar.Text);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void FrmHospedajej_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
