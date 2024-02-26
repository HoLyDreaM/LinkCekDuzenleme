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
using System.Threading;
using System.IO;
using DevExpress.Utils;

namespace FistasCekDuzenleme
{
    public partial class CekSorgula : Form
    {
        public CekSorgula()
        {
            InitializeComponent();
        }

        #region Bağlantı ve Formlar

        public Anaform anaFrm
        {
            get;
            set;
        }

        Thread Sorgula;
        SqlConnection CekCon;
        SqlCommand CekCmd;
        SqlDataReader CekDr;

        SqlConnection UpdateCekCon;
        SqlCommand UpdateCekCmd;

        iniOku.iniOku iniOku = new iniOku.iniOku(Application.StartupPath + "\\Zaman.ini");
        string Cs = Properties.Settings.Default.Cs1;

        #endregion

        #region Tanımlar

        int UpdateID;
        string ID;
        double Tarih;
        int TarihRakam;
        string Sorgu;
        string Sirket;
        string CekNo;
        string HesapNo;
        DateTime VadeTarihi;
        decimal Tutar;
        string Duzenleyen;
        string Unvani;
        string DovizCinsi;
        decimal DovizKuru;
        decimal DovizTutari;
        string DovizTutariYuvarla;
        int USD, EURO, STERLIN, FRANK;

        #endregion

        #region Cek Sorgula Form Load İşlemleri

        private void CekSorgula_Load(object sender, EventArgs e)
        {
            DateTime obj = new DateTime();
            obj = DateTime.Now;
            string str;
            Tarih = 0;
            Tarih = obj.ToOADate();
            str = Tarih.ToString().Substring(0, 5);
            TarihRakam = Convert.ToInt32(str);
            Sirket = anaFrm.sirketAdi;
        }

        #endregion

        #region Çek Arama Bölümü

