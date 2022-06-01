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
using Microsoft;
using System.IO;



using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace PresentacionAjedrez
{
    public partial class FrmMovimientos : Form
    {
        ManejadorMovimientos mm = new ManejadorMovimientos();
        public static Movimientos movimientos = new Movimientos(0,"","",0);
        public static string partidamo = "";
        int fila = 0, col = 0;
        public FrmMovimientos()
        {
            InitializeComponent();
            mm = new ManejadorMovimientos();
            CrearBoton();
            CrearBoton2();
        }

        private void dtgMovimientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (col)
            {
                case 4:
                    {
                        FrmMovimientosAdd mode = new FrmMovimientosAdd();
                        mode.ShowDialog();
                        txtBuscar.Text = "";
                        Actualizar();
                    }
                    break;
                case 5:
                    {
                        mm.Borrar(movimientos);
                        txtBuscar.Text = "";
                        Actualizar();
                    }
                    break;
            }
        }

        private void dtgMovimientos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            col = e.ColumnIndex;
            movimientos.Norden = int.Parse(dtgMovimientos.Rows[fila].
                Cells[0].Value.ToString());
            movimientos.Jugada = dtgMovimientos.Rows[fila].
                Cells[1].Value.ToString();
            movimientos.Comentario = dtgMovimientos.Rows[fila].
                Cells[2].Value.ToString();
            partidamo = dtgMovimientos.Rows[fila].
                Cells[3].Value.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            movimientos.Norden = -1;
            FrmMovimientosAdd mode = new FrmMovimientosAdd();
            mode.ShowDialog();
            Actualizar();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        void Actualizar()
        {
            mm.Mostrar(dtgMovimientos, txtBuscar.Text);
        }
        public void CrearBoton()
        {
            Button ButtonExcel = new Button();
            ButtonExcel.Text = "Excel";
            ButtonExcel.Width = 89;
            ButtonExcel.Height = 31;
            ButtonExcel.Location = new Point(937, 496);
            ButtonExcel.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            ButtonExcel.BackColor = Color.Green;
            ButtonExcel.Click += ButtonExcel_Click;
            this.Controls.Add(ButtonExcel);
        }

        private void ButtonExcel_Click(object sender, EventArgs e)
        {
            ExportarDatos(dtgMovimientos);
        }
        public void ExportarDatos(DataGridView dtgPais)
        {
            Microsoft.Office.Interop.Excel.Application exportarexcel = new Microsoft.Office.Interop.Excel.Application();
            exportarexcel.Application.Workbooks.Add(true);
            int indicecolumna = 0;
            foreach (DataGridViewColumn col in dtgPais.Columns)
            {
                indicecolumna++;
                exportarexcel.Cells[1, indicecolumna] = col.Name;
            }
            int indicefila = 0;
            foreach (DataGridViewRow fil in dtgPais.Rows)
            {
                indicefila++;
                indicecolumna = 0;
                foreach (DataGridViewColumn col in dtgPais.Columns)
                {
                    indicecolumna++;
                    exportarexcel.Cells[indicefila + 1, indicecolumna] = fil.Cells[col.Name].Value;
                }
            }
            exportarexcel.Visible = true;
        }
        public void CrearBoton2()
        {
            Button ButtonPdf = new Button();
            ButtonPdf.Text = "PDF";
            ButtonPdf.Width = 89;
            ButtonPdf.Height = 31;
            ButtonPdf.Location = new Point(840, 496);
            ButtonPdf.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            ButtonPdf.BackColor = Color.Red;
            ButtonPdf.Click += ButtonPdf_Click;
            this.Controls.Add(ButtonPdf);
        }

        private void FrmMovimientos_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void ButtonPdf_Click(object sender, EventArgs e)
        {
            Document documento = new Document(PageSize.A4);
            PdfWriter.GetInstance(documento, new FileStream(@"C:\Users\chino\Documents\Movimientos.pdf", FileMode.OpenOrCreate));
            documento.Open();

            Paragraph escuela = new Paragraph();
            escuela.Alignment = Element.ALIGN_CENTER;
            escuela.Font = FontFactory.GetFont("Arial", 12);
            escuela.Add("Instituto tecnologico Mario Molina Pasquel y Henríquez");
            documento.Add(escuela);

            Paragraph Titulo = new Paragraph();
            Titulo.Alignment = Element.ALIGN_CENTER;
            Titulo.Font = FontFactory.GetFont("Arial", 12);
            Titulo.Add("Reporte de paises movimientos");
            documento.Add(Titulo);


            documento.Add(Chunk.NEWLINE);

            PdfPTable tablaPais = new PdfPTable(3);
            tablaPais.WidthPercentage = 100;

            PdfPCell Jugada = new PdfPCell(new Phrase("Jugada"));
            Jugada.BorderWidth = 0;
            Jugada.BorderWidthBottom = 0.75f;

            PdfPCell Comentario = new PdfPCell(new Phrase("Comentario"));
            Comentario.BorderWidth = 0;
            Comentario.BorderWidthBottom = 0.75f;

            PdfPCell Fkcod_p = new PdfPCell(new Phrase("Partida"));
            Fkcod_p.BorderWidth = 0;
            Fkcod_p.BorderWidthBottom = 0.75f;

            tablaPais.AddCell(Jugada);
            tablaPais.AddCell(Comentario);
            tablaPais.AddCell(Fkcod_p);

            System.Diagnostics.Process.Start(@"C:\Users\chino\Documents\Movimientos.pdf");

            for (int i = 0; i < dtgMovimientos.RowCount; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    Jugada = new PdfPCell(new Phrase(dtgMovimientos.Rows[i].Cells[1].Value.ToString()));
                    Comentario = new PdfPCell(new Phrase(dtgMovimientos.Rows[i].Cells[2].Value.ToString()));
                    Fkcod_p = new PdfPCell(new Phrase(dtgMovimientos.Rows[i].Cells[3].Value.ToString()));
                    tablaPais.AddCell(Jugada);
                    tablaPais.AddCell(Comentario);
                    tablaPais.AddCell(Fkcod_p);
                }
            }
            documento.Add(tablaPais);
            documento.Close();
        }
    }
}
