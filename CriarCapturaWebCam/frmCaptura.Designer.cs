namespace CriarCapturaWebCam
{
    partial class frmCaptura
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbWebcam = new System.Windows.Forms.PictureBox();
            this.btLigarDesligar = new System.Windows.Forms.Button();
            this.btCapturar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.pic3 = new System.Windows.Forms.PictureBox();
            this.pic4 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbWebcam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic4)).BeginInit();
            this.SuspendLayout();
            // 
            // pbWebcam
            // 
            this.pbWebcam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbWebcam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbWebcam.Location = new System.Drawing.Point(12, 12);
            this.pbWebcam.Name = "pbWebcam";
            this.pbWebcam.Size = new System.Drawing.Size(511, 319);
            this.pbWebcam.TabIndex = 0;
            this.pbWebcam.TabStop = false;
            // 
            // btLigarDesligar
            // 
            this.btLigarDesligar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btLigarDesligar.Enabled = false;
            this.btLigarDesligar.Location = new System.Drawing.Point(12, 379);
            this.btLigarDesligar.Name = "btLigarDesligar";
            this.btLigarDesligar.Size = new System.Drawing.Size(652, 34);
            this.btLigarDesligar.TabIndex = 1;
            this.btLigarDesligar.Text = "LigarDesligar";
            this.btLigarDesligar.UseVisualStyleBackColor = true;
            this.btLigarDesligar.Click += new System.EventHandler(this.btLigarDesligar_Click);
            // 
            // btCapturar
            // 
            this.btCapturar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btCapturar.Enabled = false;
            this.btCapturar.Location = new System.Drawing.Point(12, 419);
            this.btCapturar.Name = "btCapturar";
            this.btCapturar.Size = new System.Drawing.Size(652, 34);
            this.btCapturar.TabIndex = 2;
            this.btCapturar.Text = "Capturar";
            this.btCapturar.UseVisualStyleBackColor = true;
            this.btCapturar.Click += new System.EventHandler(this.btCapturar_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pic1
            // 
            this.pic1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic1.Location = new System.Drawing.Point(537, 12);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(127, 66);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic1.TabIndex = 3;
            this.pic1.TabStop = false;
            // 
            // pic2
            // 
            this.pic2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic2.Location = new System.Drawing.Point(537, 86);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(127, 66);
            this.pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic2.TabIndex = 4;
            this.pic2.TabStop = false;
            // 
            // pic3
            // 
            this.pic3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic3.Location = new System.Drawing.Point(537, 166);
            this.pic3.Name = "pic3";
            this.pic3.Size = new System.Drawing.Size(127, 66);
            this.pic3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic3.TabIndex = 5;
            this.pic3.TabStop = false;
            // 
            // pic4
            // 
            this.pic4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic4.Location = new System.Drawing.Point(537, 245);
            this.pic4.Name = "pic4";
            this.pic4.Size = new System.Drawing.Size(127, 66);
            this.pic4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic4.TabIndex = 6;
            this.pic4.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(12, 337);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(652, 34);
            this.button1.TabIndex = 7;
            this.button1.Text = "Iniciar Monitoramento";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmCaptura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 458);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pic4);
            this.Controls.Add(this.pic3);
            this.Controls.Add(this.pic2);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.btCapturar);
            this.Controls.Add(this.btLigarDesligar);
            this.Controls.Add(this.pbWebcam);
            this.Name = "frmCaptura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbWebcam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbWebcam;
        private System.Windows.Forms.Button btLigarDesligar;
        private System.Windows.Forms.Button btCapturar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.PictureBox pic2;
        private System.Windows.Forms.PictureBox pic3;
        private System.Windows.Forms.PictureBox pic4;
        private System.Windows.Forms.Button button1;
    }
}

