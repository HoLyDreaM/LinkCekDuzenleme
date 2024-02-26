using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FistasCekDuzenleme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Bağlantı ve Tanımlar

        string yol;
        SqlConnection con = new SqlConnection();
        iniOku.iniOku iniOku = new iniOku.iniOku(Application.StartupPath + "\\ayar.ini");
        Anaform anafrm;
        public Boolean kontrol = true;

        #endregion

        #region Şifreli Veriyi Çözüyoruz

        private static string Coz(string cozVeri)
        {
            byte[] cozByteDizi = System.Convert.FromBase64String(cozVeri);
            string orjinalVeri = System.Text.ASCIIEncoding.ASCII.GetString(cozByteDizi);
            return orjinalVeri;
        }

        #endregion

        #region veriyi Şifreliyoruz

        private static string Sifrele(string veri)
        {
            byte[] veriByteDizisi = System.Text.ASCIIEncoding.ASCII.GetBytes(veri);
            string sifrelenmisVeri = System.Convert.ToBase64String(veriByteDizisi);
            return sifrelenmisVeri;
        }

        #endregion

        #region Form Load İşlemleri

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            cmGirisTuru.SelectedIndex = 0;
            try
            {
                txtServer.Text = iniOku.IniReadValue("Ayar", "Server");
                txtSirket.Text = iniOku.IniReadValue("Ayar", "Sirket");
                txtKullanici.Text = iniOku.IniReadValue("Ayar", "Kullanici");
                txtSifre.Text = Coz(iniOku.IniReadValue("Ayar", "Sifre"));
                cmGirisTuru.SelectedIndex = Convert.ToInt32(iniOku.IniReadValue("Ayar", "GirisTuru"));
                oto.Checked = Convert.ToBoolean(iniOku.IniReadValue("Ayar", "oto"));

                if (oto.Checked && kontrol)
                    btnBaglan_Click(sender, e);
            }
            catch { }
        }

        #endregion

        #region Giriş Türü Seçimi

        private void cmGirisTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmGirisTuru.SelectedIndex == 0)
            {
                txtKullanici.Enabled = false;
                txtSifre.Enabled = false;
            }
            else
            {
                txtKullanici.Enabled = true;
                txtSifre.Enabled = true;
            }
        }

        #endregion

        #region Veritabanına Bağlanıyoruz

        private void btnBaglan_Click(object sender, EventArgs e)
        {
            if (cmGirisTuru.SelectedIndex == 0)
                Properties.Settings.Default["Cs1"] = "Data Source=" + txtServer.Text + ";Initial Catalog=YNS" + txtSirket.Text + ";User ID=YNS" + txtSirket.Text + ";Password=PSW" + txtSirket.Text + "";
            else
                Properties.Settings.Default["Cs1"] = "Data Source=" + txtServer.Text + ";Initial Catalog=YNS" + txtSirket.Text + ";User ID=" + txtKullanici.Text + ";Password=" + txtSifre.Text + "";

            yol = Properties.Settings.Default.Cs1;
            con.ConnectionString = yol;
            try
            {
                con.Open();
                con.Close();
                anafrm = new Anaform();

                if (kontrol) Program.ac.MainForm = anafrm;
                iniOku.IniWriteValue("Ayar", "Server", txtServer.Text);
                iniOku.IniWriteValue("Ayar", "Sirket", txtSirket.Text);
                iniOku.IniWriteValue("Ayar", "Sifre", Sifrele(txtSifre.Text));
                iniOku.IniWriteValue("Ayar", "Kullanici", txtKullanici.Text);
                iniOku.IniWriteValue("Ayar", "oto", oto.Checked.ToString());
                iniOku.IniWriteValue("Ayar", "GirisTuru", cmGirisTuru.SelectedIndex.ToString());
                con.Close();

                if (kontrol)
                {
                    anafrm.sirketAdi = txtSirket.Text;
                    anafrm.Show();
                }
                else
                {
                    Application.Restart();
                }
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Bağlantı Sağlanamadı");
            }
        }

        #endregion

    }
}
