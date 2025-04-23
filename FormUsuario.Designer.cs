namespace KyA_DB
{
    partial class FormUsuario
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPeliculas;
        private System.Windows.Forms.TabPage tabSeries;
        private System.Windows.Forms.DataGridView dgvPeliculas;
        private System.Windows.Forms.DataGridView dgvSeries;
        private System.Windows.Forms.ListBox lstComentarios;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Button btnComentar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPeliculas = new System.Windows.Forms.TabPage();
            this.dgvPeliculas = new System.Windows.Forms.DataGridView();
            this.tabSeries = new System.Windows.Forms.TabPage();
            this.dgvSeries = new System.Windows.Forms.DataGridView();
            this.lstComentarios = new System.Windows.Forms.ListBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.btnComentar = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPeliculas.SuspendLayout();
            this.tabSeries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeliculas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeries)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPeliculas);
            this.tabControl.Controls.Add(this.tabSeries);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(760, 350);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPeliculas
            // 
            this.tabPeliculas.Controls.Add(this.dgvPeliculas);
            this.tabPeliculas.Location = new System.Drawing.Point(4, 24);
            this.tabPeliculas.Name = "tabPeliculas";
            this.tabPeliculas.Padding = new System.Windows.Forms.Padding(3);
            this.tabPeliculas.Size = new System.Drawing.Size(752, 322);
            this.tabPeliculas.TabIndex = 0;
            this.tabPeliculas.Text = "Películas";
            this.tabPeliculas.UseVisualStyleBackColor = true;
            // 
            // dgvPeliculas
            // 
            this.dgvPeliculas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeliculas.Location = new System.Drawing.Point(6, 6);
            this.dgvPeliculas.Name = "dgvPeliculas";
            this.dgvPeliculas.Size = new System.Drawing.Size(740, 310);
            this.dgvPeliculas.TabIndex = 0;
            this.dgvPeliculas.SelectionChanged += new System.EventHandler(this.dgvPeliculas_SelectionChanged);
            // 
            // tabSeries
            // 
            this.tabSeries.Controls.Add(this.dgvSeries);
            this.tabSeries.Location = new System.Drawing.Point(4, 24);
            this.tabSeries.Name = "tabSeries";
            this.tabSeries.Padding = new System.Windows.Forms.Padding(3);
            this.tabSeries.Size = new System.Drawing.Size(752, 322);
            this.tabSeries.TabIndex = 1;
            this.tabSeries.Text = "Series";
            this.tabSeries.UseVisualStyleBackColor = true;
            // 
            // dgvSeries
            // 
            this.dgvSeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeries.Location = new System.Drawing.Point(6, 6);
            this.dgvSeries.Name = "dgvSeries";
            this.dgvSeries.Size = new System.Drawing.Size(740, 310);
            this.dgvSeries.TabIndex = 0;
            this.dgvSeries.SelectionChanged += new System.EventHandler(this.dgvSeries_SelectionChanged);
            // 
            // lstComentarios
            // 
            this.lstComentarios.FormattingEnabled = true;
            this.lstComentarios.ItemHeight = 15;
            this.lstComentarios.Location = new System.Drawing.Point(12, 368);
            this.lstComentarios.Name = "lstComentarios";
            this.lstComentarios.Size = new System.Drawing.Size(760, 94);
            this.lstComentarios.TabIndex = 1;
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(12, 468);
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(540, 23);
            this.txtComentario.TabIndex = 4;
            // 
            // btnComentar
            // 
            this.btnComentar.Location = new System.Drawing.Point(558, 468);
            this.btnComentar.Name = "btnComentar";
            this.btnComentar.Size = new System.Drawing.Size(100, 30);
            this.btnComentar.TabIndex = 5;
            this.btnComentar.Text = "Comentar";
            this.btnComentar.UseVisualStyleBackColor = true;
            this.btnComentar.Click += new System.EventHandler(this.btnComentar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(12, 508);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 30);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(672, 508);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(100, 30);
            this.btnCerrarSesion.TabIndex = 3;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // FormUsuario
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnComentar);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lstComentarios);
            this.Controls.Add(this.tabControl);
            this.Name = "FormUsuario";
            this.Text = "Películas y Series";
            this.tabControl.ResumeLayout(false);
            this.tabPeliculas.ResumeLayout(false);
            this.tabSeries.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeliculas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeries)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}


