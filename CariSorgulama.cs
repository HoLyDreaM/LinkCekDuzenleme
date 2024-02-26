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
    public partial class CariSorgulama : Form
    {
        public CariSorgulama()
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
        string CekTipi;
        short islemTipi;
        decimal Tutar;
        decimal EskiTutar;
        decimal ToplamDovizTutar;
        decimal ToplamDovizTutar2;
        decimal CariTutar;
        string Unvani;
        string CekNo;
        string HesapNo;
        string parabirimi;
        string Duzenleyen;
        string DovizCinsi;
        decimal DovizKuru;
        decimal DovizTutari;
        decimal EskiDoviz,DovizFarki;
        string DovizTutariYuvarla;
        int USD, EURO, STERLIN, FRANK,Car002ID;

        #endregion

        #region Cari Sorgulama Form Load İşlemleri

        private void CariSorgulama_Load(object sender, EventArgs e)
        {
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

        #region Cari Çekleri Arama Sorgumuz

        public void CariArama()
        {
            CariCon = new SqlConnection(Cs);

            btnArama.Enabled = false;
            btnGuncelle.Enabled = false;

            grdCari.DataSource = null;
            grdCari.DataSource = ds.CariKontrolCekleri;

            USD = Convert.ToInt32(iniOku.IniReadValue("Zaman", "USD"));
            EURO = Convert.ToInt32(iniOku.IniReadValue("Zaman", "EURO"));
            STERLIN = Convert.ToInt32(iniOku.IniReadValue("Zaman", "STERLIN"));
            FRANK = Convert.ToInt32(iniOku.IniReadValue("Zaman", "FRANK"));

            Sorgu = "Select CAR003_Row_ID AS ID,CAR003_HesapKodu AS HesapKodu,CONVERT(DATETIME,CAR003_Tarih-2,102) AS Tarih,CAR003_IslemTipi AS IslemTipi, "+
                    "CAR003_EvrakSeriNo AS EvrakSeriNo,CAST((CASE CAR003_ParaBirimi  "+
                    "WHEN '2' THEN CAR003_DovizTutari * (CASE CAR003_DovizCinsi  "+
                    "WHEN 'USD' THEN(dbo.fn_DovizKuru(" + TarihRakam + ","+USD+"))  " +
                    "WHEN 'EUR' THEN(dbo.fn_DovizKuru(" + TarihRakam + ","+EURO+"))  " +
                    "WHEN 'GBP' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + STERLIN + "))  " +
                    "WHEN 'CHF' THEN(dbo.fn_DovizKuru(" + TarihRakam + ","+FRANK+"))END) " +
                    "WHEN '1' THEN CAR003_Tutar END)AS DECIMAL(21,2)) AS Tutar,(CASE CAR003_ParaBirimi  "+
                    "WHEN '2' THEN CAR003_Tutar WHEN '1' THEN CAR003_DovizTutari END) AS EskiTutar, "+
                    "CONVERT(DATETIME,CAR003_VadeTarihi-2,102) AS VadeTarihi,   "+
                    "(CASE CAR003_ParaBirimi  "+
                    "WHEN '1' THEN 'Yerel'  "+
                    "WHEN '2' THEN 'Doviz'  "+
                    "END) AS ParaBirimi,CAR003_DovizCinsi AS DovizCinsi, "+
                    "(CASE CAR003_ParaBirimi WHEN '1' THEN "+
                    "CAR003_DovizTutari + (CAST((CASE CAR003_ParaBirimi  "+
                    "WHEN '2' THEN ((CAR003_DovizTutari * (CASE CAR003_DovizCinsi  "+
                    "WHEN 'USD' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + USD + "))  " +
                    "WHEN 'EUR' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + EURO + "))  " +
                    "WHEN 'GBP' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + STERLIN + "))  " +
                    "WHEN 'CHF' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + FRANK + ")) " +
                    "END))- CAR003_Tutar) WHEN '1' THEN CAR003_DovizTutari - CAR003_Tutar / "+
                    "(CASE CAR003_DovizCinsi "+
                      "WHEN 'USD' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + USD + "))  " +
                    "WHEN 'EUR' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + EURO + "))  " +
                    "WHEN 'GBP' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + STERLIN + "))  " +
                    "WHEN 'CHF' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + FRANK + ")) " +
                    "END)  END)AS DECIMAL(21,2))*-1) WHEN '2' THEN CAR003_DovizTutari END) AS DovizTutari,"+
                    "(CASE CAR003_DovizCinsi "+
                    "WHEN 'USD' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + USD + "))  " +
                    "WHEN 'EUR' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + EURO + "))  " +
                    "WHEN 'GBP' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + STERLIN + "))  " +
                    "WHEN 'CHF' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + FRANK + ")) " +
                    "END) AS DovizKuru,CAST((CASE CAR003_ParaBirimi "+
                    "WHEN '2' THEN ((CAR003_DovizTutari * (CASE CAR003_DovizCinsi "+
                    "WHEN 'USD' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + USD + "))  " +
                    "WHEN 'EUR' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + EURO + "))  " +
                    "WHEN 'GBP' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + STERLIN + "))  " +
                    "WHEN 'CHF' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + FRANK + "))" +
                    "END))- CAR003_Tutar) WHEN '1' THEN (CAR003_DovizTutari - (CAR003_Tutar / "+
                    "(CASE CAR003_DovizCinsi " +
                    "WHEN 'USD' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + USD + "))  " +
                    "WHEN 'EUR' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + EURO + "))  " +
                    "WHEN 'GBP' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + STERLIN + "))  " +
                    "WHEN 'CHF' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + FRANK + ")) " +
                    "END)))  END)AS DECIMAL(21,2)) AS Fark From YNS"+Sirket.ToString()+".CAR003 "+
                    "Where CAR003_EvrakTipi='70' AND CAR003_VadeTarihi >= " + TarihRakam + " And CAR003_DovizCinsi<>'' And CAR003_DovizCinsi<>'TL' And " +
                    "CAR003_DovizCinsi IN "+
                    "(Select CAR002_ParaBirimi "+
                    "FROM YNS" + Sirket.ToString() + ".CAR002 Where " +
                    "CAR002_HesapKodu=CAR003_HesapKodu) " +
                    "ORDER BY ID ASC";

            if (CariCon.State == ConnectionState.Closed)
                CariCon.Open();

            CariCmd = new SqlCommand(Sorgu, CariCon);
            CariCmd.CommandTimeout = 120;
            CariDr = CariCmd.ExecuteReader(CommandBehavior.CloseConnection);
            ds.CariKontrolCekleri.TableName.Replace("YNS00100", "YNS" + Sirket.ToString());

            while (CariDr.Read())
            {
                Thread.Sleep(60);

                ID = CariDr["ID"].ToString();
                HesapKodu = CariDr["HesapKodu"].ToString();
                TarihSorgu = Convert.ToDateTime(CariDr["Tarih"].ToString());
                EvrakSeriNo = CariDr["EvrakSeriNo"].ToString();
                islemTipi=Convert.ToInt16(CariDr["IslemTipi"].ToString());
                Tutar = Convert.ToDecimal(CariDr["Tutar"].ToString());
                EskiTutar = Convert.ToDecimal(CariDr["EskiTutar"].ToString());
                VadeTarihi = Convert.ToDateTime(CariDr["VadeTarihi"].ToString());
                parabirimi = CariDr["ParaBirimi"].ToString();
                DovizCinsi = CariDr["DovizCinsi"].ToString();
                DovizKuru = Convert.ToDecimal(CariDr["DovizKuru"].ToString());
                DovizTutari = Convert.ToDecimal(CariDr["DovizTutari"].ToString());
                DovizFarki = Convert.ToDecimal(CariDr["Fark"]);

                ds.CariKontrolCekleri.AddCariKontrolCekleriRow(HesapKodu, VadeTarihi, islemTipi, EvrakSeriNo, Tutar, EskiTutar, VadeTarihi, parabirimi, DovizCinsi, DovizTutari, DovizKuru, DovizFarki, Convert.ToInt32(ID));
                //ds.CariKontrolCekleri.AddCariKontrolCekleriRow(ID, HesapKodu, islemTipi, EvrakSeriNo, Tutar, parabirimi.ToString(), DovizCinsi, DovizKuru, Convert.ToDateTime(TarihSorgu), Convert.ToDateTime(VadeTarihi), Convert.ToString(EskiDoviz), Convert.ToString(DovizFarki), DovizTutari);

                //ds.CariKontrolCekleri.AddCariKontrolCekleriRow(ID,HesapKodu,islemTipi,EvrakSeriNo,Tutar,1,DovizCinsi,DovizKuru,DovizTutari,Convert.ToDateTime(TarihSorgu),Convert.ToDateTime(VadeTarihi),Convert.ToString(EskiDoviz),Convert.ToString(DovizFarki));
            }

            CariCon.Dispose();
            CariCon.Close();
            CariCmd.Dispose();
            CariDr.Dispose();
            CariDr.Close();

            Search();

            MessageBox.Show("Toplam Bulunan Kayıt Sayısı : " + Convert.ToString(ds.CariKontrolCekleri.Rows.Count));

            btnArama.Enabled = true;
            btnGuncelle.Enabled = true;

        }

        #endregion

        #region Arama Butonu

        private void btnArama_Click(object sender, EventArgs e)
        {
            ds.CariKontrolCekleri.Clear();
            
            Sorgula = new Thread(new ThreadStart(CariArama));
            Sorgula.Priority = ThreadPriority.Highest;
            Sorgula.Start();
        }

        #endregion

        #region Cari Çek Güncelleme

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (ds.CariKontrolCekleri.Rows.Count <= 0)
            {
                MessageBox.Show("Lütfen Önce Çeklerini Sorgulayınız.");
            }
            else
            {
                UpdateCariCon = new SqlConnection(Cs);

                UpdateCekCon = new SqlConnection(Cs);

                foreach (DataRow row in ds.Cekler.Rows)
                {
                    Thread.Sleep(10);
                    UpdateID = Convert.ToInt32(row["ID"].ToString());
                    HesapKodu = row["HesapKodu"].ToString();
                    DovizTutari = Convert.ToDecimal(row["DovizTutari"].ToString().Replace(".", ","));
                    DovizKuru = Convert.ToDecimal(row["DovizKuru"].ToString().Replace(".", ","));
                    Tutar = Convert.ToDecimal(row["Tutar"].ToString().Replace(".", ","));
                    parabirimi = row["CekTipi"].ToString();

                    if (parabirimi == "Yerel")
                    {
                        queriesTableAdapter1.SCS003YerelParaGuncelleme(DovizKuru, Tutar, Convert.ToInt32(UpdateID));
                        
                    }
                    else if (parabirimi == "Doviz")
                    {
                        queriesTableAdapter1.SCS003DovizParaGuncelleme(DovizKuru, DovizTutari, Convert.ToInt32(UpdateID));
                    }

                    //if (UpdateCekCon.State == ConnectionState.Closed)
                    //    UpdateCekCon.Open();

                    //decimal DovizKurumuz = Convert.ToDecimal(row["DovizKuru"].ToString());
                    //decimal DovizTutarimiz = Convert.ToDecimal(row["DovizTutari"].ToString());
                    //string UpdateSorgumuz = "UPDATE YNS" + Sirket.ToString() + ".SCS003 SET SCS003_DovizKuru1=@DovizKuru , SCS003_DovizTutari1=@DovizTutari WHERE SCS003_Row_ID=" + UpdateID + "";

                    //UpdateCekCmd = new SqlCommand(UpdateSorgumuz, UpdateCekCon);
                    //UpdateCekCmd.Parameters.Add("@DovizKuru", SqlDbType.Decimal).Value = DovizKurumuz;
                    //UpdateCekCmd.Parameters.Add("@DovizTutari", SqlDbType.Decimal).Value = DovizTutarimiz;
                    //UpdateCekCmd.ExecuteNonQuery();


                }

                //UpdateCekCon.Dispose();
                //UpdateCekCon.Close();
                //UpdateCekCmd.Dispose();

                foreach (DataRow row in ds.CariKontrolCekleri.Rows)
                {
                    Thread.Sleep(10);
                    UpdateID = Convert.ToInt32(row["ID"].ToString());
                    HesapKodu = row["HesapKodu"].ToString();
                    EskiDoviz = Convert.ToDecimal(row["EskiTutar"].ToString());
                    DovizFarki = Convert.ToDecimal(row["Fark"].ToString());
                    DovizTutari = Convert.ToDecimal(row["DovizTutari"].ToString().Replace(".", ","));
                    DovizKuru = Convert.ToDecimal(row["DovizKuru"].ToString().Replace(".", ","));
                    Tutar = Convert.ToDecimal(row["Tutar"].ToString().Replace(".", ","));
                    parabirimi = row["ParaBirimi"].ToString();

                    if (parabirimi == "Yerel")
                    {
                        queriesTableAdapter1.CAR003YerelParaGuncelleme(DovizKuru, DovizTutari, Convert.ToInt32(UpdateID));
                    }
                    else if (parabirimi == "Doviz")
                    {
                        queriesTableAdapter1.CAR003DovizParaGuncelleme(DovizKuru, Tutar, Convert.ToInt32(UpdateID));
                    }

                    //if (UpdateCariCon.State == ConnectionState.Closed)
                    //    UpdateCariCon.Open();

                    //decimal DovizKurumuz = Convert.ToDecimal(row["DovizKuru"].ToString());
                    //decimal DovizTutarimiz = Convert.ToDecimal(row["YeniDoviz"].ToString());

                    //string UpdateSorgumuz = "UPDATE YNS" + Sirket.ToString() + ".CAR003 SET CAR003_DovizKuru=@DovizKuru , CAR003_DovizTutari=@DovizTutari WHERE CAR003_Row_ID=" + UpdateID + "";

                    //UpdateCariCmd = new SqlCommand(UpdateSorgumuz, UpdateCariCon);
                    //UpdateCariCmd.Parameters.Add("@DovizKuru", SqlDbType.Decimal).Value = DovizKurumuz;
                    //UpdateCariCmd.Parameters.Add("@DovizTutari", SqlDbType.Decimal).Value = DovizTutarimiz;
                    //UpdateCariCmd.ExecuteNonQuery();


                    //CariToplamCon = new SqlConnection(Cs);

                    //if (CariToplamCon.State == ConnectionState.Closed)
                    //    CariToplamCon.Open();

                    //string Sorgu3 = "SELECT CAR002_Row_ID, CAR002_HesapKodu, CAR002_Unvan1,CAR002_OdemeAlacak,CAR002_CekRiskiAlacak, " +
                    //       "CAR002_DovizOdemeAlacak FROM YNS" + Sirket + ".CAR002 " +
                    //       "Where CAR002_HesapKodu='" + HesapKodu + "'";

                    //CariToplamCmd = new SqlCommand(Sorgu3, CariToplamCon);
                    //CariToplamDr = CariToplamCmd.ExecuteReader(CommandBehavior.CloseConnection);

                    //if (CariToplamDr.Read())
                    //{
                    //    Car002ID = Convert.ToInt32(CariToplamDr["CAR002_Row_ID"].ToString());
                    //    decimal CariTutar = Convert.ToDecimal(CariToplamDr["CAR002_DovizOdemeAlacak"].ToString());

                    //    //if (DovizTutarimiz > EskiDoviz)
                    //    //{
                    //        ToplamDovizTutar = CariTutar + (DovizFarki);
                    //    //}

                    //    UpdateCar002 = new SqlConnection(Cs);

                    //    if (UpdateCar002.State == ConnectionState.Closed)
                    //        UpdateCar002.Open();

                    //    string UpdateCariTablosu = "UPDATE YNS" + Sirket.ToString() + ".CAR002 SET CAR002_DovizOdemeAlacak=@DovizAlacak, CAR002_DovizCekRiskiAlacak=@DovizCekRiskiAlacak " +
                    //    "WHERE CAR002_Row_ID=" + Car002ID + "";
                    //    UpdateCar002cmd = new SqlCommand(UpdateCariTablosu, UpdateCar002);
                    //    UpdateCar002cmd.Parameters.Add("@DovizAlacak", SqlDbType.Decimal).Value = ToplamDovizTutar;
                    //    UpdateCar002cmd.Parameters.Add("@DovizCekRiskiAlacak", SqlDbType.Decimal).Value = ToplamDovizTutar;
                    //    UpdateCar002cmd.ExecuteNonQuery();

                    //}
                    //CariToplamCmd.Dispose();
                    //CariToplamDr.Dispose();
                    //CariToplamDr.Close();
                }

                //UpdateCariCon.Dispose();
                //UpdateCariCon.Close();
                //UpdateCariCmd.Dispose();

                MessageBox.Show("Cari Çeklerin Güncellenmesi Başarıyla Tamamlanmıştır");
            }
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

            Sorgu = "SELECT SCS003_Row_ID AS ID, SCS003_CekNo AS CekNo, SCS003_HesapKodu AS HesapKodu, (CASE SCS003_CekTipi "+
                    "WHEN '1' THEN SCS003_Tutar "+
                    "WHEN '2' THEN SCS003_DovizTutari1 END) AS Tutar,  "+
                    "CONVERT(DATETIME,SCS003_VadeTarihi-2,102) AS VadeTarihi,SCS003_Duzenleyen AS Duzenleyen, SCS003_DuzenleyenUnvani1 AS DuzenleyenUnvani,  "+
                    "SCS003_DovizCinsi AS DovizCinsi, (CASE SCS003_DovizCinsi  "+
                    "WHEN 'USD' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + USD + "))  " +
                    "WHEN 'EUR' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + EURO + "))  " +
                    "WHEN 'GBP' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + STERLIN + "))  " +
                    "WHEN 'CHF' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + FRANK + "))  " +
                    "END) AS DovizKuru, CAST((CASE SCS003_CekTipi WHEN '1' THEN (SCS003_Tutar / (CASE SCS003_DovizCinsi  "+
                    "WHEN 'USD' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + USD + "))  " +
                    "WHEN 'EUR' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + EURO + "))  " +
                    "WHEN 'GBP' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + STERLIN + "))  " +
                    "WHEN 'CHF' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + FRANK + "))  " +
                    "END)) "+
                    "WHEN '2' THEN SCS003_DovizTutari1 * (CASE SCS003_DovizCinsi  "+
                    "WHEN 'USD' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + USD + "))  " +
                    "WHEN 'EUR' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + EURO + "))  " +
                    "WHEN 'GBP' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + STERLIN + "))  " +
                    "WHEN 'CHF' THEN(dbo.fn_DovizKuru(" + TarihRakam + "," + FRANK + "))  " +
                    "END) "+
                    " END)AS DECIMAL(21,2)) DovizTutari,(CASE SCS003_CekTipi  "+
                    "WHEN '1' THEN 'Yerel'  "+
                    "WHEN '2' THEN 'Doviz'  "+
                    "END) AS CekTipi FROM YNS"+Sirket.ToString()+".SCS003 WHERE (SCS003_VadeTarihi >= 41473) AND SCS003_CH1='1' AND SCS003_DovizCinsi<>'' And SCS003_DovizCinsi IN  " +
                    "(Select CAR002_ParaBirimi FROM YNS" + Sirket.ToString() + ".CAR002  " +
                    "Where CAR002_HesapKodu=SCS003_HesapKodu)  "+
                    "Order By ID ASC"; 

            if (CekCon.State == ConnectionState.Closed)
                CekCon.Open();

            CekCmd = new SqlCommand(Sorgu, CekCon);
            CekCmd.CommandTimeout = 120;
            CekDr = CekCmd.ExecuteReader(CommandBehavior.CloseConnection);
            ds.Cekler.TableName.Replace("YNS00100", "YNS" + Sirket.ToString());

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
                DovizKuru = Convert.ToDecimal(CekDr["DovizKuru"].ToString());
                DovizTutari = Convert.ToDecimal(CekDr["DovizTutari"].ToString());
                CekTipi = CekDr["CekTipi"].ToString();

                //ds.Cekler.AddCeklerRow(CekNo, HesapNo, Tutar, Duzenleyen, Unvani, DovizCinsi, CekTipi.ToString(), Convert.ToDateTime(VadeTarihi), DovizTutari, ID, DovizKuru);
                ds.Cekler.AddCeklerRow(Convert.ToInt32(ID), CekNo, HesapKodu, Tutar, VadeTarihi, Duzenleyen, Unvani, DovizCinsi, DovizKuru, DovizTutari, CekTipi);
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

        #region Formu Kapatıyoruz

        private void CariSorgulama_FormClosing(object sender, FormClosingEventArgs e)
        {
            CariSorgulama crSearch = new CariSorgulama();

            if (Sorgula != null)
            {
                Sorgula.Abort();
            }

            crSearch.Close();
        }

        #endregion

    }
}
