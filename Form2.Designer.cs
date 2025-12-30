namespace GoogleMapsVeriÇekme
{
    partial class Form2
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
            this.btnStart = new ReaLTaiizor.Controls.MaterialButton();
            this.btnExport = new ReaLTaiizor.Controls.MaterialButton();
            this.cmbFilterField = new ReaLTaiizor.Controls.MaterialComboBox();
            this.txtKeywords = new ReaLTaiizor.Controls.MaterialTextBox();
            this.txtFilter = new ReaLTaiizor.Controls.MaterialTextBox();
            this.btnApplyFilter = new ReaLTaiizor.Controls.MaterialButton();
            this.materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
            this.materialLabel2 = new ReaLTaiizor.Controls.MaterialLabel();
            this.dgvBusinesses = new System.Windows.Forms.DataGridView();
            this.clbColumns = new System.Windows.Forms.CheckedListBox();
            this.chkShowBrowser = new ReaLTaiizor.Controls.MaterialCheckBox();
            this.lblCount = new ReaLTaiizor.Controls.MaterialLabel();
            this.lblStatus = new ReaLTaiizor.Controls.MaterialLabel();
            this.btnStop = new ReaLTaiizor.Controls.MaterialButton();
            this.materialTabControl1 = new ReaLTaiizor.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusinesses)).BeginInit();
            this.materialTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.AutoSize = false;
            this.btnStart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStart.Depth = 0;
            this.btnStart.DrawShadows = true;
            this.btnStart.HighEmphasis = true;
            this.btnStart.Icon = null;
            this.btnStart.Location = new System.Drawing.Point(512, 46);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnStart.MouseState = ReaLTaiizor.Helpers.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(160, 50);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Verileri Getir";
            this.btnStart.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnStart.UseAccentColor = false;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnExport
            // 
            this.btnExport.AutoSize = false;
            this.btnExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExport.Depth = 0;
            this.btnExport.DrawShadows = true;
            this.btnExport.HighEmphasis = true;
            this.btnExport.Icon = null;
            this.btnExport.Location = new System.Drawing.Point(680, 46);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnExport.MouseState = ReaLTaiizor.Helpers.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(160, 50);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Excel\'e Aktar";
            this.btnExport.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnExport.UseAccentColor = false;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // cmbFilterField
            // 
            this.cmbFilterField.AutoResize = false;
            this.cmbFilterField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbFilterField.Depth = 0;
            this.cmbFilterField.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbFilterField.DropDownHeight = 174;
            this.cmbFilterField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterField.DropDownWidth = 121;
            this.cmbFilterField.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbFilterField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbFilterField.FormattingEnabled = true;
            this.cmbFilterField.IntegralHeight = false;
            this.cmbFilterField.ItemHeight = 43;
            this.cmbFilterField.Location = new System.Drawing.Point(258, 144);
            this.cmbFilterField.MaxDropDownItems = 4;
            this.cmbFilterField.MouseState = ReaLTaiizor.Helpers.MaterialDrawHelper.MaterialMouseState.OUT;
            this.cmbFilterField.Name = "cmbFilterField";
            this.cmbFilterField.Size = new System.Drawing.Size(247, 49);
            this.cmbFilterField.TabIndex = 2;
            // 
            // txtKeywords
            // 
            this.txtKeywords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtKeywords.Depth = 0;
            this.txtKeywords.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtKeywords.Location = new System.Drawing.Point(12, 46);
            this.txtKeywords.MaxLength = 50;
            this.txtKeywords.MouseState = ReaLTaiizor.Helpers.MaterialDrawHelper.MaterialMouseState.OUT;
            this.txtKeywords.Multiline = false;
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.Size = new System.Drawing.Size(493, 50);
            this.txtKeywords.TabIndex = 3;
            this.txtKeywords.Text = "";
            // 
            // txtFilter
            // 
            this.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFilter.Depth = 0;
            this.txtFilter.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtFilter.Location = new System.Drawing.Point(12, 143);
            this.txtFilter.MaxLength = 50;
            this.txtFilter.MouseState = ReaLTaiizor.Helpers.MaterialDrawHelper.MaterialMouseState.OUT;
            this.txtFilter.Multiline = false;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(240, 50);
            this.txtFilter.TabIndex = 4;
            this.txtFilter.Text = "";
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.AutoSize = false;
            this.btnApplyFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnApplyFilter.Depth = 0;
            this.btnApplyFilter.DrawShadows = true;
            this.btnApplyFilter.HighEmphasis = true;
            this.btnApplyFilter.Icon = null;
            this.btnApplyFilter.Location = new System.Drawing.Point(512, 144);
            this.btnApplyFilter.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnApplyFilter.MouseState = ReaLTaiizor.Helpers.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(160, 50);
            this.btnApplyFilter.TabIndex = 5;
            this.btnApplyFilter.Text = "Filtrele";
            this.btnApplyFilter.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnApplyFilter.UseAccentColor = false;
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(12, 13);
            this.materialLabel1.MouseState = ReaLTaiizor.Helpers.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(423, 19);
            this.materialLabel1.TabIndex = 6;
            this.materialLabel1.Text = "Örnek Format : İL - İLÇE - SEKTÖR ( İstanbul Beşiktaş Kafe ) ";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(15, 118);
            this.materialLabel2.MouseState = ReaLTaiizor.Helpers.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(119, 19);
            this.materialLabel2.TabIndex = 7;
            this.materialLabel2.Text = "Sonuç Filtreleme";
            // 
            // dgvBusinesses
            // 
            this.dgvBusinesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBusinesses.Location = new System.Drawing.Point(18, 203);
            this.dgvBusinesses.Name = "dgvBusinesses";
            this.dgvBusinesses.RowHeadersWidth = 51;
            this.dgvBusinesses.RowTemplate.Height = 24;
            this.dgvBusinesses.Size = new System.Drawing.Size(1238, 441);
            this.dgvBusinesses.TabIndex = 8;
            // 
            // clbColumns
            // 
            this.clbColumns.FormattingEnabled = true;
            this.clbColumns.Location = new System.Drawing.Point(1031, 12);
            this.clbColumns.Name = "clbColumns";
            this.clbColumns.Size = new System.Drawing.Size(219, 174);
            this.clbColumns.TabIndex = 9;
            this.clbColumns.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbColumns_ItemCheck);
            // 
            // chkShowBrowser
            // 
            this.chkShowBrowser.AutoSize = true;
            this.chkShowBrowser.Depth = 0;
            this.chkShowBrowser.Location = new System.Drawing.Point(680, 143);
            this.chkShowBrowser.Margin = new System.Windows.Forms.Padding(0);
            this.chkShowBrowser.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkShowBrowser.MouseState = ReaLTaiizor.Helpers.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.chkShowBrowser.Name = "chkShowBrowser";
            this.chkShowBrowser.Ripple = true;
            this.chkShowBrowser.Size = new System.Drawing.Size(173, 37);
            this.chkShowBrowser.TabIndex = 10;
            this.chkShowBrowser.Text = "Tarayıcı Açılsınmı ?";
            this.chkShowBrowser.UseVisualStyleBackColor = true;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Depth = 0;
            this.lblCount.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblCount.Location = new System.Drawing.Point(869, 149);
            this.lblCount.MouseState = ReaLTaiizor.Helpers.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(1, 0);
            this.lblCount.TabIndex = 11;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Depth = 0;
            this.lblStatus.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblStatus.Location = new System.Drawing.Point(869, 180);
            this.lblStatus.MouseState = ReaLTaiizor.Helpers.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1, 0);
            this.lblStatus.TabIndex = 12;
            // 
            // btnStop
            // 
            this.btnStop.AutoSize = false;
            this.btnStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStop.Depth = 0;
            this.btnStop.DrawShadows = true;
            this.btnStop.HighEmphasis = true;
            this.btnStop.Icon = null;
            this.btnStop.Location = new System.Drawing.Point(848, 46);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnStop.MouseState = ReaLTaiizor.Helpers.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(160, 50);
            this.btnStop.TabIndex = 13;
            this.btnStop.Text = "Durdur";
            this.btnStop.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnStop.UseAccentColor = false;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Controls.Add(this.tabPage2);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(12, 12);
            this.materialTabControl1.MouseState = ReaLTaiizor.Helpers.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(200, 100);
            this.materialTabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(192, 71);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 71);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 722);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.chkShowBrowser);
            this.Controls.Add(this.clbColumns);
            this.Controls.Add(this.dgvBusinesses);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.btnApplyFilter);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.txtKeywords);
            this.Controls.Add(this.cmbFilterField);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnStart);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusinesses)).EndInit();
            this.materialTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.MaterialButton btnStart;
        private ReaLTaiizor.Controls.MaterialButton btnExport;
        private ReaLTaiizor.Controls.MaterialComboBox cmbFilterField;
        private ReaLTaiizor.Controls.MaterialTextBox txtKeywords;
        private ReaLTaiizor.Controls.MaterialTextBox txtFilter;
        private ReaLTaiizor.Controls.MaterialButton btnApplyFilter;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.DataGridView dgvBusinesses;
        private System.Windows.Forms.CheckedListBox clbColumns;
        private ReaLTaiizor.Controls.MaterialCheckBox chkShowBrowser;
        private ReaLTaiizor.Controls.MaterialLabel lblCount;
        private ReaLTaiizor.Controls.MaterialLabel lblStatus;
        private ReaLTaiizor.Controls.MaterialButton btnStop;
        private ReaLTaiizor.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}