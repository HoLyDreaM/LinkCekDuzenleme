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
using System.Xml;
using System.IO;
using System.Net;
using Microsoft.Win32;
using System.Diagnostics;

namespace FistasCekDuzenleme
{
    public partial class Anaform : Form
    {
        public Anaform()
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

        SqlConnection CariCon;
        SqlCommand CariCmd;
        SqlDataReader CariDr;

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

        public string sirketAdi;
        public CekSorgula cekler;
        public CariSorgulama carisorgula;
        public CikisCarileriSorgula cikisCekleri;
        public Form1 FrmGiris;
        public Fonksiyon fnk;
        public GorevZamanlama grvzamanlama;

        int UpdateID;
        string ID;
        double Tarih;
        int TarihRakam;
        string CekNo;
        string HesapNo;
        string Duzenleyen;
        string Sorgu;
        string Sirket;
        string HesapKodu;
        DateTime VadeTarihi;
        DateTime TarihSorgu;
        string EvrakSeriNo;
        short islemTipi;
        decimal Tutar;
        string Unvani;
        string DovizCinsi;
        decimal ToplamDovizTutar;
        decimal DovizKuru;
        decimal DovizTutari;
        string DovizTutariYuvarla;
        string Gorev;
        decimal EskiDoviz, DovizFarki;
        int USD, EURO, STERLIN, FRANK, Car002ID;
        string veriCek;
        string sitedenVeriCek;

        #endregion

        #region AnaForm Load işlemleri

        private void Anaform_Load(object sender, EventArgs e)
        {

            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            CheckForIllegalCrossThreadCalls = false;

            CariCon = new SqlConnection(Cs);
            UpdateCariCon = new SqlConnection(Cs);
            CekCon = new SqlConnection(Cs);
            UpdateCekCon = new SqlConnection(Cs);

            lblSirketAdi.Text = sirketAdi.ToString();

            AcilisFormu frmacilis = new AcilisFormu();
            frmacilis.MdiParent = this;
            frmacilis.Show();

            dosyaSurumunuCek();
            YeniSurumBilgisiniCek();
            surumKarsilastir();

            timer1.Start();
        }

        #endregion

        #region Çek Kayıtlarını Sorgulama Butonu

        private void btnCariCekleriSorgula_Click(object sender, EventArgs e)
        {
            if (carisorgula == null || carisorgula.IsDisposed)
            {
                carisorgula = new CariSorgulama();
                carisorgula.Owner = this;
                carisorgula.MdiParent = this;
                carisorgula.anaFrm = this;
                carisorgula.Show();
            }
            else
            {
                carisorgula.Activate();
            }
        }

        #endregion

        #region Login Giriş Ayarları Butonu

