namespace PresentacionAjedrez
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.optPais = new System.Windows.Forms.ToolStripButton();
            this.optJugadores = new System.Windows.Forms.ToolStripButton();
            this.optArbitros = new System.Windows.Forms.ToolStripButton();
            this.optHotel = new System.Windows.Forms.ToolStripButton();
            this.optHospedajej = new System.Windows.Forms.ToolStripButton();
            this.optHospedajea = new System.Windows.Forms.ToolStripButton();
            this.optPartida = new System.Windows.Forms.ToolStripButton();
            this.optSalas = new System.Windows.Forms.ToolStripButton();
            this.optPartidasjugadas = new System.Windows.Forms.ToolStripButton();
            this.optMovimientos = new System.Windows.Forms.ToolStripButton();
            this.optSalir = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optPais,
            this.optJugadores,
            this.optArbitros,
            this.optHotel,
            this.optHospedajej,
            this.optHospedajea,
            this.optPartida,
            this.optSalas,
            this.optPartidasjugadas,
            this.optMovimientos,
            this.optSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(70, 788);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // optPais
            // 
            this.optPais.AutoSize = false;
            this.optPais.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.optPais.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.optPais.Image = ((System.Drawing.Image)(resources.GetObject("optPais.Image")));
            this.optPais.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.optPais.Name = "optPais";
            this.optPais.Size = new System.Drawing.Size(65, 65);
            this.optPais.Text = "Paises";
            this.optPais.Click += new System.EventHandler(this.optPais_Click);
            // 
            // optJugadores
            // 
            this.optJugadores.AutoSize = false;
            this.optJugadores.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.optJugadores.Image = global::PresentacionAjedrez.Properties.Resources._53254;
            this.optJugadores.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.optJugadores.Name = "optJugadores";
            this.optJugadores.Size = new System.Drawing.Size(65, 65);
            this.optJugadores.Text = "Jugadores";
            this.optJugadores.Click += new System.EventHandler(this.optJugadores_Click);
            // 
            // optArbitros
            // 
            this.optArbitros.AutoSize = false;
            this.optArbitros.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.optArbitros.Image = global::PresentacionAjedrez.Properties.Resources._26288;
            this.optArbitros.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.optArbitros.Name = "optArbitros";
            this.optArbitros.Size = new System.Drawing.Size(65, 65);
            this.optArbitros.Text = "Arbitros";
            this.optArbitros.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // optHotel
            // 
            this.optHotel.AutoSize = false;
            this.optHotel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.optHotel.Image = global::PresentacionAjedrez.Properties.Resources._244989;
            this.optHotel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.optHotel.Name = "optHotel";
            this.optHotel.Size = new System.Drawing.Size(65, 65);
            this.optHotel.Text = "Hoteles";
            this.optHotel.Click += new System.EventHandler(this.optHotel_Click);
            // 
            // optHospedajej
            // 
            this.optHospedajej.AutoSize = false;
            this.optHospedajej.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.optHospedajej.Image = global::PresentacionAjedrez.Properties.Resources._482852;
            this.optHospedajej.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.optHospedajej.Name = "optHospedajej";
            this.optHospedajej.Size = new System.Drawing.Size(65, 65);
            this.optHospedajej.Text = "Hospedaje de Jugadores";
            this.optHospedajej.Click += new System.EventHandler(this.optHospedajej_Click);
            // 
            // optHospedajea
            // 
            this.optHospedajea.AutoSize = false;
            this.optHospedajea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.optHospedajea.Image = ((System.Drawing.Image)(resources.GetObject("optHospedajea.Image")));
            this.optHospedajea.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.optHospedajea.Name = "optHospedajea";
            this.optHospedajea.Size = new System.Drawing.Size(65, 65);
            this.optHospedajea.Text = "Hospedaje de Arbitros";
            this.optHospedajea.Click += new System.EventHandler(this.optHospedajea_Click);
            // 
            // optPartida
            // 
            this.optPartida.AutoSize = false;
            this.optPartida.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.optPartida.Image = global::PresentacionAjedrez.Properties.Resources._1620501;
            this.optPartida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.optPartida.Name = "optPartida";
            this.optPartida.Size = new System.Drawing.Size(65, 65);
            this.optPartida.Text = "Partidas";
            this.optPartida.Click += new System.EventHandler(this.optPartida_Click);
            // 
            // optSalas
            // 
            this.optSalas.AutoSize = false;
            this.optSalas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.optSalas.Image = global::PresentacionAjedrez.Properties.Resources._1388270;
            this.optSalas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.optSalas.Name = "optSalas";
            this.optSalas.Size = new System.Drawing.Size(65, 65);
            this.optSalas.Text = "Salas";
            this.optSalas.Click += new System.EventHandler(this.optSalas_Click);
            // 
            // optPartidasjugadas
            // 
            this.optPartidasjugadas.AutoSize = false;
            this.optPartidasjugadas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.optPartidasjugadas.Image = global::PresentacionAjedrez.Properties.Resources._1994312;
            this.optPartidasjugadas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.optPartidasjugadas.Name = "optPartidasjugadas";
            this.optPartidasjugadas.Size = new System.Drawing.Size(65, 65);
            this.optPartidasjugadas.Text = "Partidas Jugadas";
            this.optPartidasjugadas.Click += new System.EventHandler(this.optPartidasjugadas_Click);
            // 
            // optMovimientos
            // 
            this.optMovimientos.AutoSize = false;
            this.optMovimientos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.optMovimientos.Image = global::PresentacionAjedrez.Properties.Resources._11023;
            this.optMovimientos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.optMovimientos.Name = "optMovimientos";
            this.optMovimientos.Size = new System.Drawing.Size(65, 65);
            this.optMovimientos.Text = "Movimientos";
            this.optMovimientos.Click += new System.EventHandler(this.optMovimientos_Click);
            // 
            // optSalir
            // 
            this.optSalir.AutoSize = false;
            this.optSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.optSalir.Image = global::PresentacionAjedrez.Properties.Resources._3094700;
            this.optSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.optSalir.Name = "optSalir";
            this.optSalir.Size = new System.Drawing.Size(65, 65);
            this.optSalir.Text = "Salir";
            this.optSalir.Click += new System.EventHandler(this.optSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(478, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "BIENVENIDO A ";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1216, 788);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton optPais;
        private System.Windows.Forms.ToolStripButton optSalir;
        private System.Windows.Forms.ToolStripButton optJugadores;
        private System.Windows.Forms.ToolStripButton optArbitros;
        private System.Windows.Forms.ToolStripButton optHotel;
        private System.Windows.Forms.ToolStripButton optHospedajej;
        private System.Windows.Forms.ToolStripButton optHospedajea;
        private System.Windows.Forms.ToolStripButton optSalas;
        private System.Windows.Forms.ToolStripButton optPartida;
        private System.Windows.Forms.ToolStripButton optPartidasjugadas;
        private System.Windows.Forms.ToolStripButton optMovimientos;
        private System.Windows.Forms.Label label1;
    }
}