using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FistasCekDuzenleme
{
    public partial class GorevZamanlama : Form
    {
        public GorevZamanlama()
        {
            InitializeComponent();
        }

        #region Tanımlar

        public Anaform anaFrm
        {
            get;
            set;
        }

        iniOku.iniOku iniOku = new iniOku.iniOku(Application.StartupPath + "\\Zaman.ini");

        string USD,EURO,STERLIN,FRANK;

        #endregion

        #region Görev Ekliyoruz

        private void btnZamanEkle_Click(object sender, EventArgs e)
        {

            #region Kurların Ayarlanması

            if (rdUsdAlis.Checked==true)
            {
                USD = "1";
            }
            else if(rdUsdSatis.Checked==true)
            {
                USD = "2";
            }
            if (rdEuroAlis.Checked == true)
            {
                EURO = "3";
            }
            else if (rdEuroSatis.Checked == true)
            {
                EURO = "4";
            }
            if(rdSterlinAlis.Checked==true)
            {
                STERLIN = "5";
            }
            else if (rdSterlinSatis.Checked == true)
            {
                STERLIN = "6";
            }
            if (rdFrankAlis.Checked==true)
            {
                FRANK = "7";
            }
            else if (rdFrankSatis.Checked==true)
            {
                FRANK = "8";
            }

            #endregion

            iniOku.IniWriteValue("Zaman", "GorevSaati", txtSaatAyari.Text);
            iniOku.IniWriteValue("Zaman", "USD", USD);
            iniOku.IniWriteValue("Zaman", "EURO", EURO);
            iniOku.IniWriteValue("Zaman", "STERLIN", STERLIN);
            iniOku.IniWriteValue("Zaman", "FRANK", FRANK);

        }

        #endregion

        #region Görev Zamanlama Form Load İşlemleri

        private void GorevZamanlama_Load(object sender, EventArgs e)
        {
            txtSaatAyari.Text = iniOku.IniReadValue("Zaman", "GorevSaati");
            USD = iniOku.IniReadValue("Zaman", "USD");
            EURO = iniOku.IniReadValue("Zaman", "EURO");
            STERLIN = iniOku.IniReadValue("Zaman", "STERLIN");
            FRANK = iniOku.IniReadValue("Zaman", "FRANK");

            #region Radio Buton Checked Sorgusu

            if (USD == "1")
            {
                rdUsdAlis.Select();
            }
            if (USD == "2")
            {
                rdUsdSatis.Select();
            }
            if (EURO == "3")
            {
                rdEuroAlis.Select();
            }
            if (EURO == "4")
            {
                rdEuroSatis.Select();
            }
            if (STERLIN == "5")
            {
                rdSterlinAlis.Select();
            }
            if (STERLIN == "6")
            {
                rdSterlinSatis.Select();
            }
            if (FRANK == "7")
            {
                rdFrankAlis.Select();
            }
            if (FRANK == "8")
            {
                rdFrankSatis.Select();
            }

            #endregion
            
        }

        #endregion

    }
}