        private void btnGirisAyarlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FrmGiris == null || FrmGiris.IsDisposed)
            {
                FrmGiris = new Form1();
                FrmGiris.kontrol = false;
                FrmGiris.Show();
            }
            else
            {
                FrmGiris.Activate();
            }
        }

        #endregion

        #region Cari Çekleri Sorgulama Butonu

        private void btnCariCekler_Click(object sender, EventArgs e)
        {
            if (cekler == null || cekler.IsDisposed)
            {
                cekler = new CekSorgula();
                cekler.Owner = this;
                cekler.MdiParent = this;
                cekler.anaFrm = this;
                cekler.Show();
            }
            else
            {
                cekler.Activate();
            }
        }

        #endregion

        #region Görev Zamanlayıcı Butonu

        private void btnGorevZamanlayici_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvzamanlama == null || grvzamanlama.IsDisposed)
            {
                grvzamanlama = new GorevZamanlama();
                grvzamanlama.Show();
            }
            else
            {
                grvzamanlama.Activate();
            }
        }

        #endregion

        #region Timer İşlemleri

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTarih.Text = Convert.ToString(DateTime.Now);
            string TimerTarih = lblTarih.Text;
            string TimerTarih2 = TimerTarih.ToString().Substring(11, 8);

            Gorev = iniOku.IniReadValue("Zaman", "GorevSaati");

            if (TimerTarih2 == Gorev)
            {
                ds.CariKontrolCekleri.Clear();

                CariArama();
                CariCekleriGuncelle();

                ds.Cekler.Clear();

                CekSorgulama();
                CekGuncelleme();
            }
        }

        #endregion

        #region Cari Çekleri Arama Sorgumuz

        public void CariArama()
        {
            USD = Convert.ToInt32(iniOku.IniReadValue("Zaman", "USD"));
            EURO =  Convert.ToInt32(iniOku.IniReadValue("Zaman", "EURO"));
            STERLIN=  Convert.ToInt32(iniOku.IniReadValue("Zaman", "STERLIN"));
            FRANK = Convert.ToInt32(iniOku.IniReadValue("Zaman", "FRANK"));

            DateTime obj = new DateTime();
            obj = DateTime.Now;
            string str;
            Tarih = 0;
            Tarih = obj.ToOADate();
            str = Tarih.ToString().Substring(0, 5);
            TarihRakam = Convert.ToInt32(str);

            CariCon = new SqlConnection(Cs);

            Sorgu = "Select CAR003_Row_ID AS ID,CAR003_HesapKodu AS HesapKodu,CONVERT(DATETIME,CAR003_Tarih-2,102) AS Tarih,CAR003_IslemTipi AS IslemTipi, " +
                    "CAR003_EvrakSeriNo AS EvrakSeriNo,CAR003_Tutar AS Tutar,CONVERT(DATETIME,CAR003_VadeTarihi-2,102) AS VadeTarihi, " +
                     " (CASE CAR003_ParaBirimi " +
                    "WHEN '1' THEN 'YEREL' " +
                    "WHEN '2' THEN 'DÖVİZ' END) AS ParaBirimi,CAR003_DovizCinsi AS DovizCinsi,CAR003_DovizTutari AS EskiDoviz, " +
                    "(CASE CAR003_DovizCinsi " +
                    //"WHEN '' THEN 0 " +
                    "WHEN 'USD' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + USD + ")) " +
                    "WHEN 'EUR' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + EURO + ")) " +
                    "WHEN 'GBP' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + STERLIN + ")) " +
                    "WHEN 'CHF' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + FRANK + ")) " +
                    "END) AS DovizKuru,CAST(CAR003_Tutar / " +
                    "(CASE CAR003_DovizCinsi " +
                    //"WHEN '' THEN 1 " +
                    "WHEN 'USD' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + USD + ")) " +
                    "WHEN 'EUR' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + EURO + ")) " +
                    "WHEN 'GBP' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + STERLIN + ")) " +
                    "WHEN 'CHF' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + FRANK + ")) " +
                    "END)AS DECIMAL(21,2)) AS YeniDoviz,CAST(CAR003_DovizTutari - CAR003_Tutar / " +
                    "(CASE CAR003_DovizCinsi " +
                    //"WHEN '' THEN 1 " +
                    "WHEN 'USD' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + USD + ")) " +
                    "WHEN 'EUR' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + EURO + ")) " +
                    "WHEN 'GBP' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + STERLIN + ")) " +
                    "WHEN 'CHF' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + FRANK + ")) " +
                    "END)AS DECIMAL(21,2))*-1 AS DovizFarki From YNS" + sirketAdi + ".CAR003 " +
                    "Where CAR003_BA='1' AND CAR003_EvrakTipi='70' AND CAR003_VadeTarihi >= " + TarihRakam + " " +
                    "AND CAR003_DovizTutari <> 0 " +
                    "And CAR003_DovizCinsi<>'' And CAR003_DovizCinsi<>'TL' And CAR003_DovizCinsi IN " +
                    "(Select CAR002_ParaBirimi FROM YNS" + sirketAdi.ToString() + ".CAR002 " +
                    "Where CAR002_HesapKodu=CAR003_HesapKodu) " +
                    "ORDER BY ID ASC";

            if (CariCon.State == ConnectionState.Closed)
                CariCon.Open();

            CariCmd = new SqlCommand(Sorgu, CariCon);
            CariCmd.CommandTimeout = 120;
            CariDr = CariCmd.ExecuteReader(CommandBehavior.CloseConnection);
            ds.CariKontrolCekleri.TableName.Replace("YNS02012", "YNS" + sirketAdi.ToString());

            while (CariDr.Read())
            {
                Thread.Sleep(60);

                ID = CariDr["ID"].ToString();
                HesapKodu = CariDr["HesapKodu"].ToString();
                TarihSorgu = Convert.ToDateTime(CariDr["Tarih"].ToString());
                EvrakSeriNo = CariDr["EvrakSeriNo"].ToString();
                islemTipi = Convert.ToInt16(CariDr["IslemTipi"].ToString());
                Tutar = Convert.ToDecimal(CariDr["Tutar"].ToString());
                VadeTarihi = Convert.ToDateTime(CariDr["VadeTarihi"].ToString());
                DovizCinsi = CariDr["DovizCinsi"].ToString();
                DovizKuru = Convert.ToDecimal(CariDr["DovizKuru"].ToString());
                DovizTutariYuvarla = CariDr["YeniDoviz"].ToString();
                string parabirimi = CariDr["ParaBirimi"].ToString();
                int yuvarlama = Convert.ToInt32(Convert.ToDecimal(CariDr["YeniDoviz"].ToString()));
                DovizTutari = Convert.ToDecimal(DovizTutariYuvarla);
                EskiDoviz = Convert.ToDecimal(CariDr["EskiDoviz"]);
                DovizFarki = Convert.ToDecimal(CariDr["DovizFarki"]);

                //ds.CariKontrolCekleri.AddCariKontrolCekleriRow(ID, HesapKodu, islemTipi, EvrakSeriNo, Tutar, parabirimi.ToString(), DovizCinsi, DovizKuru, Convert.ToDateTime(TarihSorgu), Convert.ToDateTime(VadeTarihi), Convert.ToString(EskiDoviz), Convert.ToString(DovizFarki), DovizTutari);

                //ds.CariKontrolCekleri.AddCariKontrolCekleriRow(ID,HesapKodu,islemTipi,EvrakSeriNo,Tutar,1,DovizCinsi,DovizKuru,DovizTutari,Convert.ToDateTime(TarihSorgu),Convert.ToDateTime(VadeTarihi),Convert.ToString(EskiDoviz),Convert.ToString(DovizFarki));
            }

            //CariCon.Dispose();
            //CariCon.Close();
            CariCmd.Dispose();
            CariDr.Dispose();
            CariDr.Close();

        }

        #endregion

        #region Cari Cekleri Güncelleme İşlemi

        public void CariCekleriGuncelle()
        {
            foreach (DataRow row in ds.CariKontrolCekleri.Rows)
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

                string UpdateSorgumuz = "UPDATE YNS" + sirketAdi.ToString() + ".CAR003 SET CAR003_DovizKuru=@DovizKuru , CAR003_DovizTutari=@DovizTutari WHERE CAR003_Row_ID=" + UpdateID + "";

                UpdateCariCmd = new SqlCommand(UpdateSorgumuz, UpdateCariCon);
                UpdateCariCmd.Parameters.Add(@"DovizKuru", SqlDbType.Decimal).Value = DovizKurumuz;
                UpdateCariCmd.Parameters.Add("@DovizTutari", SqlDbType.Decimal).Value = DovizTutarimiz;
                UpdateCariCmd.ExecuteNonQuery();


                CariToplamCon = new SqlConnection(Cs);

                if (CariToplamCon.State == ConnectionState.Closed)
                    CariToplamCon.Open();

                string Sorgu3 = "SELECT CAR002_Row_ID, CAR002_HesapKodu, CAR002_Unvan1,CAR002_OdemeAlacak,CAR002_CekRiskiAlacak, " +
                       "CAR002_DovizOdemeAlacak FROM YNS" + sirketAdi + ".CAR002 " +
                       "Where CAR002_HesapKodu='" + HesapKodu + "'";

                CariToplamCmd = new SqlCommand(Sorgu3, CariToplamCon);
                CariToplamDr = CariToplamCmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (CariToplamDr.Read())
                {
                    Car002ID = Convert.ToInt32(CariToplamDr["CAR002_Row_ID"].ToString());
                    decimal CariTutar = Convert.ToDecimal(CariToplamDr["CAR002_DovizOdemeAlacak"].ToString());

                    //if (DovizTutarimiz > EskiDoviz)
                    //{
                    ToplamDovizTutar = CariTutar + (DovizFarki);
                    //}

                    UpdateCar002 = new SqlConnection(Cs);

                    if (UpdateCar002.State == ConnectionState.Closed)
                        UpdateCar002.Open();

                    string UpdateCariTablosu = "UPDATE YNS" + sirketAdi.ToString() + ".CAR002 SET CAR002_DovizOdemeAlacak=@DovizAlacak, CAR002_DovizCekRiskiAlacak=@DovizCekRiskiAlacak " +
                    "WHERE CAR002_Row_ID=" + Car002ID + "";
                    UpdateCar002cmd = new SqlCommand(UpdateCariTablosu, UpdateCar002);
                    UpdateCar002cmd.Parameters.Add("@DovizAlacak", SqlDbType.Decimal).Value = ToplamDovizTutar;
                    UpdateCar002cmd.Parameters.Add("@DovizCekRiskiAlacak", SqlDbType.Decimal).Value = ToplamDovizTutar;
                    UpdateCar002cmd.ExecuteNonQuery();

                }
                CariToplamCmd.Dispose();
                CariToplamDr.Dispose();
                CariToplamDr.Close();
            }

            //UpdateCariCon.Dispose();
            //UpdateCariCon.Close();
            UpdateCariCmd.Dispose();
        }

        #endregion

        #region Çekleri Sorguluyoruz

        public void CekSorgulama()
        {
            USD = Convert.ToInt32(iniOku.IniReadValue("Zaman", "USD"));
            EURO = Convert.ToInt32(iniOku.IniReadValue("Zaman", "EURO"));
            STERLIN = Convert.ToInt32(iniOku.IniReadValue("Zaman", "STERLIN"));
            FRANK = Convert.ToInt32(iniOku.IniReadValue("Zaman", "FRANK"));

            DateTime obj = new DateTime();
            obj = DateTime.Now;
            string str;
            Tarih = 0;
            Tarih = obj.ToOADate();
            str = Tarih.ToString().Substring(0, 5);
            TarihRakam = Convert.ToInt32(str);

            CekCon = new SqlConnection(Cs);

            Sorgu = "SELECT SCS003_Row_ID AS ID, SCS003_CekNo AS CekNo, SCS003_HesapKodu AS HesapKodu, SCS003_Tutar AS Tutar, " +
                    "CONVERT(DATETIME,SCS003_VadeTarihi-2,102) AS VadeTarihi,SCS003_Duzenleyen AS Duzenleyen, SCS003_DuzenleyenUnvani1 AS DuzenleyenUnvani, " +
                    "SCS003_DovizCinsi AS DovizCinsi, " +
                    "(CASE SCS003_DovizCinsi " +
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
                    "END) AS DovizTutari,(CASE SCS003_CekTipi " +
                    "WHEN '2' THEN 'YEREL' " +
                    "WHEN '1' THEN 'DÖVİZ' END) AS CekTipi  FROM YNS" + Sirket + ".SCS003 " +
                    "WHERE (SCS003_CekTipi = '1') AND (SCS003_VadeTarihi >= " + TarihRakam + ") " +
                    "AND SCS003_CH1='1' AND SCS003_DovizCinsi<>'' And SCS003_DovizCinsi IN " +
                    "(Select CAR002_ParaBirimi FROM YNS" + sirketAdi.ToString() + ".CAR002 " +
                    "Where CAR002_HesapKodu=SCS003_HesapKodu) " +
                    "Order By ID ASC";

            if (CekCon.State == ConnectionState.Closed)
                CekCon.Open();

            CekCmd = new SqlCommand(Sorgu, CekCon);
            CekCmd.CommandTimeout = 120;
            CekDr = CekCmd.ExecuteReader(CommandBehavior.CloseConnection);
            ds.Cekler.TableName.Replace("YNS02012", "YNS" + sirketAdi.ToString());

            while (CekDr.Read())
            {
                //Thread.Sleep(60);

                ID = CekDr["ID"].ToString();
                CekNo = CekDr["CekNo"].ToString();
                HesapNo = CekDr["HesapKodu"].ToString();
                Tutar = Convert.ToDecimal(CekDr["Tutar"].ToString());
                VadeTarihi = Convert.ToDateTime(CekDr["VadeTarihi"].ToString());
                Duzenleyen = CekDr["Duzenleyen"].ToString();
                Unvani = CekDr["DuzenleyenUnvani"].ToString();
                DovizCinsi = CekDr["DovizCinsi"].ToString();
                string CekTipi = CekDr["CekTipi"].ToString();
                DovizKuru = Convert.ToDecimal(CekDr["DovizKuru"].ToString());
                DovizTutariYuvarla = CekDr["DovizTutari"].ToString();
                int yuvarlama = Convert.ToInt32(Convert.ToDecimal(CekDr["DovizTutari"].ToString()));
                DovizTutari = Convert.ToDecimal(DovizTutariYuvarla);

                //ds.Cekler.AddCeklerRow(CekNo, HesapNo, Tutar, Duzenleyen, Unvani, DovizCinsi, CekTipi.ToString(), Convert.ToDateTime(VadeTarihi), DovizTutari, ID, DovizKuru);
            }

            //CekCon.Dispose();
            //CekCon.Close();
            CekCmd.Dispose();
            CekDr.Dispose();
            CekDr.Close();
        }

        #endregion

        #region Çekleri Güncelliyoruz

        public void CekGuncelleme()
        {
            foreach (DataRow rows in ds.Cekler.Rows)
            {
                UpdateCekCon = new SqlConnection(Cs);

                Thread.Sleep(10);
                UpdateID = Convert.ToInt32(rows["ID"].ToString());

                if (UpdateCekCon.State == ConnectionState.Closed)
                    UpdateCekCon.Open();

                decimal DovizKurumuz = Convert.ToDecimal(rows["DovizKuru"].ToString());
                decimal DovizTutarimiz = Convert.ToDecimal(rows["DovizTutari"].ToString());
                string UpdateSorgumuz = "UPDATE YNS" + sirketAdi.ToString() + ".SCS003 SET SCS003_DovizKuru1=@DovizKuru , SCS003_DovizTutari1=@DovizTutari WHERE SCS003_Row_ID=" + UpdateID + "";

                UpdateCekCmd = new SqlCommand(UpdateSorgumuz, UpdateCekCon);
                UpdateCekCmd.Parameters.Add(@"DovizKuru", SqlDbType.Decimal).Value = DovizKurumuz;
                UpdateCekCmd.Parameters.Add("@DovizTutari", SqlDbType.Decimal).Value = DovizTutarimiz;
                UpdateCekCmd.ExecuteNonQuery();
            }

            //UpdateCekCon.Dispose();
            //UpdateCekCon.Close();
            UpdateCekCmd.Dispose();
        }

        #endregion

        #region Ana Form Notifi İcon Resize Ayarı

        private void Anaform_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                Koseicon.Visible = true;

                Thread.Sleep(3000);
                Koseicon.ShowBalloonTip(1000, "Fistaş Çek Düzenleme", "Fistaş Çek Düzenleme Programı", ToolTipIcon.Info);
            }
        }

        #endregion

        #region Köşe İcon Mouse Double Click

        private void Koseicon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Maximized;
            Koseicon.Visible = false;
        }

        #endregion

        #region Fonksiyon Oluşturma Butonu

        private void btnFnkOlustur_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fnk == null || fnk.IsDisposed)
            {
                fnk = new Fonksiyon();
                fnk.Owner = this;
                //FrmDb.anaFrm = this;
                fnk.MdiParent = this;
                fnk.Show();
            }
            else
            {
                fnk.Activate();
            }
        }

        #endregion

        #region Yeni Sürüm Çekiyoruz

        private void YeniSurumBilgisiniCek()
        {
            try
            {
                XmlTextReader xmlDocument = new XmlTextReader("http://www.editorgroup.net/Programlar/Fistas/CekGuncelleme/guncelleme.xml");
                while (xmlDocument.Read())
                {
                    if (xmlDocument.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlDocument.Name)
                        {
                            case "surum":
                                sitedenVeriCek = Convert.ToString(xmlDocument.ReadString());
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sürüm Bilgisi Çekilirken Hata Meydana Geldi" + Environment.NewLine + "Hata Açıklaması : " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Dosya Sürümü Çekiyoruz

        private void dosyaSurumunuCek()
        {
            try
            {
                XmlTextReader xmlDocument = new XmlTextReader("guncelleme.xml");
                while (xmlDocument.Read())
                {
                    if (xmlDocument.NodeType == XmlNodeType.Element)
                    {
                        switch (xmlDocument.Name)
                        {
                            case "surum":
                                veriCek = Convert.ToString(xmlDocument.ReadString());
                                lblVersiyon.Text = veriCek;
                                break;

                        }
                    }
                }
                xmlDocument.Close();
            }
            catch (Exception ex)
            {
                lblVersiyon.Text = veriCek;
                this.Close();
                this.Dispose();
            }
        }

        #endregion

        #region Sürüm Karşılaştırıyoruz

        private void surumKarsilastir()
        {
            if (veriCek != sitedenVeriCek)
            {
                lblVersiyon.ForeColor = Color.Red;
                lblVersiyon.Text = sitedenVeriCek + " Versiyonu Çıkmıştır.Lütfen Güncelleme Yapınız.";
                //surumMbCek();
                btnGuncelle.Enabled = true;
            }
            else
            {
                lblVersiyon.Text = veriCek + " Güncel Sürüm";
                btnGuncelle.Enabled = false;
            }
        }

        #endregion

        #region Güncelleme Butonu

        private void btnGuncelle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.Start("ProgramGuncelleme.exe");
            Application.Exit();
        }

        #endregion

        #region Formu Kapatıyoruz

        private void Anaform_FormClosing(object sender, FormClosingEventArgs e)
        {
            Anaform anfrm = new Anaform();
            anfrm.Close();
        }

        #endregion

        #region Sql Sorgu Programı Kısayol Tuşu

        private void Anaform_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                Process.Start("Sorgulayici.exe");
            }
        }

        #endregion

        #region Alacak Çekleri Çıkış Bordrosu

        private void btnAlacakCekleriCikis_Click(object sender, EventArgs e)
        {
            if (cikisCekleri == null || cikisCekleri.IsDisposed)
            {
                cikisCekleri = new CikisCarileriSorgula();
                cikisCekleri.Owner = this;
                cikisCekleri.MdiParent = this;
                cikisCekleri.anaFrm = this;
                cikisCekleri.Show();
            }
            else
            {
                cikisCekleri.Activate();
            }
        }

        #endregion

    }
}
