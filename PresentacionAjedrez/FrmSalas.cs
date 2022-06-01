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
    public partial class FrmSalas : Form
    {
        ManejadorSalas ms;
        public static Salas salas = new Salas(0,0,0,"",0);
        public static string hotels = "";
        int fila = 0, col = 0;
        public FrmSalas()
        {
            InitializeComponent();
            ms = new ManejadorSalas();
        }
        private void dtgSalas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (col)
            {
                case 5:
                    {
                        FrmSalasAdd sade = new FrmSalasAdd();
                        sade.ShowDialog();
                        txtBuscar.Text = "";
                        Actualizar();
                    }
                    break;
                case 6:
                    {
                        ms.Borrar(salas);
                        txtBuscar.Text = "";
                        Actualizar();
                    }
                    break;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtgSalas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            col = e.ColumnIndex;
            salas.Idsalas = int.Parse(dtgSalas.Rows[fila]
                .Cells[0].Value.ToString());
            salas.Nentradas = int.Parse(dtgSalas.Rows[fila]
                .Cells[1].Value.ToString());
            salas.Capacidad = int.Parse(dtgSalas.Rows[fila]
                .Cells[2].Value.ToString());
            salas.Medio = dtgSalas.Rows[fila].
                Cells[3].Value.ToString();
            hotels = dtgSalas.Rows[fila].Cells[4].Value.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            salas.Idsalas = -1;
            FrmSalasAdd sade = new FrmSalasAdd();
            sade.ShowDialog();
            Actualizar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void FrmSalas_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        void Actualizar()
        {
            ms.Mostrar(dtgSalas, txtBuscar.Text);
        }
    }
}
