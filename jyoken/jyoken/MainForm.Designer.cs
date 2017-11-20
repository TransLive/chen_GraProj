namespace jyoken
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnFileSelect = new System.Windows.Forms.Button();
            this.txtboxFileSelect = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnSaveRouteSelect = new System.Windows.Forms.Button();
            this.txtboxSaveRoute = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.picBoxSucceed = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnClear = new System.Windows.Forms.Button();
            this.cheLstBoxKeyWords = new System.Windows.Forms.CheckedListBox();
            this.promptLabel = new System.Windows.Forms.Label();
            this.btnSetting = new System.Windows.Forms.Button();
            this.cheboxAllSelect = new System.Windows.Forms.CheckBox();
            this.lblIntro = new System.Windows.Forms.Label();
            this.btnSavedFileOpen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSucceed)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFileSelect
            // 
            this.btnFileSelect.Location = new System.Drawing.Point(326, 16);
            this.btnFileSelect.Name = "btnFileSelect";
            this.btnFileSelect.Size = new System.Drawing.Size(154, 39);
            this.btnFileSelect.TabIndex = 0;
            this.btnFileSelect.Text = "ファイルを選択";
            this.btnFileSelect.UseVisualStyleBackColor = true;
            this.btnFileSelect.Click += new System.EventHandler(this.fileSelect_Click);
            // 
            // txtboxFileSelect
            // 
            this.txtboxFileSelect.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtboxFileSelect.Location = new System.Drawing.Point(30, 16);
            this.txtboxFileSelect.Multiline = true;
            this.txtboxFileSelect.Name = "txtboxFileSelect";
            this.txtboxFileSelect.ReadOnly = true;
            this.txtboxFileSelect.Size = new System.Drawing.Size(267, 39);
            this.txtboxFileSelect.TabIndex = 1;
            // 
            // btnProcess
            // 
            this.btnProcess.Enabled = false;
            this.btnProcess.Location = new System.Drawing.Point(197, 291);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(100, 39);
            this.btnProcess.TabIndex = 2;
            this.btnProcess.Text = "処理";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnSaveRouteSelect
            // 
            this.btnSaveRouteSelect.Location = new System.Drawing.Point(326, 91);
            this.btnSaveRouteSelect.Name = "btnSaveRouteSelect";
            this.btnSaveRouteSelect.Size = new System.Drawing.Size(154, 39);
            this.btnSaveRouteSelect.TabIndex = 3;
            this.btnSaveRouteSelect.Text = "保存フォルダー";
            this.btnSaveRouteSelect.UseVisualStyleBackColor = true;
            this.btnSaveRouteSelect.Click += new System.EventHandler(this.btnRouteSelect_Click);
            // 
            // txtboxSaveRoute
            // 
            this.txtboxSaveRoute.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtboxSaveRoute.Location = new System.Drawing.Point(30, 91);
            this.txtboxSaveRoute.Multiline = true;
            this.txtboxSaveRoute.Name = "txtboxSaveRoute";
            this.txtboxSaveRoute.ReadOnly = true;
            this.txtboxSaveRoute.Size = new System.Drawing.Size(267, 39);
            this.txtboxSaveRoute.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(197, 351);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 39);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "セーブ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // picBoxSucceed
            // 
            this.picBoxSucceed.Location = new System.Drawing.Point(303, 136);
            this.picBoxSucceed.Name = "picBoxSucceed";
            this.picBoxSucceed.Size = new System.Drawing.Size(194, 227);
            this.picBoxSucceed.TabIndex = 7;
            this.picBoxSucceed.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(30, 439);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(450, 33);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "クリア";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cheLstBoxKeyWords
            // 
            this.cheLstBoxKeyWords.BackColor = System.Drawing.SystemColors.Control;
            this.cheLstBoxKeyWords.CheckOnClick = true;
            this.cheLstBoxKeyWords.FormattingEnabled = true;
            this.cheLstBoxKeyWords.Location = new System.Drawing.Point(30, 146);
            this.cheLstBoxKeyWords.MinimumSize = new System.Drawing.Size(100, 184);
            this.cheLstBoxKeyWords.MultiColumn = true;
            this.cheLstBoxKeyWords.Name = "cheLstBoxKeyWords";
            this.cheLstBoxKeyWords.Size = new System.Drawing.Size(100, 184);
            this.cheLstBoxKeyWords.TabIndex = 10;
            this.cheLstBoxKeyWords.SelectedIndexChanged += new System.EventHandler(this.cheLstBoxKeyWords_SelectedIndexChanged);
            // 
            // promptLabel
            // 
            this.promptLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(62)))), ((int)(((byte)(150)))));
            this.promptLabel.Location = new System.Drawing.Point(27, 393);
            this.promptLabel.Name = "promptLabel";
            this.promptLabel.Size = new System.Drawing.Size(453, 43);
            this.promptLabel.TabIndex = 6;
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(197, 146);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(100, 121);
            this.btnSetting.TabIndex = 12;
            this.btnSetting.Text = "設定";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // cheboxAllSelect
            // 
            this.cheboxAllSelect.AutoSize = true;
            this.cheboxAllSelect.Location = new System.Drawing.Point(30, 360);
            this.cheboxAllSelect.Name = "cheboxAllSelect";
            this.cheboxAllSelect.Size = new System.Drawing.Size(102, 22);
            this.cheboxAllSelect.TabIndex = 13;
            this.cheboxAllSelect.Text = "全て選択";
            this.cheboxAllSelect.UseVisualStyleBackColor = true;
            this.cheboxAllSelect.Click += new System.EventHandler(this.cheboxAllSelect_Click);
            // 
            // lblIntro
            // 
            this.lblIntro.Location = new System.Drawing.Point(326, 146);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(154, 244);
            this.lblIntro.TabIndex = 14;
            this.lblIntro.Text = "label1";
            // 
            // btnSavedFileOpen
            // 
            this.btnSavedFileOpen.Location = new System.Drawing.Point(326, 351);
            this.btnSavedFileOpen.Name = "btnSavedFileOpen";
            this.btnSavedFileOpen.Size = new System.Drawing.Size(154, 39);
            this.btnSavedFileOpen.TabIndex = 15;
            this.btnSavedFileOpen.Text = "結果を開く";
            this.btnSavedFileOpen.UseVisualStyleBackColor = true;
            this.btnSavedFileOpen.Click += new System.EventHandler(this.btnSavedFileOpen_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 474);
            this.Controls.Add(this.btnSavedFileOpen);
            this.Controls.Add(this.lblIntro);
            this.Controls.Add(this.cheboxAllSelect);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.cheLstBoxKeyWords);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.picBoxSucceed);
            this.Controls.Add(this.promptLabel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtboxSaveRoute);
            this.Controls.Add(this.btnSaveRouteSelect);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.txtboxFileSelect);
            this.Controls.Add(this.btnFileSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(530, 530);
            this.MinimumSize = new System.Drawing.Size(530, 530);
            this.Name = "MainForm";
            this.Text = "条件要求抽出の神器";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSucceed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

#endregion

        private System.Windows.Forms.Button btnFileSelect;
        private System.Windows.Forms.TextBox txtboxFileSelect;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnSaveRouteSelect;
        private System.Windows.Forms.TextBox txtboxSaveRoute;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox picBoxSucceed;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckedListBox cheLstBoxKeyWords;
        private System.Windows.Forms.Label promptLabel;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.CheckBox cheboxAllSelect;
        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.Button btnSavedFileOpen;
#if DEBUG
        private System.Windows.Forms.Button button1;
#endif
    }
}

