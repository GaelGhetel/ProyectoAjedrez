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
    public partial class FrmPartida : Form
    {
        ManejadorPartida mpa;
        public static Partida partida = new Partida(0,0,0,0,"",0);
        public static string arbitrosp = "";
        public static string jugadoresp = "";
        public static string jugadoresp2 = "";
        public static string salasp = "";
        int fila = 0, col = 0;
        public FrmPartida()
        {
            InitializeComponent();
            mpa = new ManejadorPartida();
            CrearBoton();
            CrearBoton2();
        }

        private void dtgPartida_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            col = e.ColumnIndex;
            partida.Cod_p = int.Parse(dtgPartida.Rows[fila].
                Cells[0].Value.ToString());
            jugadoresp = dtgPartida.Rows[fila].
                Cells[1].Value.ToString();
            jugadoresp2 = dtgPartida.Rows[fila].
                Cells[2].Value.ToString();
            arbitrosp = dtgPartida.Rows[fila].
                Cells[3].Value.ToString();
            partida.Jornada = dtgPartida.Rows[fila].
                Cells[4].Value.ToString();
            salasp = dtgPartida.Rows[fila].
                Cells[5].Value.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            partida.Cod_p = -1;
            FrmPartidaAdd parde = new FrmPartidaAdd();
            parde.ShowDialog();
            Actualizar();
        }

        private void dtgPartida_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (col)
            {
                case 6:
                    {
                        FrmPartidaAdd parde = new FrmPartidaAdd();
                        parde.ShowDialog();
                        txtBuscar.Text = "";
                        Actualizar();
                    }
                    break;
                case 7:
                    {
                        mpa.Borrar(partida);
                        txtBuscar.Text = "";
                        Actualizar();
                    }
                    break;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        void Actualizar()
        {
            mpa.Mostrar(dtgPartida, txtBuscar.Text);
        }
        public void CrearBoton()
        {
            Button ButtonExcel = new Button();
            ButtonExcel.Text = "Excel";
            ButtonExcel.Width = 96;
            ButtonExcel.Height = 39;
            ButtonExcel.Location = new Point(981, 494);
            ButtonExcel.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            ButtonExcel.BackColor = Color.Green;
            ButtonExcel.Click += ButtonExcel_Click;
            this.Controls.Add(ButtonExcel);
        }

        private void ButtonExcel_Click(object sender, EventArgs e)
        {
            ExportarDatos(dtgPartida);
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
            ButtonPdf.Location = new Point(843, 494);
            ButtonPdf.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            ButtonPdf.BackColor = Color.Red;
            ButtonPdf.Click += ButtonPdf_Click;
            this.Controls.Add(ButtonPdf);
        }

        private void FrmPartida_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void ButtonPdf_Click(object sender, EventArgs e)
        {
            Document documento = new Document(PageSize.A4);
            PdfWriter.GetInstance(documento, new FileStream(@"C:\Users\chino\Documents\Partida.pdf", FileMode.OpenOrCreate));
            documento.Open();

            Paragraph escuela = new Paragraph();
            escuela.Alignment = Element.ALIGN_CENTER;
            escuela.Font = FontFactory.GetFont("Arial", 12);
            escuela.Add("Instituto tecnologico Mario Molina Pasquel y Henríquez");
            documento.Add(escuela);

            Paragraph Titulo = new Paragraph();
            Titulo.Alignment = Element.ALIGN_CENTER;
            Titulo.Font = FontFactory.GetFont("Arial", 12);
            Titulo.Add("Reporte de paises partida");
            documento.Add(Titulo);

            documento.Add(Chunk.NEWLINE);

            PdfPTable tablaPais = new PdfPTable(5);
            tablaPais.WidthPercentage = 100;

            PdfPCell Fknumasociado = new PdfPCell(new Phrase("Jugador 1"));
            Fknumasociado.BorderWidth = 0;
            Fknumasociado.BorderWidthBottom = 0.75f;

            PdfPCell Fknumasociado2 = new PdfPCell(new Phrase("Jugador 2"));
            Fknumasociado2.BorderWidth = 0;
            Fknumasociado2.BorderWidthBottom = 0.75f;

            PdfPCell Fknasociado = new PdfPCell(new Phrase("Arbitro"));
            Fknasociado.BorderWidth = 0;
            Fknasociado.BorderWidthBottom = 0.75f;


            PdfPCell Jornada = new PdfPCell(new Phrase("Jornada"));
            Jornada.BorderWidth = 0;
            Jornada.BorderWidthBottom = 0.75f;

            PdfPCell Fkidsalas = new PdfPCell(new Phrase("Sala"));
            Fkidsalas.BorderWidth = 0;
            Fkidsalas.BorderWidthBottom = 0.75f;

            tablaPais.AddCell(Fknumasociado);
            tablaPais.AddCell(Fknumasociado2);
            tablaPais.AddCell(Fknasociado);
            tablaPais.AddCell(Jornada);
            tablaPais.AddCell(Fkidsalas);

            System.Diagnostics.Process.Start(@"C:\Users\chino\Documents\Partida.pdf");

            for (int i = 0; i < dtgPartida.RowCount; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    Fknumasociado = new PdfPCell(new Phrase(dtgPartida.Rows[i].Cells[1].Value.ToString()));
                    Fknumasociado2 = new PdfPCell(new Phrase(dtgPartida.Rows[i].Cells[2].Value.ToString()));
                    Fknasociado = new PdfPCell(new Phrase(dtgPartida.Rows[i].Cells[3].Value.ToString()));
                    Jornada = new PdfPCell(new Phrase(dtgPartida.Rows[i].Cells[4].Value.ToString()));
                    Fkidsalas = new PdfPCell(new Phrase(dtgPartida.Rows[i].Cells[5].Value.ToString()));
                    tablaPais.AddCell(Fknumasociado);
                    tablaPais.AddCell(Fknumasociado2);
                    tablaPais.AddCell(Fknasociado);
                    tablaPais.AddCell(Jornada);
                    tablaPais.AddCell(Fkidsalas);
                }
            }
            documento.Add(tablaPais);
            documento.Close();
        }
    }
}
