namespace FistasCekDuzenleme
{
    partial class CekSorgula
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnArama = new System.Windows.Forms.Button();
            this.grdCek = new DevExpress.XtraGrid.GridControl();
            this.ceklerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ds = new FistasCekDuzenleme.Ds();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCekNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHesapKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTutar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVadeTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDuzenleyen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDuzenleyenUnvani = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDovizCinsi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDovizKuru = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDovizTutari = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCekTipi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ceklerTableAdapter = new FistasCekDuzenleme.DsTableAdapters.CeklerTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceklerBindingSource)).BeginInit();
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
            this.panel1.TabIndex = 19;
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
            // grdCek
            // 
            this.grdCek.DataSource = this.ceklerBindingSource;
            this.grdCek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCek.Location = new System.Drawing.Point(0, 64);
            this.grdCek.MainView = this.gridView1;
            this.grdCek.Name = "grdCek";
            this.grdCek.Size = new System.Drawing.Size(972, 354);
            this.grdCek.TabIndex = 20;
            this.grdCek.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // ceklerBindingSource
            // 
            this.ceklerBindingSource.DataMember = "Cekler";
            this.ceklerBindingSource.DataSource = this.ds;
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
            this.colCekNo,
            this.colHesapKodu,
            this.colTutar,
            this.colVadeTarihi,
            this.colDuzenleyen,
            this.colDuzenleyenUnvani,
            this.colDovizCinsi,
            this.colDovizKuru,
            this.colDovizTutari,
            this.colCekTipi,
            this.colID});
            this.gridView1.GridControl = this.grdCek;
            this.gridView1.GroupPanelText = "  ";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colCekNo
            // 
            this.colCekNo.FieldName = "CekNo";
            this.colCekNo.Name = "colCekNo";
            this.colCekNo.Visible = true;
            this.colCekNo.VisibleIndex = 1;
            this.colCekNo.Width = 113;
            // 
            // colHesapKodu
            // 
            this.colHesapKodu.FieldName = "HesapKodu";
            this.colHesapKodu.Name = "colHesapKodu";
            this.colHesapKodu.Visible = true;
            this.colHesapKodu.VisibleIndex = 2;
            this.colHesapKodu.Width = 100;
            // 
            // colTutar
            // 
            this.colTutar.DisplayFormat.FormatString = "n2";
            this.colTutar.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colTutar.FieldName = "Tutar";
            this.colTutar.Name = "colTutar";
            this.colTutar.Visible = true;
            this.colTutar.VisibleIndex = 3;
            this.colTutar.Width = 100;
            // 
            // colVadeTarihi
            // 
            this.colVadeTarihi.DisplayFormat.FormatString = "d";
            this.colVadeTarihi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colVadeTarihi.FieldName = "VadeTarihi";
            this.colVadeTarihi.Name = "colVadeTarihi";
            this.colVadeTarihi.Visible = true;
            this.colVadeTarihi.VisibleIndex = 4;
            // 
            // colDuzenleyen
            // 
            this.colDuzenleyen.FieldName = "Duzenleyen";
            this.colDuzenleyen.Name = "colDuzenleyen";
            this.colDuzenleyen.Visible = true;
            this.colDuzenleyen.VisibleIndex = 5;
            this.colDuzenleyen.Width = 100;
            // 
            // colDuzenleyenUnvani
            // 
            this.colDuzenleyenUnvani.FieldName = "DuzenleyenUnvani";
            this.colDuzenleyenUnvani.Name = "colDuzenleyenUnvani";
            this.colDuzenleyenUnvani.Visible = true;
            this.colDuzenleyenUnvani.VisibleIndex = 6;
            this.colDuzenleyenUnvani.Width = 200;
            // 
            // colDovizCinsi
            // 
            this.colDovizCinsi.FieldName = "DovizCinsi";
            this.colDovizCinsi.Name = "colDovizCinsi";
            this.colDovizCinsi.Visible = true;
            this.colDovizCinsi.VisibleIndex = 7;
            // 
            // colDovizKuru
            // 
            this.colDovizKuru.FieldName = "DovizKuru";
            this.colDovizKuru.Name = "colDovizKuru";
            this.colDovizKuru.Visible = true;
            this.colDovizKuru.VisibleIndex = 8;
            // 
            // colDovizTutari
            // 
            this.colDovizTutari.DisplayFormat.FormatString = "n2";
            this.colDovizTutari.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colDovizTutari.FieldName = "DovizTutari";
            this.colDovizTutari.Name = "colDovizTutari";
            this.colDovizTutari.Visible = true;
            this.colDovizTutari.VisibleIndex = 9;
            this.colDovizTutari.Width = 150;
            // 
            // colCekTipi
            // 
            this.colCekTipi.FieldName = "CekTipi";
            this.colCekTipi.Name = "colCekTipi";
            this.colCekTipi.Visible = true;
            this.colCekTipi.VisibleIndex = 10;
            // 
            // colID
            // 
            this.colID.Caption = "Çek ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            // 
            // ceklerTableAdapter
            // 
            this.ceklerTableAdapter.ClearBeforeFill = true;
            // 
            // CekSorgula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 418);
            this.Controls.Add(this.grdCek);
            this.Controls.Add(this.panel1);
            this.Name = "CekSorgula";
            this.Text = "Çek Kayıtlarını Sorgula";
            this.Load += new System.EventHandler(this.CekSorgula_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceklerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnArama;
        private System.Windows.Forms.Button btnGuncelle;
        private DevExpress.XtraGrid.GridControl grdCek;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private Ds ds;
        private System.Windows.Forms.BindingSource sCS003BindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCekNo;
        private DevExpress.XtraGrid.Columns.GridColumn colHesapKodu;
        private DevExpress.XtraGrid.Columns.GridColumn colTutar;
        private DevExpress.XtraGrid.Columns.GridColumn colVadeTarihi;
        private DevExpress.XtraGrid.Columns.GridColumn colDuzenleyen;
        private DevExpress.XtraGrid.Columns.GridColumn colDuzenleyenUnvani;
        private DevExpress.XtraGrid.Columns.GridColumn colDovizCinsi;
        private DevExpress.XtraGrid.Columns.GridColumn colDovizKuru;
        private DevExpress.XtraGrid.Columns.GridColumn colDovizTutari;
        private DevExpress.XtraGrid.Columns.GridColumn colCekTipi;
        private System.Windows.Forms.BindingSource ceklerBindingSource;
        private DsTableAdapters.CeklerTableAdapter ceklerTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
    }
}