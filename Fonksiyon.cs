using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace FistasCekDuzenleme
{
    public partial class Fonksiyon : Form
    {
        public Fonksiyon()
        {
            InitializeComponent();
        }

        #region Bağlantılar ve Tanımlar

        SqlConnection conFnk;
        SqlCommand cmdFnk;
        SqlDataReader drFnk;
        string veritabani;
        string Cs = Properties.Settings.Default.Cs1;
        iniOku.iniOku iniOku = new iniOku.iniOku(Application.StartupPath + "\\ayar.ini");

        #endregion

        #region Form Load İşlemleri

        private void Fonksiyon_Load(object sender, EventArgs e)
        {
            FonksiyonDurumu();
        }

        #endregion

        #region Fonksiyon Kontrol

        private Int16 FnkKontrol()
        {
            conFnk = new SqlConnection(Cs);

            if (conFnk.State == ConnectionState.Closed)
                conFnk.Open();

            string sorgu = "SELECT COUNT(*) AS Durum FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_DovizKuru]')";
            cmdFnk = new SqlCommand(sorgu, conFnk);
            return Convert.ToInt16(cmdFnk.ExecuteScalar());
        }

        #endregion

        #region Fonksiyon Bilgilerini Çekiyoruz

        private void FnkBilgileriniCek()
        {
            conFnk = new SqlConnection(Cs);

            if (conFnk.State == ConnectionState.Closed)
                conFnk.Open();

            string sorgu = "SELECT name,type,create_date FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_DovizKuru]')";
            cmdFnk = new SqlCommand(sorgu, conFnk);
            drFnk = cmdFnk.ExecuteReader();

            while (drFnk.Read())
            {
                txtFonksiyonAdi.Text = drFnk["name"].ToString();
                txtTarih.Text = drFnk["create_date"].ToString();
            }

            conFnk.Dispose();
            conFnk.Close();
            drFnk.Dispose();
            drFnk.Close();
        }

        #endregion

        #region Fonksiyon Durum Kontrolü

        private void FonksiyonDurumu()
        {
            if (FnkKontrol() > 0)
            {
                txtDurum.Text = "Fonksiyon Oluşturulmuş";
                txtDurum.ForeColor = Color.Green;
                btnFnkOlustur.Enabled = false;
                btnFnkKaldir.Enabled = true;
                FnkBilgileriniCek();
            }
            else
            {
                txtDurum.Text = "Fonksiyon Oluşturulmamış";
                txtDurum.ForeColor = Color.Red;
                txtFonksiyonAdi.Text = "...";
                txtTarih.Text = "...";

                btnFnkOlustur.Enabled = true;
                btnFnkKaldir.Enabled = false;
            }
        }

        #endregion

        #region Fonksiyon Oluşturuyoruz

        private void FnkOlustur()
        {
            conFnk = new SqlConnection(Cs);

            if (conFnk.State == ConnectionState.Closed)
                conFnk.Open();

            veritabani = iniOku.IniReadValue("Ayar", "Sirket");
            string sorgu = "CREATE FUNCTION [dbo].[fn_DovizKuru](@Tarih AS Int,@Kur AS Tinyint) "+
                           "RETURNS Money AS "+
                           "BEGIN "+
                           "DECLARE @i INT,@gelen MONEY,@durum BIT "+
                           "SET @i = 0 "+
                           "SET @gelen=0 "+
                           "SET @durum=1 "+
                           "WHILE (@durum=1) "+
                              "BEGIN "+
                              "SET @gelen=(SELECT  "+
                              "(CASE  @Kur  "+
                              " WHEN 1 THEN  DVZ002_DvzAlis1 "+
	                           "WHEN 2 THEN  DVZ002_DvzSatis1 "+
	                           "WHEN 3 THEN  DVZ002_DvzAlis2 "+
	                           "WHEN 4 THEN  DVZ002_DvzSatis2 "+
	                           "WHEN 5 THEN  DVZ002_DvzAlis3 "+
	                           "WHEN 6 THEN  DVZ002_DvzSatis3 "+
	                           "WHEN 7 THEN  DVZ002_DvzAlis4 "+
	                           "WHEN 8 THEN  DVZ002_DvzSatis4 END) AS DovizKuru  "+
	                           "FROM YNS"+veritabani+".DVZ002 WHERE DVZ002_DovizDate=@tarih-@i) "+
	
	                           "IF @gelen is null  "+
	                           "BEGIN "+
	                           "SET @i = @i + 1 "+
	                           "END "+
	                           "ELSE "+
	                           "BREAK  "+
                           "END "+

                           "RETURN @gelen " +
                           "END";
            cmdFnk = new SqlCommand(sorgu, conFnk);
            cmdFnk.ExecuteScalar();
            conFnk.Dispose();
            conFnk.Close();
            FonksiyonDurumu();
        }

        #endregion

        #region Fonksiyon Kaldırma İşlemi

        private void FnkKaldir()
        {
            conFnk = new SqlConnection(Cs);

            if (conFnk.State == ConnectionState.Closed)
                conFnk.Open();

            string sorgu="IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_DovizKuru]')) "+
                         "DROP FUNCTION [dbo].[fn_DovizKuru];";
            cmdFnk = new SqlCommand(sorgu, conFnk);
            cmdFnk.ExecuteScalar();
            cmdFnk.Dispose();
            conFnk.Dispose();
            conFnk.Close();
            FonksiyonDurumu();
        }

        #endregion

        #region Fonksiyon Oluşturma Butonu

        private void btnFnkOlustur_Click(object sender, EventArgs e)
        {
            FnkOlustur();
        }

        #endregion

        #region Fonksiyon Kaldırma Butonu

        private void btnFnkKaldir_Click(object sender, EventArgs e)
        {
            DialogResult Secim;
            Secim = MessageBox.Show(this, "Fonksiyonu Silmek İstediğinize Emin Misiniz?", "Uyarı..", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (Secim == DialogResult.Yes)
            {
                FnkKaldir();
            }
        }

        #endregion
    }
}
