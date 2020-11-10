namespace AdvancedClient
{
    partial class frmRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegister));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_KullanıcıAdı = new System.Windows.Forms.Label();
            this.lb_Sifre = new System.Windows.Forms.Label();
            this.txt_KullanıcıAdı = new System.Windows.Forms.TextBox();
            this.txt_Şifre = new System.Windows.Forms.TextBox();
            this.btn_GirişYap = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AdvancedClient.Properties.Resources.soru_isareti;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(95, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_KullanıcıAdı);
            this.groupBox1.Controls.Add(this.lb_Sifre);
            this.groupBox1.Controls.Add(this.txt_KullanıcıAdı);
            this.groupBox1.Controls.Add(this.txt_Şifre);
            this.groupBox1.Controls.Add(this.btn_GirişYap);
            this.groupBox1.Location = new System.Drawing.Point(25, 159);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 191);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // lb_KullanıcıAdı
            // 
            this.lb_KullanıcıAdı.AutoSize = true;
            this.lb_KullanıcıAdı.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_KullanıcıAdı.Location = new System.Drawing.Point(49, 39);
            this.lb_KullanıcıAdı.Name = "lb_KullanıcıAdı";
            this.lb_KullanıcıAdı.Size = new System.Drawing.Size(89, 17);
            this.lb_KullanıcıAdı.TabIndex = 3;
            this.lb_KullanıcıAdı.Text = "User Name:";
            // 
            // lb_Sifre
            // 
            this.lb_Sifre.AutoSize = true;
            this.lb_Sifre.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Sifre.Location = new System.Drawing.Point(49, 85);
            this.lb_Sifre.Name = "lb_Sifre";
            this.lb_Sifre.Size = new System.Drawing.Size(84, 17);
            this.lb_Sifre.TabIndex = 4;
            this.lb_Sifre.Text = "Password:";
            // 
            // txt_KullanıcıAdı
            // 
            this.txt_KullanıcıAdı.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_KullanıcıAdı.Location = new System.Drawing.Point(138, 36);
            this.txt_KullanıcıAdı.Name = "txt_KullanıcıAdı";
            this.txt_KullanıcıAdı.Size = new System.Drawing.Size(100, 20);
            this.txt_KullanıcıAdı.TabIndex = 0;
            // 
            // txt_Şifre
            // 
            this.txt_Şifre.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_Şifre.Location = new System.Drawing.Point(138, 82);
            this.txt_Şifre.Name = "txt_Şifre";
            this.txt_Şifre.PasswordChar = '*';
            this.txt_Şifre.Size = new System.Drawing.Size(100, 20);
            this.txt_Şifre.TabIndex = 1;
            // 
            // btn_GirişYap
            // 
            this.btn_GirişYap.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GirişYap.Location = new System.Drawing.Point(138, 137);
            this.btn_GirişYap.Name = "btn_GirişYap";
            this.btn_GirişYap.Size = new System.Drawing.Size(100, 32);
            this.btn_GirişYap.TabIndex = 2;
            this.btn_GirişYap.Text = "Login";
            this.btn_GirişYap.UseVisualStyleBackColor = true;
            this.btn_GirişYap.Click += new System.EventHandler(this.btn_GirişYap_Click);
            // 
            // frmRegister
            // 
            this.AcceptButton = this.btn_GirişYap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(326, 376);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmRegister";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.frmRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_KullanıcıAdı;
        private System.Windows.Forms.Label lb_Sifre;
        private System.Windows.Forms.TextBox txt_KullanıcıAdı;
        private System.Windows.Forms.TextBox txt_Şifre;
        private System.Windows.Forms.Button btn_GirişYap;
    }
}