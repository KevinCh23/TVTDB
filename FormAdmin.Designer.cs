namespace KyA_DB
{
    partial class FormAdmin
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAgregarUsuario;
        private System.Windows.Forms.Button btnBorrarUsuario;
        private System.Windows.Forms.Button btnAgregarPelicula;
        private System.Windows.Forms.Button btnAgregarSerie;
        private System.Windows.Forms.Button btnBorrarPelicula;
        private System.Windows.Forms.Button btnBorrarSerie;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.DataGridView dgvReportes;

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
            this.btnAgregarUsuario = new System.Windows.Forms.Button();
            this.btnBorrarUsuario = new System.Windows.Forms.Button();
            this.btnAgregarPelicula = new System.Windows.Forms.Button();
            this.btnAgregarSerie = new System.Windows.Forms.Button();
            this.btnBorrarPelicula = new System.Windows.Forms.Button();
            this.btnBorrarSerie = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.dgvReportes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregarUsuario
            // 
            this.btnAgregarUsuario.Location = new System.Drawing.Point(12, 12);
            this.btnAgregarUsuario.Name = "btnAgregarUsuario";
            this.btnAgregarUsuario.Size = new System.Drawing.Size(150, 30);
            this.btnAgregarUsuario.TabIndex = 0;
            this.btnAgregarUsuario.Text = "Añadir Usuario";
            this.btnAgregarUsuario.UseVisualStyleBackColor = true;
            this.btnAgregarUsuario.Click += new System.EventHandler(this.btnAgregarUsuario_Click);
            // 
            // btnBorrarUsuario
            // 
            this.btnBorrarUsuario.Location = new System.Drawing.Point(12, 48);
            this.btnBorrarUsuario.Name = "btnBorrarUsuario";
            this.btnBorrarUsuario.Size = new System.Drawing.Size(150, 30);
            this.btnBorrarUsuario.TabIndex = 1;
            this.btnBorrarUsuario.Text = "Borrar Usuario";
            this.btnBorrarUsuario.UseVisualStyleBackColor = true;
            this.btnBorrarUsuario.Click += new System.EventHandler(this.btnBorrarUsuario_Click);
            // 
            // btnAgregarPelicula
            // 
            this.btnAgregarPelicula.Location = new System.Drawing.Point(12, 84);
            this.btnAgregarPelicula.Name = "btnAgregarPelicula";
            this.btnAgregarPelicula.Size = new System.Drawing.Size(150, 30);
            this.btnAgregarPelicula.TabIndex = 2;
            this.btnAgregarPelicula.Text = "Añadir Película";
            this.btnAgregarPelicula.UseVisualStyleBackColor = true;
            this.btnAgregarPelicula.Click += new System.EventHandler(this.btnAgregarPelicula_Click);
            // 
            // btnAgregarSerie
            // 
            this.btnAgregarSerie.Location = new System.Drawing.Point(12, 120);
            this.btnAgregarSerie.Name = "btnAgregarSerie";
            this.btnAgregarSerie.Size = new System.Drawing.Size(150, 30);
            this.btnAgregarSerie.TabIndex = 3;
            this.btnAgregarSerie.Text = "Añadir Serie";
            this.btnAgregarSerie.UseVisualStyleBackColor = true;
            this.btnAgregarSerie.Click += new System.EventHandler(this.btnAgregarSerie_Click);
            // 
            // btnBorrarPelicula
            // 
            this.btnBorrarPelicula.Location = new System.Drawing.Point(12, 156);
            this.btnBorrarPelicula.Name = "btnBorrarPelicula";
            this.btnBorrarPelicula.Size = new System.Drawing.Size(150, 30);
            this.btnBorrarPelicula.TabIndex = 4;
            this.btnBorrarPelicula.Text = "Borrar Película";
            this.btnBorrarPelicula.UseVisualStyleBackColor = true;
            this.btnBorrarPelicula.Click += new System.EventHandler(this.btnBorrarPelicula_Click);
            // 
            // btnBorrarSerie
            // 
            this.btnBorrarSerie.Location = new System.Drawing.Point(12, 192);
            this.btnBorrarSerie.Name = "btnBorrarSerie";
            this.btnBorrarSerie.Size = new System.Drawing.Size(150, 30);
            this.btnBorrarSerie.TabIndex = 5;
            this.btnBorrarSerie.Text = "Borrar Serie";
            this.btnBorrarSerie.UseVisualStyleBackColor = true;
            this.btnBorrarSerie.Click += new System.EventHandler(this.btnBorrarSerie_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(12, 228);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(150, 30);
            this.btnCerrarSesion.TabIndex = 6;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // dgvReportes
            // 
            this.dgvReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportes.Location = new System.Drawing.Point(180, 12);
            this.dgvReportes.Name = "dgvReportes";
            this.dgvReportes.Size = new System.Drawing.Size(600, 300);
            this.dgvReportes.TabIndex = 7;
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvReportes);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnBorrarSerie);
            this.Controls.Add(this.btnBorrarPelicula);
            this.Controls.Add(this.btnAgregarSerie);
            this.Controls.Add(this.btnAgregarPelicula);
            this.Controls.Add(this.btnBorrarUsuario);
            this.Controls.Add(this.btnAgregarUsuario);
            this.Name = "FormAdmin";
            this.Text = "Administración";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}