        public void Search()
        {
            CekCon = new SqlConnection(Cs);

            btnArama.Enabled = false;
            btnGuncelle.Enabled = false;
            
            grdCek.DataSource = null;
            grdCek.DataSource = ds.Cekler;

            USD = Convert.ToInt32(iniOku.IniReadValue("Zaman", "USD"));
            EURO = Convert.ToInt32(iniOku.IniReadValue("Zaman", "EURO"));
            STERLIN = Convert.ToInt32(iniOku.IniReadValue("Zaman", "STERLIN"));
            FRANK = Convert.ToInt32(iniOku.IniReadValue("Zaman", "FRANK"));

            Sorgu = "SELECT SCS003_Row_ID AS ID, SCS003_CekNo AS CekNo, SCS003_HesapKodu AS HesapKodu, SCS003_Tutar AS Tutar, " +
                    "CONVERT(DATETIME,SCS003_VadeTarihi-2,102) AS VadeTarihi,SCS003_Duzenleyen AS Duzenleyen, SCS003_DuzenleyenUnvani1 AS DuzenleyenUnvani, " +
                    "SCS003_DovizCinsi AS DovizCinsi, " +
                    "(CASE SCS003_DovizCinsi " +
                    "WHEN '' THEN 0 "+
                    "WHEN 'USD' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + USD + "))" +
                    "WHEN 'EUR' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + EURO + ")) " +
                    "WHEN 'GBP' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + STERLIN + ")) " +
                    "WHEN 'CHF' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + FRANK + ")) " +
                    "END) AS DovizKuru, " +
                    "SCS003_Tutar / " +
                    "(CASE SCS003_DovizCinsi " +
                    "WHEN '' THEN 1 "+
                    "WHEN 'USD' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + USD + "))" +
                    "WHEN 'EUR' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + EURO + ")) " +
                    "WHEN 'GBP' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + STERLIN + ")) " +
                    "WHEN 'CHF' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + FRANK + ")) " +
                    "END) AS DovizTutari,SCS003_CekTipi AS CekTipi FROM YNS" + Sirket + ".SCS003 " +
                    "WHERE (SCS003_CekTipi = '1') AND (SCS003_VadeTarihi >= " + TarihRakam + ") " +
                    "Order By ID ASC";

            if (CekCon.State == ConnectionState.Closed)
                CekCon.Open();

            CekCmd = new SqlCommand(Sorgu, CekCon);
            CekCmd.CommandTimeout = 120;
            CekDr = CekCmd.ExecuteReader(CommandBehavior.CloseConnection);
            ds.Cekler.TableName.Replace("YNS02012", "YNS" + Sirket.ToString());

            while (CekDr.Read())
            {
                Thread.Sleep(60);

                ID = CekDr["ID"].ToString();
                CekNo = CekDr["CekNo"].ToString();
                HesapNo = CekDr["HesapKodu"].ToString();
                Tutar = Convert.ToDecimal(CekDr["Tutar"].ToString());
                VadeTarihi = Convert.ToDateTime(CekDr["VadeTarihi"].ToString());
                Duzenleyen = CekDr["Duzenleyen"].ToString();
                Unvani = CekDr["DuzenleyenUnvani"].ToString();
                DovizCinsi = CekDr["DovizCinsi"].ToString();
                string Cekler = CekDr["CekTipi"].ToString();
                DovizKuru = Convert.ToDecimal(CekDr["DovizKuru"].ToString());
                DovizTutariYuvarla = CekDr["DovizTutari"].ToString();
                int yuvarlama = Convert.ToInt32(Convert.ToDecimal(CekDr["DovizTutari"].ToString()));
                DovizTutari = Convert.ToDecimal(DovizTutariYuvarla);

                //ds.Cekler.AddCeklerRow(CekNo, HesapNo, Tutar, Duzenleyen, Unvani, DovizCinsi, Cekler.ToString(), Convert.ToDateTime(VadeTarihi), DovizTutari, ID, DovizKuru);
            }

            CekCon.Dispose();
            CekCon.Close();
            CekCmd.Dispose();
            CekDr.Dispose();
            CekDr.Close();

            MessageBox.Show("Toplam Bulunan Kayıt Sayısı : " + Convert.ToString(ds.Cekler.Rows.Count));

            btnArama.Enabled = true;
            btnGuncelle.Enabled = true;
            
        }

        #endregion

        #region Arama Butonu

        private void btnArama_Click(object sender, EventArgs e)
        {
            ds.Cekler.Clear();

            Sorgula = new Thread(new ThreadStart(Search));
            Sorgula.Priority = ThreadPriority.Highest;
            Sorgula.Start();
        }

        #endregion

        #region Çekleri Güncelleme İşlemi

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (ds.Cekler.Rows.Count <= 0)
            {
                MessageBox.Show("Lütfen Önce Çekleri Sorgulayınız.");
            }
            else
            {
                UpdateCekCon = new SqlConnection(Cs);

                foreach (DataRow row in ds.Cekler.Rows)
                {
                    Thread.Sleep(10);
                    UpdateID = Convert.ToInt32(row["ID"].ToString());

                    if (UpdateCekCon.State == ConnectionState.Closed)
                        UpdateCekCon.Open();

                    decimal DovizKurumuz = Convert.ToDecimal(row["DovizKuru"].ToString());
                    decimal DovizTutarimiz = Convert.ToDecimal(row["DovizTutari"].ToString());
                    string UpdateSorgumuz = "UPDATE YNS" + Sirket.ToString() + ".SCS003 SET SCS003_DovizKuru1=@DovizKuru , SCS003_DovizTutari1=@DovizTutari WHERE SCS003_Row_ID=" + UpdateID + "";

                    UpdateCekCmd = new SqlCommand(UpdateSorgumuz, UpdateCekCon);
                    UpdateCekCmd.Parameters.Add(@"DovizKuru", SqlDbType.Decimal).Value = DovizKurumuz;
                    UpdateCekCmd.Parameters.Add("@DovizTutari", SqlDbType.Decimal).Value = DovizTutarimiz;
                    UpdateCekCmd.ExecuteNonQuery();
                }

                UpdateCekCon.Dispose();
                UpdateCekCon.Close();
                UpdateCekCmd.Dispose();

                MessageBox.Show("Çek Güncellenmesi Başarıyla Tamamlanmıştır");
            }
        }

        #endregion

    }
}
