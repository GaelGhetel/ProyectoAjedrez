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
    public partial class FrmHotel : Form
    {
        ManejadorHotel mh;
        public static Hotel hotel = new Hotel(0, "", "","");
        int fila = 0, col = 0;
        public FrmHotel()
        {
            InitializeComponent();
            mh = new ManejadorHotel();
        }
        private void dtgHotel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (col)
            {
                case 4:
                    {
                        FrmHotelAdd hode = new FrmHotelAdd();
                        hode.ShowDialog();
                        txtBuscar.Text = "";
                        Actualizar();
                    }
                    break;
                case 5:
                    {
                        mh.Borrar(hotel);
                        txtBuscar.Text = "";
                        Actualizar();
                    }
                    break;
            }
        }

        private void dtgHotel_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            col = e.ColumnIndex;
            hotel.Idhotel = int.Parse(dtgHotel.Rows[fila]
                .Cells[0].Value.ToString());
            hotel.Nombre = dtgHotel.Rows[fila]
                .Cells[1].Value.ToString();
            hotel.Direccion = dtgHotel.Rows[fila]
                .Cells[2].Value.ToString();
            hotel.Telefono = dtgHotel.Rows[fila].
                Cells[3].Value.ToString();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            hotel.Idhotel = -1;
            FrmHotelAdd hode = new FrmHotelAdd();
            hode.ShowDialog();
            Actualizar();
        }

        private void FrmHotel_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        void Actualizar()
        {
            mh.Mostrar(dtgHotel, txtBuscar.Text);
        }
    }
}
