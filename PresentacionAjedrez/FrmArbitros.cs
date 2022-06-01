using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.Windows.Forms;
using ManejadorAjedrez;
using EntidadAjedrez;
using System.IO;

namespace PresentacionAjedrez
{
    public partial class FrmArbitros : Form
    {
        ManejadorArbitros ma;
        public static Arbitros arbitros = new Arbitros(0,"","","",0,0);
        public static string paisa = "";
        int fila = 0, col = 0;
        public FrmArbitros()
        {
            InitializeComponent();
            ma = new ManejadorArbitros();
            CrearBoton();
            CrearBoton2();
        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtgArbitros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            arbitros.Nasociado = int.Parse(dtgArbitros.Rows[fila].
                Cells[0].Value.ToString());
            arbitros.Nombre = dtgArbitros.Rows[fila].
                Cells[1].Value.ToString();
            arbitros.Direccion = dtgArbitros.Rows[fila].
                Cells[2].Value.ToString();
            arbitros.Telefono = dtgArbitros.Rows[fila].
                Cells[3].Value.ToString();
            arbitros.Campeonatos = int.Parse(dtgArbitros.Rows[fila].
                Cells[4].Value.ToString());
            paisa = dtgArbitros.Rows[fila].Cells[5].Value.ToString();
            switch(col)
            {
                case 6: {
                        FrmArbitrosAdd arde = new FrmArbitrosAdd();
                        arde.ShowDialog();
                        Actualizar();
                    } break;
                case 7: {
                        ma.Borrar(arbitros);
                        Actualizar();
                    } break;
            }
        }

        private void dtgArbitros_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            col = e.ColumnIndex;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            arbitros.Nasociado = -1;
            FrmArbitrosAdd arde = new FrmArbitrosAdd();
            arde.ShowDialog();
            Actualizar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }


        void Actualizar()
        {
            ma.Mostrar(dtgArbitros, txtBuscar.Text);
        }
        public void CrearBoton()
        {
            Button ButtonExcel = new Button();
            ButtonExcel.Text = "Excel";
            ButtonExcel.Width = 99;
            ButtonExcel.Height = 39;
            ButtonExcel.Location = new Point(959, 513);
            ButtonExcel.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            ButtonExcel.BackColor = Color.Green;
            ButtonExcel.Click += ButtonExcel_Click;
            this.Controls.Add(ButtonExcel);
        }
        public void ExportarDatos(DataGridView dtgArbitros)
        {
            Microsoft.Office.Interop.Excel.Application exportarexcel = new Microsoft.Office.Interop.Excel.Application();
            exportarexcel.Application.Workbooks.Add(true);
            int indicecolumna = 0;
            foreach (DataGridViewColumn col in dtgArbitros.Columns)
            {
                indicecolumna++;
                exportarexcel.Cells[1, indicecolumna] = col.Name;
            }
            int indicefila = 0;
            foreach (DataGridViewRow fil in dtgArbitros.Rows)
            {
                indicefila++;
                indicecolumna = 0;
                foreach (DataGridViewColumn col in dtgArbitros.Columns)
                {
                    indicecolumna++;
                    exportarexcel.Cells[indicefila + 1, indicecolumna] = fil.Cells[col.Name].Value;
                }
            }
            exportarexcel.Visible = true;
        }
        private void ButtonExcel_Click(object sender, EventArgs e)
        {
            ExportarDatos(dtgArbitros);
        }
        public void CrearBoton2()
        {
            Button ButtonPdf = new Button();
            ButtonPdf.Text = "PDF";
            ButtonPdf.Width = 99;
            ButtonPdf.Height = 39;
            ButtonPdf.Location = new Point(800, 513);
            ButtonPdf.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            ButtonPdf.BackColor = Color.Red;
            ButtonPdf.Click += ButtonPdf_Click;
            this.Controls.Add(ButtonPdf);
        }

        private void FrmArbitros_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void ButtonPdf_Click(object sender, EventArgs e)
        {
            Document documento = new Document(PageSize.A4);
            PdfWriter.GetInstance(documento, new FileStream(@"C:\Users\chino\Documents\Arbitros.pdf", FileMode.OpenOrCreate));
            documento.Open();

            Paragraph escuela = new Paragraph();
            escuela.Alignment = Element.ALIGN_CENTER;
            escuela.Font = FontFactory.GetFont("Arial", 12);
            escuela.Add("Instituto tecnologico Mario Molina Pasquel y Henríquez");
            documento.Add(escuela);

            Paragraph Titulo = new Paragraph();
            Titulo.Alignment = Element.ALIGN_CENTER;
            Titulo.Font = FontFactory.GetFont("Arial", 12);
            Titulo.Add("Listado de Arbitros");
            documento.Add(Titulo);


            documento.Add(Chunk.NEWLINE);

            PdfPTable tablaPais = new PdfPTable(5);
            tablaPais.WidthPercentage = 100;

            PdfPCell nombre = new PdfPCell(new Phrase("Nombre"));
            nombre.BorderWidth = 0;
            nombre.BorderWidthBottom = 0.75f;

            PdfPCell direccion = new PdfPCell(new Phrase("Direccion"));
            direccion.BorderWidth = 0;
            direccion.BorderWidthBottom = 0.75f;

            PdfPCell telefono = new PdfPCell(new Phrase("Telefono"));
            telefono.BorderWidth = 0;
            telefono.BorderWidthBottom = 0.75f;

            PdfPCell campeonato = new PdfPCell(new Phrase("Campeonatos"));
            campeonato.BorderWidth = 0;
            campeonato.BorderWidthBottom = 0.75f;

            PdfPCell FkNc = new PdfPCell(new Phrase("Pais"));
            FkNc.BorderWidth = 0;
            FkNc.BorderWidthBottom = 0.75f;

            tablaPais.AddCell(nombre);
            tablaPais.AddCell(direccion);
            tablaPais.AddCell(telefono);
            tablaPais.AddCell(campeonato);
            tablaPais.AddCell(FkNc);

            System.Diagnostics.Process.Start(@"C:\Users\chino\Documents\Arbitros.pdf");

            for (int i = 0; i < dtgArbitros.RowCount; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    nombre = new PdfPCell(new Phrase(dtgArbitros.Rows[i].Cells[1].Value.ToString()));
                    direccion = new PdfPCell(new Phrase(dtgArbitros.Rows[i].Cells[2].Value.ToString()));
                    telefono = new PdfPCell(new Phrase(dtgArbitros.Rows[i].Cells[3].Value.ToString()));
                    campeonato = new PdfPCell(new Phrase(dtgArbitros.Rows[i].Cells[4].Value.ToString()));
                    FkNc = new PdfPCell(new Phrase(dtgArbitros.Rows[i].Cells[5].Value.ToString()));

                    tablaPais.AddCell(nombre);
                    tablaPais.AddCell(direccion);
                    tablaPais.AddCell(telefono);
                    tablaPais.AddCell(campeonato);
                    tablaPais.AddCell(FkNc);
                }
            }
            documento.Add(tablaPais);
            documento.Close();
        }
    }
}
