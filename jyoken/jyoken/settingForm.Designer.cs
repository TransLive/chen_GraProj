namespace jyoken
{
    partial class SettingForm
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
            this.btnMecabSelect = new System.Windows.Forms.Button();
            this.txtBoxMecabLocation = new System.Windows.Forms.TextBox();
            this.btnMecabLocationConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMecabSelect
            // 
            this.btnMecabSelect.Location = new System.Drawing.Point(12, 74);
            this.btnMecabSelect.Name = "btnMecabSelect";
            this.btnMecabSelect.Size = new System.Drawing.Size(242, 58);
            this.btnMecabSelect.TabIndex = 0;
            this.btnMecabSelect.Text = "Mecabを選択";
            this.btnMecabSelect.UseVisualStyleBackColor = true;
            this.btnMecabSelect.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBoxMecabLocation
            // 
            this.txtBoxMecabLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxMecabLocation.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtBoxMecabLocation.Location = new System.Drawing.Point(12, 12);
            this.txtBoxMecabLocation.Multiline = true;
            this.txtBoxMecabLocation.Name = "txtBoxMecabLocation";
            this.txtBoxMecabLocation.ReadOnly = true;
            this.txtBoxMecabLocation.Size = new System.Drawing.Size(490, 56);
            this.txtBoxMecabLocation.TabIndex = 1;
            // 
            // btnMecabLocationConfirm
            // 
            this.btnMecabLocationConfirm.Enabled = false;
            this.btnMecabLocationConfirm.Location = new System.Drawing.Point(260, 74);
            this.btnMecabLocationConfirm.Name = "btnMecabLocationConfirm";
            this.btnMecabLocationConfirm.Size = new System.Drawing.Size(242, 58);
            this.btnMecabLocationConfirm.TabIndex = 2;
            this.btnMecabLocationConfirm.Text = "決定";
            this.btnMecabLocationConfirm.UseVisualStyleBackColor = true;
            this.btnMecabLocationConfirm.Click += new System.EventHandler(this.btnMecabLocationConfirm_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 144);
            this.Controls.Add(this.btnMecabLocationConfirm);
            this.Controls.Add(this.txtBoxMecabLocation);
            this.Controls.Add(this.btnMecabSelect);
            this.MaximumSize = new System.Drawing.Size(530, 200);
            this.MinimumSize = new System.Drawing.Size(530, 200);
            this.Name = "SettingForm";
            this.Text = "設定";
            this.Load += new System.EventHandler(this.settingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMecabSelect;
        private System.Windows.Forms.TextBox txtBoxMecabLocation;
        private System.Windows.Forms.Button btnMecabLocationConfirm;
    }
}