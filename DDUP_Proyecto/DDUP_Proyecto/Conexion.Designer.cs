namespace DDUP_Proyecto
{
    partial class Conexion
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Conexion));
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.btnConectar = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.btnUpdate = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.lblStatus = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.tileTarjeta = new MetroFramework.Controls.MetroTile();
            this.tileBiblioteca = new MetroFramework.Controls.MetroTile();
            this.tileAlumno = new MetroFramework.Controls.MetroTile();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.themeSelector = new MetroFramework.Controls.MetroComboBox();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 23;
            this.metroComboBox1.Location = new System.Drawing.Point(23, 82);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(194, 29);
            this.metroComboBox1.TabIndex = 0;
            this.metroComboBox1.UseSelectable = true;
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(223, 82);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(109, 29);
            this.btnConectar.TabIndex = 1;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseSelectable = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(23, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(351, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Conecte el módulo de tarjetas RFID y presione conectar.";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(24, 118);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(171, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Seleccione el puerto COM ";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(339, 83);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(134, 28);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Actualizar Puertos";
            this.btnUpdate.UseSelectable = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(23, 408);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(53, 19);
            this.metroLabel3.TabIndex = 5;
            this.metroLabel3.Text = "Estado:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStatus.Location = new System.Drawing.Point(92, 408);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(103, 19);
            this.lblStatus.Style = MetroFramework.MetroColorStyle.Red;
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Desconectado";
            this.lblStatus.UseStyleColors = true;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.metroTile1);
            this.metroPanel1.Controls.Add(this.tileTarjeta);
            this.metroPanel1.Controls.Add(this.tileBiblioteca);
            this.metroPanel1.Controls.Add(this.tileAlumno);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(23, 141);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1236, 264);
            this.metroPanel1.TabIndex = 7;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroTile1.Location = new System.Drawing.Point(939, 31);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(265, 192);
            this.metroTile1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroTile1.TabIndex = 5;
            this.metroTile1.Text = "Aprender Colores";
            this.metroTile1.TileImage = global::DDUP_Proyecto.Properties.Resources.icons8_lápiz_96;
            this.metroTile1.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile1.UseCustomForeColor = true;
            this.metroTile1.UseSelectable = true;
            this.metroTile1.UseTileImage = true;
            this.metroTile1.Visible = false;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click_1);
            // 
            // tileTarjeta
            // 
            this.tileTarjeta.ActiveControl = null;
            this.tileTarjeta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tileTarjeta.Location = new System.Drawing.Point(349, 31);
            this.tileTarjeta.Name = "tileTarjeta";
            this.tileTarjeta.Size = new System.Drawing.Size(249, 192);
            this.tileTarjeta.Style = MetroFramework.MetroColorStyle.Teal;
            this.tileTarjeta.TabIndex = 3;
            this.tileTarjeta.Text = "Registro de Tarjetas";
            this.tileTarjeta.TileImage = global::DDUP_Proyecto.Properties.Resources.icons8_soccer_yellow_card_96;
            this.tileTarjeta.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.tileTarjeta.UseCustomForeColor = true;
            this.tileTarjeta.UseSelectable = true;
            this.tileTarjeta.UseTileImage = true;
            this.tileTarjeta.Click += new System.EventHandler(this.metroTile2_Click);
            // 
            // tileBiblioteca
            // 
            this.tileBiblioteca.ActiveControl = null;
            this.tileBiblioteca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tileBiblioteca.Location = new System.Drawing.Point(38, 31);
            this.tileBiblioteca.Name = "tileBiblioteca";
            this.tileBiblioteca.Size = new System.Drawing.Size(271, 192);
            this.tileBiblioteca.Style = MetroFramework.MetroColorStyle.Orange;
            this.tileBiblioteca.TabIndex = 2;
            this.tileBiblioteca.Text = "Biblioteca";
            this.tileBiblioteca.TileImage = ((System.Drawing.Image)(resources.GetObject("tileBiblioteca.TileImage")));
            this.tileBiblioteca.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.tileBiblioteca.UseCustomForeColor = true;
            this.tileBiblioteca.UseSelectable = true;
            this.tileBiblioteca.UseTileImage = true;
            this.tileBiblioteca.Visible = false;
            this.tileBiblioteca.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // tileAlumno
            // 
            this.tileAlumno.ActiveControl = null;
            this.tileAlumno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tileAlumno.Location = new System.Drawing.Point(635, 31);
            this.tileAlumno.Name = "tileAlumno";
            this.tileAlumno.Size = new System.Drawing.Size(265, 192);
            this.tileAlumno.Style = MetroFramework.MetroColorStyle.Purple;
            this.tileAlumno.TabIndex = 4;
            this.tileAlumno.Text = "Aprender Braille";
            this.tileAlumno.TileImage = global::DDUP_Proyecto.Properties.Resources.icons8_braille_96;
            this.tileAlumno.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.tileAlumno.UseCustomForeColor = true;
            this.tileAlumno.UseSelectable = true;
            this.tileAlumno.UseTileImage = true;
            this.tileAlumno.Click += new System.EventHandler(this.metroTile3_Click);
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(1001, 408);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(44, 19);
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.Text = "Tema:";
            // 
            // themeSelector
            // 
            this.themeSelector.FormattingEnabled = true;
            this.themeSelector.ItemHeight = 23;
            this.themeSelector.Items.AddRange(new object[] {
            "Brillante",
            "Oscuro"});
            this.themeSelector.Location = new System.Drawing.Point(1063, 411);
            this.themeSelector.MaxDropDownItems = 2;
            this.themeSelector.Name = "themeSelector";
            this.themeSelector.Size = new System.Drawing.Size(194, 29);
            this.themeSelector.TabIndex = 9;
            this.themeSelector.UseSelectable = true;
            this.themeSelector.SelectedIndexChanged += new System.EventHandler(this.themeSelector_SelectedIndexChanged);
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Default;
            // 
            // Conexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 450);
            this.Controls.Add(this.themeSelector);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.metroComboBox1);
            this.MaximizeBox = false;
            this.Name = "Conexion";
            this.Resizable = false;
            this.Text = "Menú principal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Conexion_FormClosed);
            this.Load += new System.EventHandler(this.Conexion_Load);
            this.metroPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private MetroFramework.Controls.MetroButton btnConectar;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton btnUpdate;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel lblStatus;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTile tileAlumno;
        private MetroFramework.Controls.MetroTile tileTarjeta;
        private MetroFramework.Controls.MetroTile tileBiblioteca;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroComboBox themeSelector;
        public MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private MetroFramework.Controls.MetroTile metroTile1;
        private System.IO.Ports.SerialPort serialPort1;
    }
}