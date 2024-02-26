namespace FistasCekDuzenleme
{
    partial class Fonksiyon
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
            this.txtDurum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTarih = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFonksiyonAdi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFnkKaldir = new DevExpress.XtraEditors.SimpleButton();
            this.btnFnkOlustur = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // txtDurum
            // 
            this.txtDurum.BackColor = System.Drawing.Color.Honeydew;
            this.txtDurum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDurum.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDurum.ForeColor = System.Drawing.Color.Black;
            this.txtDurum.Location = new System.Drawing.Point(129, 9);
            this.txtDurum.Name = "txtDurum";
            this.txtDurum.ReadOnly = true;
            this.txtDurum.Size = new System.Drawing.Size(201, 21);
            this.txtDurum.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 21);
            this.label2.TabIndex = 32;
            this.label2.Text = "Fonksiyon Durumu";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTarih
            // 
            this.txtTarih.BackColor = System.Drawing.Color.Honeydew;
            this.txtTarih.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTarih.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTarih.Location = new System.Drawing.Point(129, 69);
            this.txtTarih.Name = "txtTarih";
            this.txtTarih.ReadOnly = true;
            this.txtTarih.Size = new System.Drawing.Size(254, 21);
            this.txtTarih.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 21);
            this.label1.TabIndex = 31;
            this.label1.Text = "Oluşturulma Tarihi";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFonksiyonAdi
            // 
            this.txtFonksiyonAdi.BackColor = System.Drawing.Color.Honeydew;
            this.txtFonksiyonAdi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFonksiyonAdi.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtFonksiyonAdi.Location = new System.Drawing.Point(129, 40);
            this.txtFonksiyonAdi.Name = "txtFonksiyonAdi";
            this.txtFonksiyonAdi.ReadOnly = true;
            this.txtFonksiyonAdi.Size = new System.Drawing.Size(254, 21);
            this.txtFonksiyonAdi.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Silver;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(12, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 21);
            this.label5.TabIndex = 30;
            this.label5.Text = "Fonksiyon Adı";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFnkKaldir
            // 
            this.btnFnkKaldir.Image = global::FistasCekDuzenleme.Properties.Resources._1351762821_1012;
            this.btnFnkKaldir.Location = new System.Drawing.Point(360, 8);
            this.btnFnkKaldir.Name = "btnFnkKaldir";
            this.btnFnkKaldir.Size = new System.Drawing.Size(23, 23);
            this.btnFnkKaldir.TabIndex = 27;
            this.btnFnkKaldir.Text = "Kaldır";
            this.btnFnkKaldir.Click += new System.EventHandler(this.btnFnkKaldir_Click);
            // 
            // btnFnkOlustur
            // 
            this.btnFnkOlustur.Image = global::FistasCekDuzenleme.Properties.Resources._1351762950_103;
            this.btnFnkOlustur.Location = new System.Drawing.Point(331, 8);
            this.btnFnkOlustur.Name = "btnFnkOlustur";
            this.btnFnkOlustur.Size = new System.Drawing.Size(28, 23);
            this.btnFnkOlustur.TabIndex = 26;
            this.btnFnkOlustur.Text = "Oluştur";
            this.btnFnkOlustur.Click += new System.EventHandler(this.btnFnkOlustur_Click);
            // 
            // Fonksiyon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 405);
            this.Controls.Add(this.btnFnkKaldir);
            this.Controls.Add(this.btnFnkOlustur);
            this.Controls.Add(this.txtDurum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTarih);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFonksiyonAdi);
            this.Controls.Add(this.label5);
            this.Name = "Fonksiyon";
            this.Text = "Fonksiyon Oluşturma";
            this.Load += new System.EventHandler(this.Fonksiyon_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnFnkKaldir;
        private DevExpress.XtraEditors.SimpleButton btnFnkOlustur;
        private System.Windows.Forms.TextBox txtDurum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTarih;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFonksiyonAdi;
        private System.Windows.Forms.Label label5;
    }
}