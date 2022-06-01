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
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace PresentacionAjedrez
{
    public partial class FrmPartidasJugadas : Form
    {
        ManejadorPartidasJugadas mpj = new ManejadorPartidasJugadas();
        public static Partidasjugadas partidasjugadas = new Partidasjugadas(0, "", 0, 0);
        public static string partidapj = "";
        public static string jugadorespj = "";
        int fila = 0, col = 0;
        public FrmPartidasJugadas()
        {
            InitializeComponent();
            mpj = new ManejadorPartidasJugadas();
            CrearBoton();
            CrearBoton2();
        }
        private void dtgPartidasJugadas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (col)
            {
                case 4:
                    {
                        FrmPartidasJugadasAdd pjde = new FrmPartidasJugadasAdd();
                        pjde.ShowDialog();
                        txtBuscar.Text = "";
                        Actualizar();
                    }
                    break;
                case 5:
                    {
                        mpj.Borrar(partidasjugadas);
                        txtBuscar.Text = "";
                        Actualizar();
                    }
                    break;
            }
        }

        private void dtgPartidasJugadas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            col = e.ColumnIndex;
            partidasjugadas.Idjugada = int.Parse(dtgPartidasJugadas.Rows[fila].
                Cells[0].Value.ToString());
            partidasjugadas.Coloficha = dtgPartidasJugadas.Rows[fila].
                Cells[1].Value.ToString();
            partidapj = dtgPartidasJugadas.Rows[fila].
                Cells[2].Value.ToString();
            jugadorespj = dtgPartidasJugadas.Rows[fila].
                Cells[3].Value.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            partidasjugadas.Idjugada = -1;
            FrmPartidasJugadasAdd pjde = new FrmPartidasJugadasAdd();
            pjde.ShowDialog();
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

        private void FrmPartidasJugadas_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        void Actualizar()
        {
            mpj.Mostrar(dtgPartidasJugadas, txtBuscar.Text);
        }
        public void CrearBoton()
        {
            Button ButtonExcel = new Button();
            ButtonExcel.Text = "Excel";
            ButtonExcel.Width = 89;
            ButtonExcel.Height = 31;
            ButtonExcel.Location = new Point(821, 484);
            ButtonExcel.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            ButtonExcel.BackColor = Color.Green;
            ButtonExcel.Click += ButtonExcel_Click;
            this.Controls.Add(ButtonExcel);
        }
        public void CrearBoton2()
        {
            Button ButtonPdf = new Button();
            ButtonPdf.Text = "PDF";
            ButtonPdf.Width = 89;
            ButtonPdf.Height = 31;
            ButtonPdf.Location = new Point(703, 484);
            ButtonPdf.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            ButtonPdf.BackColor = Color.Red;
            ButtonPdf.Click += ButtonPdf_Click;
            this.Controls.Add(ButtonPdf);
        }

        private void ButtonPdf_Click(object sender, EventArgs e)
        {
            Document documento = new Document(PageSize.A4);
            PdfWriter.GetInstance(documento, new FileStream(@"C:\Users\chino\Documents\PartidasJugadas.pdf", FileMode.OpenOrCreate));
            documento.Open();

            Paragraph escuela = new Paragraph();
            escuela.Alignment = Element.ALIGN_CENTER;
            escuela.Font = FontFactory.GetFont("Arial", 12);
            escuela.Add("Instituto tecnologico Mario Molina Pasquel y Henríquez");
            documento.Add(escuela);

            Paragraph Titulo = new Paragraph();
            Titulo.Alignment = Element.ALIGN_CENTER;
            Titulo.Font = FontFactory.GetFont("Arial", 12);
            Titulo.Add("Reporte de paises participantes");
            documento.Add(Titulo);


            documento.Add(Chunk.NEWLINE);

            PdfPTable tablaPais = new PdfPTable(3);
            tablaPais.WidthPercentage = 100;

            PdfPCell ColorFicha = new PdfPCell(new Phrase("Color de Ficha"));
            ColorFicha.BorderWidth = 0;
            ColorFicha.BorderWidthBottom = 0.75f;

            PdfPCell Partida = new PdfPCell(new Phrase("Partida"));
            Partida.BorderWidth = 0;
            Partida.BorderWidthBottom = 0.75f;

            PdfPCell Ganador = new PdfPCell(new Phrase("Ganador"));
            Ganador.BorderWidth = 0;
            Ganador.BorderWidthBottom = 0.75f;

            tablaPais.AddCell(ColorFicha);
            tablaPais.AddCell(Partida);
            tablaPais.AddCell(Ganador);

            System.Diagnostics.Process.Start(@"C:\Users\chino\Documents\PartidasJugadas.pdf");

            for (int i = 0; i < dtgPartidasJugadas.RowCount; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    ColorFicha = new PdfPCell(new Phrase(dtgPartidasJugadas.Rows[i].Cells[1].Value.ToString()));
                    Partida = new PdfPCell(new Phrase(dtgPartidasJugadas.Rows[i].Cells[2].Value.ToString()));
                    Ganador = new PdfPCell(new Phrase(dtgPartidasJugadas.Rows[i].Cells[3].Value.ToString()));

                    tablaPais.AddCell(ColorFicha);
                    tablaPais.AddCell(Partida);
                    tablaPais.AddCell(Ganador);
                }
            }
            documento.Add(tablaPais);
            documento.Close();
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
        private void ButtonExcel_Click(object sender, EventArgs e)
        {
            ExportarDatos(dtgPartidasJugadas);
        }
    }
}
