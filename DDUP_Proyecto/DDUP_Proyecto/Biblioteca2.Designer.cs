namespace DDUP_Proyecto
{
    partial class Biblioteca2
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
                tts.Dispose();
                errorSound.Dispose();
                foundSound.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Biblioteca2));
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.panel_Settings = new MetroFramework.Controls.MetroPanel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.readToggle = new MetroFramework.Controls.MetroToggle();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.soundToggle = new MetroFramework.Controls.MetroToggle();
            this.panel_Title = new MetroFramework.Controls.MetroPanel();
            this.lblTitle = new MetroFramework.Controls.MetroLabel();
            this.panel_TabControl = new MetroFramework.Controls.MetroPanel();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.tabDescripcion = new MetroFramework.Controls.MetroTabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblDescription = new MetroFramework.Controls.MetroLabel();
            this.tabImagen = new MetroFramework.Controls.MetroTabPage();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabSonido = new MetroFramework.Controls.MetroTabPage();
            this.metroProgressBar1 = new MetroFramework.Controls.MetroProgressBar();
            this.metroTile3 = new MetroFramework.Controls.MetroTile();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.tabOtros = new MetroFramework.Controls.MetroTabPage();
            this.panel_Navigation = new MetroFramework.Controls.MetroPanel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.mainPanel = new MetroFramework.Controls.MetroPanel();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.panel_Settings.SuspendLayout();
            this.panel_Title.SuspendLayout();
            this.panel_TabControl.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.tabDescripcion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabImagen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabSonido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel_Navigation.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // panel_Settings
            // 
            this.panel_Settings.Controls.Add(this.metroLabel3);
            this.panel_Settings.Controls.Add(this.readToggle);
            this.panel_Settings.Controls.Add(this.metroLabel2);
            this.panel_Settings.Controls.Add(this.soundToggle);
            this.panel_Settings.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Settings.HorizontalScrollbarBarColor = true;
            this.panel_Settings.HorizontalScrollbarHighlightOnWheel = false;
            this.panel_Settings.HorizontalScrollbarSize = 10;
            this.panel_Settings.Location = new System.Drawing.Point(0, 29);
            this.panel_Settings.Name = "panel_Settings";
            this.panel_Settings.Size = new System.Drawing.Size(760, 22);
            this.panel_Settings.TabIndex = 2;
            this.panel_Settings.VerticalScrollbarBarColor = true;
            this.panel_Settings.VerticalScrollbarHighlightOnWheel = false;
            this.panel_Settings.VerticalScrollbarSize = 10;
            // 
            // metroLabel3
            // 
            this.metroLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(549, 2);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(143, 19);
            this.metroLabel3.TabIndex = 5;
            this.metroLabel3.Text = "Leer automáticamente:";
            // 
            // readToggle
            // 
            this.readToggle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.readToggle.AutoSize = true;
            this.readToggle.Checked = true;
            this.readToggle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.readToggle.DisplayStatus = false;
            this.readToggle.Location = new System.Drawing.Point(698, 2);
            this.readToggle.Name = "readToggle";
            this.readToggle.Size = new System.Drawing.Size(50, 17);
            this.readToggle.TabIndex = 4;
            this.readToggle.Text = "On";
            this.readToggle.UseSelectable = true;
            this.readToggle.CheckedChanged += new System.EventHandler(this.readToggle_CheckedChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(365, 2);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(122, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Reproducir sonidos";
            // 
            // soundToggle
            // 
            this.soundToggle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.soundToggle.AutoSize = true;
            this.soundToggle.DisplayStatus = false;
            this.soundToggle.Location = new System.Drawing.Point(493, 2);
            this.soundToggle.Name = "soundToggle";
            this.soundToggle.Size = new System.Drawing.Size(50, 17);
            this.soundToggle.TabIndex = 2;
            this.soundToggle.Text = "Off";
            this.soundToggle.UseSelectable = true;
            // 
            // panel_Title
            // 
            this.panel_Title.Controls.Add(this.lblTitle);
            this.panel_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Title.HorizontalScrollbarBarColor = true;
            this.panel_Title.HorizontalScrollbarHighlightOnWheel = false;
            this.panel_Title.HorizontalScrollbarSize = 10;
            this.panel_Title.Location = new System.Drawing.Point(0, 0);
            this.panel_Title.Name = "panel_Title";
            this.panel_Title.Size = new System.Drawing.Size(760, 29);
            this.panel_Title.TabIndex = 3;
            this.panel_Title.VerticalScrollbarBarColor = true;
            this.panel_Title.VerticalScrollbarHighlightOnWheel = false;
            this.panel_Title.VerticalScrollbarSize = 10;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTitle.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTitle.Location = new System.Drawing.Point(4, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(62, 25);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Título";
            // 
            // panel_TabControl
            // 
            this.panel_TabControl.AutoSize = true;
            this.panel_TabControl.Controls.Add(this.metroTabControl1);
            this.panel_TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_TabControl.HorizontalScrollbarBarColor = true;
            this.panel_TabControl.HorizontalScrollbarHighlightOnWheel = false;
            this.panel_TabControl.HorizontalScrollbarSize = 10;
            this.panel_TabControl.Location = new System.Drawing.Point(0, 51);
            this.panel_TabControl.Name = "panel_TabControl";
            this.panel_TabControl.Size = new System.Drawing.Size(760, 381);
            this.panel_TabControl.TabIndex = 4;
            this.panel_TabControl.VerticalScrollbarBarColor = true;
            this.panel_TabControl.VerticalScrollbarHighlightOnWheel = false;
            this.panel_TabControl.VerticalScrollbarSize = 10;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroTabControl1.Controls.Add(this.tabDescripcion);
            this.metroTabControl1.Controls.Add(this.tabImagen);
            this.metroTabControl1.Controls.Add(this.tabSonido);
            this.metroTabControl1.Controls.Add(this.tabOtros);
            this.metroTabControl1.FontWeight = MetroFramework.MetroTabControlWeight.Regular;
            this.metroTabControl1.HotTrack = true;
            this.metroTabControl1.Location = new System.Drawing.Point(7, 3);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(738, 346);
            this.metroTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.metroTabControl1.TabIndex = 5;
            this.metroTabControl1.UseSelectable = true;
            // 
            // tabDescripcion
            // 
            this.tabDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabDescripcion.Controls.Add(this.pictureBox2);
            this.tabDescripcion.Controls.Add(this.lblDescription);
            this.tabDescripcion.HorizontalScrollbarBarColor = true;
            this.tabDescripcion.HorizontalScrollbarHighlightOnWheel = false;
            this.tabDescripcion.HorizontalScrollbarSize = 10;
            this.tabDescripcion.Location = new System.Drawing.Point(4, 38);
            this.tabDescripcion.Name = "tabDescripcion";
            this.tabDescripcion.Size = new System.Drawing.Size(730, 304);
            this.tabDescripcion.TabIndex = 0;
            this.tabDescripcion.Text = "Descripción";
            this.tabDescripcion.VerticalScrollbarBarColor = true;
            this.tabDescripcion.VerticalScrollbarHighlightOnWheel = false;
            this.tabDescripcion.VerticalScrollbarSize = 10;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::DDUP_Proyecto.Properties.Resources.icons8_page_32;
            this.pictureBox2.Location = new System.Drawing.Point(693, 267);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblDescription.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblDescription.Location = new System.Drawing.Point(2, 10);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(723, 257);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = resources.GetString("lblDescription.Text");
            this.lblDescription.WrapToLine = true;
            // 
            // tabImagen
            // 
            this.tabImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabImagen.Controls.Add(this.pictureBox3);
            this.tabImagen.Controls.Add(this.pictureBox1);
            this.tabImagen.HorizontalScrollbarBarColor = true;
            this.tabImagen.HorizontalScrollbarHighlightOnWheel = false;
            this.tabImagen.HorizontalScrollbarSize = 10;
            this.tabImagen.Location = new System.Drawing.Point(4, 38);
            this.tabImagen.Name = "tabImagen";
            this.tabImagen.Size = new System.Drawing.Size(730, 304);
            this.tabImagen.TabIndex = 1;
            this.tabImagen.Text = "Imagen";
            this.tabImagen.VerticalScrollbarBarColor = true;
            this.tabImagen.VerticalScrollbarHighlightOnWheel = false;
            this.tabImagen.VerticalScrollbarSize = 10;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = global::DDUP_Proyecto.Properties.Resources.icons8_full_image_32;
            this.pictureBox3.Location = new System.Drawing.Point(693, 267);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::DDUP_Proyecto.Properties.Resources.image_placeholder;
            this.pictureBox1.Location = new System.Drawing.Point(277, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(254, 254);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // tabSonido
            // 
            this.tabSonido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabSonido.Controls.Add(this.metroProgressBar1);
            this.tabSonido.Controls.Add(this.metroTile3);
            this.tabSonido.Controls.Add(this.metroTile2);
            this.tabSonido.Controls.Add(this.pictureBox4);
            this.tabSonido.HorizontalScrollbarBarColor = true;
            this.tabSonido.HorizontalScrollbarHighlightOnWheel = false;
            this.tabSonido.HorizontalScrollbarSize = 10;
            this.tabSonido.Location = new System.Drawing.Point(4, 38);
            this.tabSonido.Name = "tabSonido";
            this.tabSonido.Size = new System.Drawing.Size(730, 304);
            this.tabSonido.TabIndex = 2;
            this.tabSonido.Text = "Sonido";
            this.tabSonido.VerticalScrollbarBarColor = true;
            this.tabSonido.VerticalScrollbarHighlightOnWheel = false;
            this.tabSonido.VerticalScrollbarSize = 10;
            // 
            // metroProgressBar1
            // 
            this.metroProgressBar1.Location = new System.Drawing.Point(69, 170);
            this.metroProgressBar1.Name = "metroProgressBar1";
            this.metroProgressBar1.Size = new System.Drawing.Size(587, 23);
            this.metroProgressBar1.TabIndex = 5;
            this.metroProgressBar1.Value = 75;
            // 
            // metroTile3
            // 
            this.metroTile3.ActiveControl = null;
            this.metroTile3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroTile3.Location = new System.Drawing.Point(456, 58);
            this.metroTile3.Name = "metroTile3";
            this.metroTile3.Size = new System.Drawing.Size(107, 58);
            this.metroTile3.Style = MetroFramework.MetroColorStyle.Black;
            this.metroTile3.TabIndex = 4;
            this.metroTile3.Text = "Detener";
            this.metroTile3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTile3.TileImage = global::DDUP_Proyecto.Properties.Resources.icons8_stop_circled_32__1_;
            this.metroTile3.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.metroTile3.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.metroTile3.UseSelectable = true;
            this.metroTile3.UseTileImage = true;
            // 
            // metroTile2
            // 
            this.metroTile2.ActiveControl = null;
            this.metroTile2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroTile2.Location = new System.Drawing.Point(150, 58);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(107, 58);
            this.metroTile2.Style = MetroFramework.MetroColorStyle.Black;
            this.metroTile2.TabIndex = 3;
            this.metroTile2.Text = "Reproducir";
            this.metroTile2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTile2.TileImage = global::DDUP_Proyecto.Properties.Resources.icons8_circled_play_32__1_;
            this.metroTile2.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.metroTile2.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.metroTile2.UseSelectable = true;
            this.metroTile2.UseTileImage = true;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.Image = global::DDUP_Proyecto.Properties.Resources.icons8_speaker_32;
            this.pictureBox4.Location = new System.Drawing.Point(693, 267);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 32);
            this.pictureBox4.TabIndex = 2;
            this.pictureBox4.TabStop = false;
            // 
            // tabOtros
            // 
            this.tabOtros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabOtros.HorizontalScrollbarBarColor = true;
            this.tabOtros.HorizontalScrollbarHighlightOnWheel = false;
            this.tabOtros.HorizontalScrollbarSize = 10;
            this.tabOtros.Location = new System.Drawing.Point(4, 38);
            this.tabOtros.Name = "tabOtros";
            this.tabOtros.Size = new System.Drawing.Size(730, 304);
            this.tabOtros.TabIndex = 3;
            this.tabOtros.Text = "Otros";
            this.tabOtros.VerticalScrollbarBarColor = true;
            this.tabOtros.VerticalScrollbarHighlightOnWheel = false;
            this.tabOtros.VerticalScrollbarSize = 10;
            // 
            // panel_Navigation
            // 
            this.panel_Navigation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_Navigation.Controls.Add(this.metroLabel1);
            this.panel_Navigation.Controls.Add(this.metroTile1);
            this.panel_Navigation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Navigation.HorizontalScrollbarBarColor = true;
            this.panel_Navigation.HorizontalScrollbarHighlightOnWheel = false;
            this.panel_Navigation.HorizontalScrollbarSize = 10;
            this.panel_Navigation.Location = new System.Drawing.Point(0, 432);
            this.panel_Navigation.Name = "panel_Navigation";
            this.panel_Navigation.Size = new System.Drawing.Size(760, 62);
            this.panel_Navigation.TabIndex = 5;
            this.panel_Navigation.VerticalScrollbarBarColor = true;
            this.panel_Navigation.VerticalScrollbarHighlightOnWheel = false;
            this.panel_Navigation.VerticalScrollbarSize = 10;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(279, 24);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(472, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Coloca una tarjeta en el sensor para buscar el objeto en la biblioteca.";
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(3, 3);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(108, 52);
            this.metroTile1.TabIndex = 0;
            this.metroTile1.Text = "Regresar";
            this.metroTile1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroTile1.TileImage = global::DDUP_Proyecto.Properties.Resources.icons8_back_arrow_32;
            this.metroTile1.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroTile1.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.metroTile1.UseCustomForeColor = true;
            this.metroTile1.UseSelectable = true;
            this.metroTile1.UseTileImage = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.AutoSize = true;
            this.mainPanel.Controls.Add(this.panel_TabControl);
            this.mainPanel.Controls.Add(this.panel_Navigation);
            this.mainPanel.Controls.Add(this.panel_Settings);
            this.mainPanel.Controls.Add(this.panel_Title);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.HorizontalScrollbarBarColor = true;
            this.mainPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.mainPanel.HorizontalScrollbarSize = 10;
            this.mainPanel.Location = new System.Drawing.Point(20, 60);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(760, 494);
            this.mainPanel.TabIndex = 6;
            this.mainPanel.VerticalScrollbarBarColor = true;
            this.mainPanel.VerticalScrollbarHighlightOnWheel = false;
            this.mainPanel.VerticalScrollbarSize = 10;
            // 
            // Biblioteca2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 574);
            this.Controls.Add(this.mainPanel);
            this.Name = "Biblioteca2";
            this.Text = "Biblioteca";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Biblioteca2_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.panel_Settings.ResumeLayout(false);
            this.panel_Settings.PerformLayout();
            this.panel_Title.ResumeLayout(false);
            this.panel_Title.PerformLayout();
            this.panel_TabControl.ResumeLayout(false);
            this.metroTabControl1.ResumeLayout(false);
            this.tabDescripcion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabImagen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabSonido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel_Navigation.ResumeLayout(false);
            this.panel_Navigation.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroPanel panel_Settings;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroToggle readToggle;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroToggle soundToggle;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroPanel panel_TabControl;
        private MetroFramework.Controls.MetroLabel lblDescription;
        private MetroFramework.Controls.MetroPanel panel_Title;
        private MetroFramework.Controls.MetroLabel lblTitle;
        private MetroFramework.Controls.MetroTabPage tabDescripcion;
        private MetroFramework.Controls.MetroTabPage tabImagen;
        private MetroFramework.Controls.MetroPanel panel_Navigation;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroPanel mainPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTabPage tabSonido;
        private MetroFramework.Controls.MetroTabPage tabOtros;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private MetroFramework.Controls.MetroTile metroTile2;
        private MetroFramework.Controls.MetroProgressBar metroProgressBar1;
        private MetroFramework.Controls.MetroTile metroTile3;
    }
}