namespace Hawkeye
{
    partial class FrmSelectLayer
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
            this.LayerComboBox2 = new System.Windows.Forms.ComboBox();
            this.Confrim = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LayerComboBox2
            // 
            this.LayerComboBox2.FormattingEnabled = true;
            this.LayerComboBox2.Location = new System.Drawing.Point(44, 48);
            this.LayerComboBox2.Name = "LayerComboBox2";
            this.LayerComboBox2.Size = new System.Drawing.Size(191, 20);
            this.LayerComboBox2.TabIndex = 0;
            // 
            // Confrim
            // 
            this.Confrim.Location = new System.Drawing.Point(44, 89);
            this.Confrim.Name = "Confrim";
            this.Confrim.Size = new System.Drawing.Size(70, 34);
            this.Confrim.TabIndex = 1;
            this.Confrim.Text = "确定";
            this.Confrim.UseVisualStyleBackColor = true;
            this.Confrim.Click += new System.EventHandler(this.Confrim_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(165, 89);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(70, 34);
            this.Cancel.TabIndex = 2;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // FrmSelectLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 155);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Confrim);
            this.Controls.Add(this.LayerComboBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSelectLayer";
            this.Text = "选择图层";
            this.Load += new System.EventHandler(this.FrmSelectLayer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox LayerComboBox2;
        private System.Windows.Forms.Button Confrim;
        private System.Windows.Forms.Button Cancel;
    }
}