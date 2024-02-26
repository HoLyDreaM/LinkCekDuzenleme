namespace FistasCekDuzenleme
{
    partial class CariSorgulama
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition4 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnArama = new System.Windows.Forms.Button();
            this.grdCari = new DevExpress.XtraGrid.GridControl();
            this.cariKontrolCekleriBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ds = new FistasCekDuzenleme.Ds();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCariID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHesapKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTarih = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIslemTipi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEvrakSeriNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTutar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEskiTutar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVadeTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParaBirimi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDovizCinsi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDovizKuru = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDovizTutari = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cariKontrolCekleriTableAdapter = new FistasCekDuzenleme.DsTableAdapters.CariKontrolCekleriTableAdapter();
            this.queriesTableAdapter1 = new FistasCekDuzenleme.DsTableAdapters.QueriesTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cariKontrolCekleriBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGuncelle);
            this.panel1.Controls.Add(this.btnArama);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 64);
            this.panel1.TabIndex = 20;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.Image = global::FistasCekDuzenleme.Properties.Resources.update;
            this.btnGuncelle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuncelle.Location = new System.Drawing.Point(97, 6);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(98, 49);
            this.btnGuncelle.TabIndex = 5;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnArama
            // 
            this.btnArama.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnArama.Image = global::FistasCekDuzenleme.Properties.Resources.ara;
            this.btnArama.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArama.Location = new System.Drawing.Point(10, 6);
            this.btnArama.Name = "btnArama";
            this.btnArama.Size = new System.Drawing.Size(81, 49);
            this.btnArama.TabIndex = 5;
            this.btnArama.Text = "Arama";
            this.btnArama.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnArama.UseVisualStyleBackColor = true;
            this.btnArama.Click += new System.EventHandler(this.btnArama_Click);
            // 
            // grdCari
            // 
            this.grdCari.DataSource = this.cariKontrolCekleriBindingSource;
            this.grdCari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCari.Location = new System.Drawing.Point(0, 64);
            this.grdCari.MainView = this.gridView1;
            this.grdCari.Name = "grdCari";
            this.grdCari.Size = new System.Drawing.Size(972, 354);
            this.grdCari.TabIndex = 21;
            this.grdCari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // cariKontrolCekleriBindingSource
            // 
            this.cariKontrolCekleriBindingSource.DataMember = "CariKontrolCekleri";
            this.cariKontrolCekleriBindingSource.DataSource = this.ds;
            // 
            // ds
            // 
            this.ds.DataSetName = "Ds";
            this.ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Appearance.GroupRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCariID,
            this.colHesapKodu,
            this.colTarih,
            this.colIslemTipi,
            this.colEvrakSeriNo,
            this.colTutar,
            this.colEskiTutar,
            this.colVadeTarihi,
            this.colParaBirimi,
            this.colDovizCinsi,
            this.colDovizKuru,
            this.colDovizTutari,
            this.colFark});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.White;
            styleFormatCondition1.Appearance.BackColor2 = System.Drawing.Color.Red;
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition1.Expression = "IsNullOrEmpty([cha_kod])";
            styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.White;
            styleFormatCondition2.Appearance.BackColor2 = System.Drawing.Color.Green;
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition2.Expression = " Not  IsNullOrEmpty([cha_kod])";
            styleFormatCondition3.Appearance.BackColor = System.Drawing.Color.White;
            styleFormatCondition3.Appearance.BackColor2 = System.Drawing.Color.Red;
            styleFormatCondition3.Appearance.Options.UseBackColor = true;
            styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition3.Expression = "IsNullOrEmpty([cha_kasa_hizkod])";
            styleFormatCondition4.Appearance.BackColor = System.Drawing.Color.White;
            styleFormatCondition4.Appearance.BackColor2 = System.Drawing.Color.Green;
            styleFormatCondition4.Appearance.Options.UseBackColor = true;
            styleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition4.Expression = " Not  IsNullOrEmpty([cha_kasa_hizkod])";
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2,
            styleFormatCondition3,
            styleFormatCondition4});
            this.gridView1.GridControl = this.grdCari;
            this.gridView1.GroupPanelText = "  ";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colCariID
            // 
            this.colCariID.Caption = "Cari ID";
            this.colCariID.FieldName = "ID";
            this.colCariID.Name = "colCariID";
            this.colCariID.OptionsColumn.ReadOnly = true;
            this.colCariID.Visible = true;
            this.colCariID.VisibleIndex = 0;
            // 
            // colHesapKodu
            // 
            this.colHesapKodu.Caption = "Hesap Kodu";
            this.colHesapKodu.FieldName = "HesapKodu";
            this.colHesapKodu.Name = "colHesapKodu";
            this.colHesapKodu.OptionsColumn.ReadOnly = true;
            this.colHesapKodu.Visible = true;
            this.colHesapKodu.VisibleIndex = 1;
            this.colHesapKodu.Width = 123;
            // 
            // colTarih
            // 
            this.colTarih.Caption = "Tarih";
            this.colTarih.DisplayFormat.FormatString = "d";
            this.colTarih.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTarih.FieldName = "Tarih";
            this.colTarih.Name = "colTarih";
            this.colTarih.OptionsColumn.ReadOnly = true;
            this.colTarih.Visible = true;
            this.colTarih.VisibleIndex = 2;
            this.colTarih.Width = 95;
            // 
            // colIslemTipi
            // 
            this.colIslemTipi.Caption = "Islem Tipi";
            this.colIslemTipi.FieldName = "IslemTipi";
            this.colIslemTipi.Name = "colIslemTipi";
            this.colIslemTipi.OptionsColumn.ReadOnly = true;
            this.colIslemTipi.Visible = true;
            this.colIslemTipi.VisibleIndex = 3;
            this.colIslemTipi.Width = 55;
            // 
            // colEvrakSeriNo
            // 
            this.colEvrakSeriNo.Caption = "Evrak Seri No";
            this.colEvrakSeriNo.FieldName = "EvrakSeriNo";
            this.colEvrakSeriNo.Name = "colEvrakSeriNo";
            this.colEvrakSeriNo.OptionsColumn.ReadOnly = true;
            this.colEvrakSeriNo.Visible = true;
            this.colEvrakSeriNo.VisibleIndex = 4;
            // 
            // colTutar
            // 
            this.colTutar.Caption = "Tutar";
            this.colTutar.FieldName = "Tutar";
            this.colTutar.Name = "colTutar";
            this.colTutar.OptionsColumn.ReadOnly = true;
            this.colTutar.Visible = true;
            this.colTutar.VisibleIndex = 5;
            this.colTutar.Width = 100;
            // 
            // colEskiTutar
            // 
            this.colEskiTutar.Caption = "Eski Tutar";
            this.colEskiTutar.FieldName = "EskiTutar";
            this.colEskiTutar.Name = "colEskiTutar";
            this.colEskiTutar.Visible = true;
            this.colEskiTutar.VisibleIndex = 6;
            // 
            // colVadeTarihi
            // 
            this.colVadeTarihi.Caption = "Vade Tarihi";
            this.colVadeTarihi.DisplayFormat.FormatString = "d";
            this.colVadeTarihi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colVadeTarihi.FieldName = "VadeTarihi";
            this.colVadeTarihi.Name = "colVadeTarihi";
            this.colVadeTarihi.OptionsColumn.ReadOnly = true;
            this.colVadeTarihi.Visible = true;
            this.colVadeTarihi.VisibleIndex = 7;
            this.colVadeTarihi.Width = 100;
            // 
            // colParaBirimi
            // 
            this.colParaBirimi.Caption = "Para Birimi";
            this.colParaBirimi.FieldName = "ParaBirimi";
            this.colParaBirimi.Name = "colParaBirimi";
            this.colParaBirimi.OptionsColumn.ReadOnly = true;
            this.colParaBirimi.Visible = true;
            this.colParaBirimi.VisibleIndex = 8;
            // 
            // colDovizCinsi
            // 
            this.colDovizCinsi.Caption = "Doviz Cinsi";
            this.colDovizCinsi.FieldName = "DovizCinsi";
            this.colDovizCinsi.Name = "colDovizCinsi";
            this.colDovizCinsi.OptionsColumn.ReadOnly = true;
            this.colDovizCinsi.Visible = true;
            this.colDovizCinsi.VisibleIndex = 9;
            this.colDovizCinsi.Width = 80;
            // 
            // colDovizKuru
            // 
            this.colDovizKuru.Caption = "Doviz Kuru";
            this.colDovizKuru.FieldName = "DovizKuru";
            this.colDovizKuru.Name = "colDovizKuru";
            this.colDovizKuru.OptionsColumn.ReadOnly = true;
            this.colDovizKuru.Visible = true;
            this.colDovizKuru.VisibleIndex = 10;
            this.colDovizKuru.Width = 95;
            // 
            // colDovizTutari
            // 
            this.colDovizTutari.Caption = "Doviz Tutarı";
            this.colDovizTutari.DisplayFormat.FormatString = "n2";
            this.colDovizTutari.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colDovizTutari.FieldName = "DovizTutari";
            this.colDovizTutari.Name = "colDovizTutari";
            this.colDovizTutari.OptionsColumn.ReadOnly = true;
            this.colDovizTutari.Visible = true;
            this.colDovizTutari.VisibleIndex = 11;
            this.colDovizTutari.Width = 95;
            // 
            // colFark
            // 
            this.colFark.Caption = "Fark";
            this.colFark.FieldName = "Fark";
            this.colFark.Name = "colFark";
            this.colFark.Visible = true;
            this.colFark.VisibleIndex = 12;
            // 
            // cariKontrolCekleriTableAdapter
            // 
            this.cariKontrolCekleriTableAdapter.ClearBeforeFill = true;
            // 
            // CariSorgulama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 418);
            this.Controls.Add(this.grdCari);
            this.Controls.Add(this.panel1);
            this.Name = "CariSorgulama";
            this.Text = "Cari Çek Kayıtlarını Sorgula";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CariSorgulama_FormClosing);
            this.Load += new System.EventHandler(this.CariSorgulama_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cariKontrolCekleriBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnArama;
        private DevExpress.XtraGrid.GridControl grdCari;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colHesapKodu;
        private DevExpress.XtraGrid.Columns.GridColumn colTarih;
        private DevExpress.XtraGrid.Columns.GridColumn colIslemTipi;
        private DevExpress.XtraGrid.Columns.GridColumn colEvrakSeriNo;
        private DevExpress.XtraGrid.Columns.GridColumn colTutar;
        private DevExpress.XtraGrid.Columns.GridColumn colVadeTarihi;
        private DevExpress.XtraGrid.Columns.GridColumn colParaBirimi;
        private DevExpress.XtraGrid.Columns.GridColumn colDovizCinsi;
        private DevExpress.XtraGrid.Columns.GridColumn colDovizKuru;
        private DevExpress.XtraGrid.Columns.GridColumn colDovizTutari;
        private Ds ds;
        private System.Windows.Forms.BindingSource cariKontrolCekleriBindingSource;
        private DsTableAdapters.CariKontrolCekleriTableAdapter cariKontrolCekleriTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colCariID;
        private DevExpress.XtraGrid.Columns.GridColumn colEskiTutar;
        private DevExpress.XtraGrid.Columns.GridColumn colFark;
        private DsTableAdapters.QueriesTableAdapter queriesTableAdapter1;
    }
}