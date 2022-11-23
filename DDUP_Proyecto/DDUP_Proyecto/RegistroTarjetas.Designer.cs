namespace DDUP_Proyecto
{
    partial class RegistroTarjetas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroPanel4 = new MetroFramework.Controls.MetroPanel();
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.radio_Letras = new MetroFramework.Controls.MetroRadioButton();
            this.radio_Num = new MetroFramework.Controls.MetroRadioButton();
            this.radio_Basura = new MetroFramework.Controls.MetroRadioButton();
            this.radio_Todos = new MetroFramework.Controls.MetroRadioButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectEntityBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.metroPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            this.metroPanel2.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectEntityBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(24, 64);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(328, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Haga doble clic en una celda para editar su contenido.";
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // metroPanel4
            // 
            this.metroPanel4.AutoSize = true;
            this.metroPanel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.metroPanel4.Controls.Add(this.metroTile1);
            this.metroPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroPanel4.HorizontalScrollbarBarColor = true;
            this.metroPanel4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel4.HorizontalScrollbarSize = 10;
            this.metroPanel4.Location = new System.Drawing.Point(0, 389);
            this.metroPanel4.Name = "metroPanel4";
            this.metroPanel4.Size = new System.Drawing.Size(761, 62);
            this.metroPanel4.TabIndex = 0;
            this.metroPanel4.VerticalScrollbarBarColor = true;
            this.metroPanel4.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel4.VerticalScrollbarSize = 10;
            // 
            // metroGrid1
            // 
            this.metroGrid1.AllowUserToResizeRows = false;
            this.metroGrid1.AutoGenerateColumns = false;
            this.metroGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.metroGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(242)))), ((int)(((byte)(121)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.metroGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.tipoDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.tipoIDDataGridViewTextBoxColumn});
            this.metroGrid1.DataSource = this.objectEntityBindingSource1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(242)))), ((int)(((byte)(121)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle2;
            this.metroGrid1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.Location = new System.Drawing.Point(0, 0);
            this.metroGrid1.Margin = new System.Windows.Forms.Padding(10);
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(242)))), ((int)(((byte)(121)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid1.Size = new System.Drawing.Size(761, 306);
            this.metroGrid1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroGrid1.TabIndex = 0;
            this.metroGrid1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.metroGrid1_CellValueChanged);
            this.metroGrid1.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.metroGrid1_RowLeave);
            this.metroGrid1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.metroGrid1_RowStateChanged);
            // 
            // metroPanel2
            // 
            this.metroPanel2.AutoSize = true;
            this.metroPanel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.metroPanel2.Controls.Add(this.radio_Letras);
            this.metroPanel2.Controls.Add(this.radio_Num);
            this.metroPanel2.Controls.Add(this.radio_Basura);
            this.metroPanel2.Controls.Add(this.radio_Todos);
            this.metroPanel2.Controls.Add(this.metroLabel2);
            this.metroPanel2.Controls.Add(this.metroTile2);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(0, 334);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(761, 55);
            this.metroPanel2.TabIndex = 0;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // radio_Letras
            // 
            this.radio_Letras.AutoSize = true;
            this.radio_Letras.Location = new System.Drawing.Point(452, 20);
            this.radio_Letras.Name = "radio_Letras";
            this.radio_Letras.Size = new System.Drawing.Size(54, 15);
            this.radio_Letras.TabIndex = 7;
            this.radio_Letras.Text = "Letras";
            this.radio_Letras.UseSelectable = true;
            this.radio_Letras.CheckedChanged += new System.EventHandler(this.radio_Letras_CheckedChanged);
            // 
            // radio_Num
            // 
            this.radio_Num.AutoSize = true;
            this.radio_Num.Location = new System.Drawing.Point(374, 20);
            this.radio_Num.Name = "radio_Num";
            this.radio_Num.Size = new System.Drawing.Size(72, 15);
            this.radio_Num.TabIndex = 6;
            this.radio_Num.Text = "Números";
            this.radio_Num.UseSelectable = true;
            this.radio_Num.CheckedChanged += new System.EventHandler(this.radio_Num_CheckedChanged);
            // 
            // radio_Basura
            // 
            this.radio_Basura.AutoSize = true;
            this.radio_Basura.Location = new System.Drawing.Point(310, 20);
            this.radio_Basura.Name = "radio_Basura";
            this.radio_Basura.Size = new System.Drawing.Size(58, 15);
            this.radio_Basura.TabIndex = 5;
            this.radio_Basura.Text = "Basura";
            this.radio_Basura.UseSelectable = true;
            this.radio_Basura.CheckedChanged += new System.EventHandler(this.radio_Basura_CheckedChanged);
            // 
            // radio_Todos
            // 
            this.radio_Todos.AutoSize = true;
            this.radio_Todos.Checked = true;
            this.radio_Todos.Location = new System.Drawing.Point(250, 20);
            this.radio_Todos.Name = "radio_Todos";
            this.radio_Todos.Size = new System.Drawing.Size(54, 15);
            this.radio_Todos.TabIndex = 4;
            this.radio_Todos.TabStop = true;
            this.radio_Todos.Text = "Todos";
            this.radio_Todos.UseSelectable = true;
            this.radio_Todos.CheckedChanged += new System.EventHandler(this.radio_Todos_CheckedChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(184, 17);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(59, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Mostrar:";
            // 
            // metroPanel1
            // 
            this.metroPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.metroPanel1.Controls.Add(this.metroPanel2);
            this.metroPanel1.Controls.Add(this.metroGrid1);
            this.metroPanel1.Controls.Add(this.metroPanel4);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(23, 86);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(761, 451);
            this.metroPanel1.TabIndex = 3;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroTile2
            // 
            this.metroTile2.ActiveControl = null;
            this.metroTile2.Location = new System.Drawing.Point(3, 6);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(174, 42);
            this.metroTile2.Style = MetroFramework.MetroColorStyle.Red;
            this.metroTile2.TabIndex = 2;
            this.metroTile2.Text = "Eliminar seleccionado";
            this.metroTile2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroTile2.TileImage = global::DDUP_Proyecto.Properties.Resources.icons8_delete_trash_32;
            this.metroTile2.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroTile2.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.metroTile2.UseCustomForeColor = true;
            this.metroTile2.UseSelectable = true;
            this.metroTile2.UseTileImage = true;
            this.metroTile2.Click += new System.EventHandler(this.metroTile2_Click);
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 46;
            // 
            // tipoDataGridViewTextBoxColumn
            // 
            this.tipoDataGridViewTextBoxColumn.DataPropertyName = "Tipo";
            this.tipoDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tipoDataGridViewTextBoxColumn.Name = "tipoDataGridViewTextBoxColumn";
            this.tipoDataGridViewTextBoxColumn.Width = 58;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.Width = 82;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.Width = 102;
            // 
            // tipoIDDataGridViewTextBoxColumn
            // 
            this.tipoIDDataGridViewTextBoxColumn.DataPropertyName = "TipoID";
            this.tipoIDDataGridViewTextBoxColumn.HeaderText = "TipoID";
            this.tipoIDDataGridViewTextBoxColumn.Name = "tipoIDDataGridViewTextBoxColumn";
            this.tipoIDDataGridViewTextBoxColumn.Width = 72;
            // 
            // objectEntityBindingSource1
            // 
            this.objectEntityBindingSource1.DataSource = typeof(DDUP_Proyecto.ObjectEntity);
            // 
            // RegistroTarjetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.metroLabel1);
            this.MinimumSize = new System.Drawing.Size(800, 560);
            this.Name = "RegistroTarjetas";
            this.Text = "Registro Tarjetas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegistroTarjetas_FormClosed);
            this.Load += new System.EventHandler(this.RegistroTarjetas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.metroPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectEntityBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private System.Windows.Forms.BindingSource objectEntityBindingSource1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroRadioButton radio_Letras;
        private MetroFramework.Controls.MetroRadioButton radio_Num;
        private MetroFramework.Controls.MetroRadioButton radio_Basura;
        private MetroFramework.Controls.MetroRadioButton radio_Todos;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTile metroTile2;
        private MetroFramework.Controls.MetroGrid metroGrid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoIDDataGridViewTextBoxColumn;
        private MetroFramework.Controls.MetroPanel metroPanel4;
        private MetroFramework.Controls.MetroTile metroTile1;
    }
}