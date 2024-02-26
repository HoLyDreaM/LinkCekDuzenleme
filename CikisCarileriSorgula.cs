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
    public partial class CikisCarileriSorgula : Form
    {
        public CikisCarileriSorgula()
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
        SqlConnection CariCikisCon;
        SqlCommand CariCikisCmd;
        SqlDataReader CariCikisDr;

        SqlConnection Car002Con;
        SqlCommand Car002Cmd;
        SqlDataReader Car002Dr;

        SqlConnection CariToplamCon;
        SqlCommand CariToplamCmd;
        SqlDataReader CariToplamDr;

        SqlConnection CekCon;
        SqlCommand CekCmd;
        SqlDataReader CekDr;

        SqlConnection UpdateCekCon;
        SqlCommand UpdateCekCmd;

        SqlConnection UpdateCariCon;
        SqlCommand UpdateCariCmd;

        SqlConnection UpdateCar002;
        SqlCommand UpdateCar002cmd;

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
        string HesapKodu;
        DateTime VadeTarihi;
        DateTime TarihSorgu;
        string EvrakSeriNo;
        short islemTipi;
        decimal Tutar;
        decimal ToplamDovizTutar;
        decimal ToplamDovizTutar2;
        decimal CariTutar;
        string Unvani;
        string CekNo;
        string HesapNo;
        string Duzenleyen;
        string DovizCinsi;
        decimal DovizKuru;
        decimal DovizTutari;
        decimal EskiDoviz, DovizFarki;
        string DovizTutariYuvarla;
        int USD, EURO, STERLIN, FRANK, Car002ID;

        #endregion

        #region Form Load İşlemleri

        private void CikisCarileriSorgula_Load(object sender, EventArgs e)
        {
            //this.cariCikisKontrolCekleriTableAdapter.Fill(this.ds.CariCikisKontrolCekleri);
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            CheckForIllegalCrossThreadCalls = false;
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

        #region Çıkış Çekleri Arama Sorgumuz

        public void CariArama()
        {
            CariCikisCon = new SqlConnection(Cs);

            btnArama.Enabled = false;
            btnGuncelle.Enabled = false;

            grdCari.DataSource = null;
            grdCari.DataSource = ds.CariCikisKontrolCekleri;

            USD = Convert.ToInt32(iniOku.IniReadValue("Zaman", "USD"));
            EURO = Convert.ToInt32(iniOku.IniReadValue("Zaman", "EURO"));
            STERLIN = Convert.ToInt32(iniOku.IniReadValue("Zaman", "STERLIN"));
            FRANK = Convert.ToInt32(iniOku.IniReadValue("Zaman", "FRANK"));

            Sorgu = "Select CAR003_Row_ID AS ID,CAR003_HesapKodu AS HesapKodu,CONVERT(DATETIME,CAR003_Tarih-2,102) AS Tarih,CAR003_IslemTipi AS IslemTipi, " +
                    "CAR003_EvrakSeriNo AS EvrakSeriNo,CAR003_Tutar AS Tutar,CONVERT(DATETIME,CAR003_VadeTarihi-2,102) AS VadeTarihi, " +
                    "(CASE CAR003_ParaBirimi "+
                    "WHEN '1' THEN 'YEREL'  " +
                    "WHEN '2' THEN 'DOVIZ' END) AS ParaBirimi,CAR003_DovizCinsi AS DovizCinsi,CAR003_DovizTutari AS EskiDoviz, " +
                    "(CASE CAR002.CAR002_ParaBirimi " +
                    "WHEN 'USD' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + USD + ")) " +
                    "WHEN 'EUR' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + EURO + ")) " +
                    "WHEN 'GBP' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + STERLIN + ")) " +
                    "WHEN 'CHF' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + FRANK + ")) " +
                    "END) AS DovizKuru,CAST(CAR003_Tutar / " +
                    "(CASE CAR002.CAR002_ParaBirimi " +
                    "WHEN 'USD' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + USD + ")) " +
                    "WHEN 'EUR' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + EURO + ")) " +
                    "WHEN 'GBP' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + STERLIN + ")) " +
                    "WHEN 'CHF' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + FRANK + ")) " +
                    "END)AS DECIMAL(21,2)) AS YeniDoviz,CAST(CAR003_DovizTutari - CAR003_Tutar / " +
                    "(CASE CAR002.CAR002_ParaBirimi " +
                    "WHEN 'USD' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + USD + ")) " +
                    "WHEN 'EUR' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + EURO + ")) " +
                    "WHEN 'GBP' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + STERLIN + ")) " +
                    "WHEN 'CHF' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + FRANK + ")) " +
                    "END)AS DECIMAL(21,2))*-1 AS DovizFarki " +
                    "From YNS" + Sirket + ".CAR003 AS CAR003 INNER JOIN YNS" + Sirket + ".CAR002 AS CAR002 " +
                    "ON CAR003.CAR003_HesapKodu=CAR002.CAR002_HesapKodu " +
                    "Where CAR003_EvrakTipi='74' AND CAR003_SenetCekPozisyonTipi=2 " +
                    "AND CAR003_BA=0 AND CAR003_VadeTarihi >=  " + TarihRakam + " " +
                    "And CAR003_DovizCinsi<>'' And CAR003_DovizCinsi<>'TL' And CAR003_DovizCinsi IN " +
                    "(Select CAR002_ParaBirimi FROM YNS" + Sirket + ".CAR002 " +
                    "Where CAR002_HesapKodu=CAR003_HesapKodu) " +
                    "ORDER BY ID ASC ";

            if (CariCikisCon.State == ConnectionState.Closed)
                CariCikisCon.Open();

            CariCikisCmd = new SqlCommand(Sorgu, CariCikisCon);
            CariCikisCmd.CommandTimeout = 120;
            CariCikisDr = CariCikisCmd.ExecuteReader(CommandBehavior.CloseConnection);
            ds.CariCikisKontrolCekleri.TableName.Replace("YNS02012", "YNS" + Sirket.ToString());

            while (CariCikisDr.Read())
            {
                Thread.Sleep(60);

                ID = CariCikisDr["ID"].ToString();
                HesapKodu = CariCikisDr["HesapKodu"].ToString();
                TarihSorgu = Convert.ToDateTime(CariCikisDr["Tarih"].ToString());
                EvrakSeriNo = CariCikisDr["EvrakSeriNo"].ToString();
                islemTipi = Convert.ToInt16(CariCikisDr["IslemTipi"].ToString());
                Tutar = Convert.ToDecimal(CariCikisDr["Tutar"].ToString());
                VadeTarihi = Convert.ToDateTime(CariCikisDr["VadeTarihi"].ToString());
                DovizCinsi = CariCikisDr["DovizCinsi"].ToString();
                DovizKuru = Convert.ToDecimal(CariCikisDr["DovizKuru"].ToString());
                DovizTutariYuvarla = CariCikisDr["YeniDoviz"].ToString();
                int yuvarlama = Convert.ToInt32(Convert.ToDecimal(CariCikisDr["YeniDoviz"].ToString()));
                DovizTutari = Convert.ToDecimal(DovizTutariYuvarla);
                EskiDoviz = Convert.ToDecimal(CariCikisDr["EskiDoviz"]);
                DovizFarki = Convert.ToDecimal(CariCikisDr["DovizFarki"]);

                //ds.CariCikisKontrolCekleri.AddCariCikisKontrolCekleriRow(ID, HesapKodu, islemTipi, EvrakSeriNo, Tutar, 1, DovizCinsi, DovizKuru, Convert.ToDateTime(TarihSorgu), Convert.ToDateTime(VadeTarihi), Convert.ToString(EskiDoviz), Convert.ToString(DovizFarki), DovizTutari);
                ds.CariCikisKontrolCekleri.AddCariCikisKontrolCekleriRow(ID, HesapKodu, Convert.ToDateTime(TarihSorgu), islemTipi, EvrakSeriNo, Tutar, Convert.ToDateTime(VadeTarihi), 1, DovizCinsi, DovizKuru, Convert.ToString(EskiDoviz), Convert.ToString(DovizFarki), DovizTutari);
                //ds.CariKontrolCekleri.AddCariKontrolCekleriRow(ID,HesapKodu,islemTipi,EvrakSeriNo,Tutar,1,DovizCinsi,DovizKuru,DovizTutari,Convert.ToDateTime(TarihSorgu),Convert.ToDateTime(VadeTarihi),Convert.ToString(EskiDoviz),Convert.ToString(DovizFarki));
            }

            CariCikisCon.Dispose();
            CariCikisCon.Close();
            CariCikisCmd.Dispose();
            CariCikisDr.Dispose();
            CariCikisDr.Close();

            Search();

            MessageBox.Show("Toplam Bulunan Kayıt Sayısı : " + Convert.ToString(ds.CariCikisKontrolCekleri.Rows.Count));

            btnArama.Enabled = true;
            btnGuncelle.Enabled = true;

        }

        #endregion

        #region Arama Butonu

        private void btnArama_Click(object sender, EventArgs e)
        {
            ds.CariCikisKontrolCekleri.Clear();
            ds.Cekler.Clear();

            Sorgula = new Thread(new ThreadStart(CariArama));
            Sorgula.Priority = ThreadPriority.Highest;
            Sorgula.Start();
        }

        #endregion

        #region Çek Arama Bölümü

        public void Search()
        {
            CekCon = new SqlConnection(Cs);

            USD = Convert.ToInt32(iniOku.IniReadValue("Zaman", "USD"));
            EURO = Convert.ToInt32(iniOku.IniReadValue("Zaman", "EURO"));
            STERLIN = Convert.ToInt32(iniOku.IniReadValue("Zaman", "STERLIN"));
            FRANK = Convert.ToInt32(iniOku.IniReadValue("Zaman", "FRANK"));

            Sorgu = "SELECT SCS003_Row_ID AS ID, SCS003_CekNo AS CekNo, SCS003_HesapKodu AS HesapKodu, SCS003_Tutar AS Tutar, " +
                    "CONVERT(DATETIME,SCS003_VadeTarihi-2,102) AS VadeTarihi,SCS003_Duzenleyen AS Duzenleyen, SCS003_DuzenleyenUnvani1 AS DuzenleyenUnvani, " +
                    "SCS003_DovizCinsi AS DovizCinsi, " +
                    "(CASE CAR002_ParaBirimi " +
                //"WHEN '' THEN 0 " +
                //"WHEN 'TL' THEN 0" +
                    "WHEN 'USD' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + USD + ")) " +
                    "WHEN 'EUR' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + EURO + ")) " +
                    "WHEN 'GBP' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + STERLIN + ")) " +
                    "WHEN 'CHF' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + FRANK + ")) " +
                    "END) AS DovizKuru, " +
                    "SCS003_Tutar / " +
                    "(CASE SCS003_DovizCinsi " +
                //"WHEN '' THEN 1 " +
                //"WHEN 'TL' THEN 1 "+
                    "WHEN 'USD' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + USD + ")) " +
                    "WHEN 'EUR' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + EURO + ")) " +
                    "WHEN 'GBP' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + STERLIN + ")) " +
                    "WHEN 'CHF' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + FRANK + ")) " +
                    "END) AS DovizTutari,(CASE SCS003_CekTipi "+
                    "WHEN '1' THEN 'YEREL' "+
                    "WHEN '2' THEN 'DOVIZ' END) AS CekTipi  "+
                    "FROM YNS" + Sirket + ".SCS003 AS SCS003 INNER JOIN YNS" + Sirket + ".CAR002 AS CAR002 " +
                    "ON SCS003.SCS003_HesapKodu=CAR002.CAR002_HesapKodu "+
                    "WHERE (SCS003_VadeTarihi >= " + TarihRakam + ") " +
                    "AND SCS003_CH1='1' AND SCS003_CH2= '1' AND SCS003_BankaCekNoPozisyon2='2' "+
                    "AND SCS003_SonPozisyonTipi='2' AND SCS003_EB2='1'AND SCS003_DovizCinsi<>'' And SCS003_DovizCinsi IN " +
                    "(Select CAR002_ParaBirimi FROM YNS" + Sirket + ".CAR002 " +
                    "Where CAR002_HesapKodu=SCS003_HesapKodu) " +
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
                string adanada = CekDr["DovizKuru"].ToString();
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

            //MessageBox.Show("Toplam Bulunan Kayıt Sayısı : " + Convert.ToString(ds.Cekler.Rows.Count));

            //btnArama.Enabled = true;
            //btnGuncelle.Enabled = true;

        }

        #endregion

        #region Çıkış Çekleri Güncelle

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (ds.CariCikisKontrolCekleri.Rows.Count <= 0)
            {
                MessageBox.Show("Lütfen Önce Çıkış Çeklerini Sorgulayınız.");
            }
            else
            {
                UpdateCariCon = new SqlConnection(Cs);

                UpdateCekCon = new SqlConnection(Cs);

                foreach (DataRow row in ds.Cekler.Rows)
                {
                    Thread.Sleep(10);
                    UpdateID = Convert.ToInt32(row["ID"].ToString());

                    if (UpdateCekCon.State == ConnectionState.Closed)
                        UpdateCekCon.Open();

                    decimal DovizKurumuz = Convert.ToDecimal(row["DovizKuru"].ToString());
                    decimal DovizTutarimiz = Convert.ToDecimal(row["DovizTutari"].ToString());
                    string UpdateSorgumuz = "UPDATE YNS" + Sirket.ToString() + ".SCS003 SET SCS003_DovizKuru1=@DovizKuru, SCS003_DovizKuru2=@DovizKuru , SCS003_DovizTutari1=@DovizTutari, SCS003_DovizTutari2=@DovizTutari WHERE SCS003_Row_ID=" + UpdateID + "";

                    UpdateCekCmd = new SqlCommand(UpdateSorgumuz, UpdateCekCon);
                    UpdateCekCmd.Parameters.Add(@"DovizKuru", SqlDbType.Decimal).Value = DovizKurumuz;
                    UpdateCekCmd.Parameters.Add("@DovizTutari", SqlDbType.Decimal).Value = DovizTutarimiz;
                    UpdateCekCmd.ExecuteNonQuery();
                }

                UpdateCekCon.Dispose();
                UpdateCekCon.Close();
                UpdateCekCmd.Dispose();

                foreach (DataRow row in ds.CariCikisKontrolCekleri.Rows)
                {
                    Thread.Sleep(10);
                    UpdateID = Convert.ToInt32(row["CariID"].ToString());
                    HesapKodu = row["HesapKodu"].ToString();
                    EskiDoviz = Convert.ToDecimal(row["EskiDoviz"].ToString());
                    DovizFarki = Convert.ToDecimal(row["DovizFarki"].ToString());

                    if (UpdateCariCon.State == ConnectionState.Closed)
                        UpdateCariCon.Open();

                    decimal DovizKurumuz = Convert.ToDecimal(row["DovizKuru"].ToString());
                    decimal DovizTutarimiz = Convert.ToDecimal(row["YeniDoviz"].ToString());

                    string UpdateSorgumuz = "UPDATE YNS" + Sirket.ToString() + ".CAR003 SET CAR003_DovizKuru=@DovizKuru , CAR003_DovizTutari=@DovizTutari WHERE CAR003_Row_ID=" + UpdateID + "";

                    UpdateCariCmd = new SqlCommand(UpdateSorgumuz, UpdateCariCon);
                    UpdateCariCmd.Parameters.Add(@"DovizKuru", SqlDbType.Decimal).Value = DovizKurumuz;
                    UpdateCariCmd.Parameters.Add("@DovizTutari", SqlDbType.Decimal).Value = DovizTutarimiz;
                    UpdateCariCmd.ExecuteNonQuery();


                    CariToplamCon = new SqlConnection(Cs);

                    if (CariToplamCon.State == ConnectionState.Closed)
                        CariToplamCon.Open();

                    string Sorgu3 = "SELECT CAR002_Row_ID, CAR002_HesapKodu, CAR002_Unvan1,CAR002_OdemeAlacak,CAR002_CekRiskiAlacak, " +
                           "CAR002_DovizOdemeBorc FROM YNS" + Sirket + ".CAR002 " +
                           "Where CAR002_HesapKodu='" + HesapKodu + "'";

                    CariToplamCmd = new SqlCommand(Sorgu3, CariToplamCon);
                    CariToplamDr = CariToplamCmd.ExecuteReader(CommandBehavior.CloseConnection);

                    if (CariToplamDr.Read())
                    {
                        Car002ID = Convert.ToInt32(CariToplamDr["CAR002_Row_ID"].ToString());
                        decimal CariTutar = Convert.ToDecimal(CariToplamDr["CAR002_DovizOdemeBorc"].ToString());

                        //if (DovizTutarimiz > EskiDoviz)
                        //{
                        ToplamDovizTutar = CariTutar + (DovizFarki);
                        //}

                        UpdateCar002 = new SqlConnection(Cs);

                        if (UpdateCar002.State == ConnectionState.Closed)
                            UpdateCar002.Open();

                        string UpdateCariTablosu = "UPDATE YNS" + Sirket.ToString() + ".CAR002 SET CAR002_DovizOdemeBorc=@DovizBorc, CAR002_DovizCekRiskiBorc=@DovizCekRiskiBorc " +
                        "WHERE CAR002_Row_ID=" + Car002ID + "";
                        UpdateCar002cmd = new SqlCommand(UpdateCariTablosu, UpdateCar002);
                        UpdateCar002cmd.Parameters.Add("@DovizBorc", SqlDbType.Decimal).Value = ToplamDovizTutar;
                        UpdateCar002cmd.Parameters.Add("@DovizCekRiskiBorc", SqlDbType.Decimal).Value = ToplamDovizTutar;
                        UpdateCar002cmd.ExecuteNonQuery();

                    }
                    CariToplamCmd.Dispose();
                    CariToplamDr.Dispose();
                    CariToplamDr.Close();
                }

                UpdateCariCon.Dispose();
                UpdateCariCon.Close();
                UpdateCariCmd.Dispose();

                MessageBox.Show("Çıkış Çeklerin Güncellenmesi Başarıyla Tamamlanmıştır");
            }
        }

        #endregion

        #region Formu Kapatıyoruz

        private void CikisCarileriSorgula_FormClosing(object sender, FormClosingEventArgs e)
        {
            CikisCarileriSorgula cexitSearch = new CikisCarileriSorgula();
            if (Sorgula != null)
            {
                Sorgula.Abort();
            }

            cexitSearch.Close();
        }

        #endregion

    }
}
