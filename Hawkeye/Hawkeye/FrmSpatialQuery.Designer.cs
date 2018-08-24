namespace Hawkeye
{
    partial class FrmSpatialQuery
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
            this.QueryResultGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.QueryResultGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // QueryResultGridView
            // 
            this.QueryResultGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QueryResultGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.QueryResultGridView.Location = new System.Drawing.Point(1, 0);
            this.QueryResultGridView.Name = "QueryResultGridView";
            this.QueryResultGridView.RowTemplate.Height = 23;
            this.QueryResultGridView.Size = new System.Drawing.Size(282, 261);
            this.QueryResultGridView.TabIndex = 0;
            // 
            // FrmSpatialQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.QueryResultGridView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSpatialQuery";
            this.Text = "空间查询";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmSpatialQuery_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.QueryResultGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView QueryResultGridView;
    }
}