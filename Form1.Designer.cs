namespace FistasCekDuzenleme
{
    partial class Form1
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
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.oto = new System.Windows.Forms.CheckBox();
            this.btnBaglan = new System.Windows.Forms.Button();
            this.cmGirisTuru = new System.Windows.Forms.ComboBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.txtKullanici = new System.Windows.Forms.TextBox();
            this.txtSirket = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Silver;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(12, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 20);
            this.label9.TabIndex = 44;
            this.label9.Text = "Şifre";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Silver;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(12, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 20);
            this.label8.TabIndex = 43;
            this.label8.Text = "Kullanıcı Adı";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Silver;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(12, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 20);
            this.label6.TabIndex = 42;
            this.label6.Text = "Şirket Adı";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Silver;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(12, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 20);
            this.label5.TabIndex = 41;
            this.label5.Text = "Server Adı";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // oto
            // 
            this.oto.AutoSize = true;
            this.oto.Location = new System.Drawing.Point(221, 175);
            this.oto.Name = "oto";
            this.oto.Size = new System.Drawing.Size(104, 17);
            this.oto.TabIndex = 40;
            this.oto.Text = "Otomatik Bağlan";
            this.oto.UseVisualStyleBackColor = true;
            // 
            // btnBaglan
            // 
            this.btnBaglan.Location = new System.Drawing.Point(129, 146);
            this.btnBaglan.Name = "btnBaglan";
            this.btnBaglan.Size = new System.Drawing.Size(196, 23);
            this.btnBaglan.TabIndex = 39;
            this.btnBaglan.Text = "Bağlan";
            this.btnBaglan.UseVisualStyleBackColor = true;
            this.btnBaglan.Click += new System.EventHandler(this.btnBaglan_Click);
            // 
            // cmGirisTuru
            // 
            this.cmGirisTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmGirisTuru.FormattingEnabled = true;
            this.cmGirisTuru.Items.AddRange(new object[] {
            "Windows Kimliği Ile Oturum Aç",
            "Kullanıcı Kimliği İle Oturum Aç"});
            this.cmGirisTuru.Location = new System.Drawing.Point(129, 67);
            this.cmGirisTuru.Name = "cmGirisTuru";
            this.cmGirisTuru.Size = new System.Drawing.Size(196, 21);
            this.cmGirisTuru.TabIndex = 36;
            this.cmGirisTuru.SelectedIndexChanged += new System.EventHandler(this.cmGirisTuru_SelectedIndexChanged);
            // 
            // txtSifre
            // 
            this.txtSifre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSifre.Location = new System.Drawing.Point(129, 120);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(196, 20);
            this.txtSifre.TabIndex = 38;
            // 
            // txtKullanici
            // 
            this.txtKullanici.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKullanici.Location = new System.Drawing.Point(129, 94);
            this.txtKullanici.Name = "txtKullanici";
            this.txtKullanici.Size = new System.Drawing.Size(196, 20);
            this.txtKullanici.TabIndex = 37;
            // 
            // txtSirket
            // 
            this.txtSirket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSirket.Location = new System.Drawing.Point(129, 41);
            this.txtSirket.Name = "txtSirket";
            this.txtSirket.Size = new System.Drawing.Size(196, 20);
            this.txtSirket.TabIndex = 35;
            // 
            // txtServer
            // 
            this.txtServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServer.Location = new System.Drawing.Point(129, 15);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(196, 20);
            this.txtServer.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Silver;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(12, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 20);
            this.label7.TabIndex = 45;
            this.label7.Text = "Giriş Türü";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 192);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.oto);
            this.Controls.Add(this.btnBaglan);
            this.Controls.Add(this.cmGirisTuru);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtKullanici);
            this.Controls.Add(this.txtSirket);
            this.Controls.Add(this.txtServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Veritabanı Bağlantı Ayarları";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox oto;
        private System.Windows.Forms.Button btnBaglan;
        private System.Windows.Forms.ComboBox cmGirisTuru;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.TextBox txtKullanici;
        private System.Windows.Forms.TextBox txtSirket;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label7;
    }
}

