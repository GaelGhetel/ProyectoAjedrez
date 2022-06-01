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
    public partial class FrmPais : Form
    {
        ManejadorPais mp;
        public static Pais paises = new Pais(0,"",0);
        int fila = 0, col = 0;
        public FrmPais()
        {
            InitializeComponent();
            mp = new ManejadorPais();
            CrearBoton();
            CrearBoton2();
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void dtgPais_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch(col)
            {
                case 3: {
                        FrmPaisAdd pade = new FrmPaisAdd();
                        pade.ShowDialog();
                        txtBuscar.Text = "";
                        Actualizar();
                    } break;
                case 4: {
                        mp.Borrar(paises);
                        txtBuscar.Text = "";
                        Actualizar();
                    } break;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            paises.Ncorrelativo = -1;
            FrmPaisAdd pade = new FrmPaisAdd();
            pade.ShowDialog();
            Actualizar();

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtgPais_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            col = e.ColumnIndex;
            paises.Ncorrelativo = int.Parse(dtgPais.Rows[fila]
                .Cells[0].Value.ToString());
            paises.Nombre = dtgPais.Rows[fila]
                .Cells[1].Value.ToString();
            paises.Nclubes = int.Parse(dtgPais.Rows[fila]
                .Cells[2].Value.ToString());
        }

        private void FrmPais_Load(object sender, EventArgs e)
        {
            Actualizar();
        }
        public void CrearBoton()
        {
            Button ButtonExcel = new Button();
            ButtonExcel.Text = "Excel";
            ButtonExcel.Width = 89;
            ButtonExcel.Height = 31;
            ButtonExcel.Location = new Point(555, 368);
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
            ButtonPdf.Location = new Point(423, 368);
            ButtonPdf.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            ButtonPdf.BackColor = Color.Red;
            ButtonPdf.Click += ButtonPdf_Click;
            this.Controls.Add(ButtonPdf);
        }

        private void ButtonPdf_Click(object sender, EventArgs e)
        {
            Document documento = new Document(PageSize.A4);
            PdfWriter.GetInstance(documento, new FileStream(@"C:\Users\chino\Documents\Paises.pdf", FileMode.OpenOrCreate));
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

            PdfPTable tablaPais = new PdfPTable(2);
            tablaPais.WidthPercentage = 100;

            PdfPCell Nombre = new PdfPCell(new Phrase("Nombre"));
            Nombre.BorderWidth = 0;
            Nombre.BorderWidthBottom = 0.75f;

            PdfPCell Nclubes = new PdfPCell(new Phrase("Número de clubes"));
            Nclubes.BorderWidth = 0;
            Nclubes.BorderWidthBottom = 0.75f;

            tablaPais.AddCell(Nombre);
            tablaPais.AddCell(Nclubes);

            System.Diagnostics.Process.Start(@"C:\Users\chino\Documents\Paises.pdf");

            for (int i = 0; i < dtgPais.RowCount; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    Nombre = new PdfPCell(new Phrase(dtgPais.Rows[i].Cells[1].Value.ToString()));
                    Nclubes = new PdfPCell(new Phrase(dtgPais.Rows[i].Cells[2].Value.ToString()));

                    tablaPais.AddCell(Nombre);
                    tablaPais.AddCell(Nclubes);
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
            foreach(DataGridViewColumn col in dtgPais.Columns)
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
            ExportarDatos(dtgPais);
        }
        void Actualizar()
        {
            mp.Mostrar(dtgPais, txtBuscar.Text);
        }
    }
}
