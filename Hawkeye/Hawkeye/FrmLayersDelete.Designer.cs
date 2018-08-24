namespace Hawkeye
{
    partial class FrmLayersDelete
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
            this.LayersCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.SelectAll = new System.Windows.Forms.Button();
            this.DeleteSelectedLayers = new System.Windows.Forms.Button();
            this.CancelSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LayersCheckedListBox
            // 
            this.LayersCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LayersCheckedListBox.FormattingEnabled = true;
            this.LayersCheckedListBox.Location = new System.Drawing.Point(12, 44);
            this.LayersCheckedListBox.MultiColumn = true;
            this.LayersCheckedListBox.Name = "LayersCheckedListBox";
            this.LayersCheckedListBox.Size = new System.Drawing.Size(192, 180);
            this.LayersCheckedListBox.TabIndex = 0;
            // 
            // SelectAll
            // 
            this.SelectAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SelectAll.Location = new System.Drawing.Point(12, 12);
            this.SelectAll.Name = "SelectAll";
            this.SelectAll.Size = new System.Drawing.Size(60, 23);
            this.SelectAll.TabIndex = 1;
            this.SelectAll.Text = "全选";
            this.SelectAll.UseVisualStyleBackColor = true;
            this.SelectAll.Click += new System.EventHandler(this.SelectAll_Click);
            // 
            // DeleteSelectedLayers
            // 
            this.DeleteSelectedLayers.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DeleteSelectedLayers.Location = new System.Drawing.Point(78, 12);
            this.DeleteSelectedLayers.Name = "DeleteSelectedLayers";
            this.DeleteSelectedLayers.Size = new System.Drawing.Size(60, 23);
            this.DeleteSelectedLayers.TabIndex = 1;
            this.DeleteSelectedLayers.Text = "删除";
            this.DeleteSelectedLayers.UseVisualStyleBackColor = true;
            this.DeleteSelectedLayers.Click += new System.EventHandler(this.DeleteSelectedLayers_Click);
            // 
            // CancelSelect
            // 
            this.CancelSelect.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CancelSelect.Location = new System.Drawing.Point(144, 12);
            this.CancelSelect.Name = "CancelSelect";
            this.CancelSelect.Size = new System.Drawing.Size(60, 23);
            this.CancelSelect.TabIndex = 1;
            this.CancelSelect.Text = "取消";
            this.CancelSelect.UseVisualStyleBackColor = true;
            this.CancelSelect.Click += new System.EventHandler(this.CancelSelect_Click);
            // 
            // FrmLayersDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 241);
            this.Controls.Add(this.CancelSelect);
            this.Controls.Add(this.DeleteSelectedLayers);
            this.Controls.Add(this.SelectAll);
            this.Controls.Add(this.LayersCheckedListBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLayersDelete";
            this.Text = "删除图层";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox LayersCheckedListBox;
        private System.Windows.Forms.Button SelectAll;
        private System.Windows.Forms.Button DeleteSelectedLayers;
        private System.Windows.Forms.Button CancelSelect;
    }
}