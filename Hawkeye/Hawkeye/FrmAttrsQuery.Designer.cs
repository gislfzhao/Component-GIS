namespace Hawkeye
{
    partial class FrmAttrsQuery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LayerComboBox = new System.Windows.Forms.ComboBox();
            this.LayerName = new System.Windows.Forms.Label();
            this.FieldName = new System.Windows.Forms.Label();
            this.FieldComboBox = new System.Windows.Forms.ComboBox();
            this.QueryButton = new System.Windows.Forms.Button();
            this.QueryResultGridView = new System.Windows.Forms.DataGridView();
            this.QueryResult = new System.Windows.Forms.Label();
            this.FieldValue = new System.Windows.Forms.Label();
            this.ValueComboBox = new System.Windows.Forms.ComboBox();
            this.QueryTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.QueryResultGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // LayerComboBox
            // 
            this.LayerComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LayerComboBox.FormattingEnabled = true;
            this.LayerComboBox.Location = new System.Drawing.Point(132, 11);
            this.LayerComboBox.Name = "LayerComboBox";
            this.LayerComboBox.Size = new System.Drawing.Size(121, 20);
            this.LayerComboBox.TabIndex = 0;
            this.LayerComboBox.SelectedIndexChanged += new System.EventHandler(this.LayerComboBox_SelectedIndexChanged);
            // 
            // LayerName
            // 
            this.LayerName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LayerName.AutoSize = true;
            this.LayerName.BackColor = System.Drawing.Color.White;
            this.LayerName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LayerName.Location = new System.Drawing.Point(46, 13);
            this.LayerName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LayerName.Name = "LayerName";
            this.LayerName.Size = new System.Drawing.Size(60, 16);
            this.LayerName.TabIndex = 1;
            this.LayerName.Text = "图  层";
            // 
            // FieldName
            // 
            this.FieldName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.FieldName.AutoSize = true;
            this.FieldName.BackColor = System.Drawing.Color.White;
            this.FieldName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FieldName.Location = new System.Drawing.Point(46, 43);
            this.FieldName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FieldName.Name = "FieldName";
            this.FieldName.Size = new System.Drawing.Size(60, 16);
            this.FieldName.TabIndex = 3;
            this.FieldName.Text = "字  段";
            // 
            // FieldComboBox
            // 
            this.FieldComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.FieldComboBox.FormattingEnabled = true;
            this.FieldComboBox.Location = new System.Drawing.Point(132, 41);
            this.FieldComboBox.Name = "FieldComboBox";
            this.FieldComboBox.Size = new System.Drawing.Size(121, 20);
            this.FieldComboBox.TabIndex = 2;
            this.FieldComboBox.SelectedIndexChanged += new System.EventHandler(this.FieldComboBox_SelectedIndexChanged);
            // 
            // QueryButton
            // 
            this.QueryButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.QueryButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QueryButton.Location = new System.Drawing.Point(233, 102);
            this.QueryButton.Name = "QueryButton";
            this.QueryButton.Size = new System.Drawing.Size(54, 31);
            this.QueryButton.TabIndex = 4;
            this.QueryButton.Text = "查询";
            this.QueryButton.UseVisualStyleBackColor = true;
            this.QueryButton.Click += new System.EventHandler(this.QueryButton_Click);
            // 
            // QueryResultGridView
            // 
            this.QueryResultGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.QueryResultGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.QueryResultGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.QueryResultGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.QueryResultGridView.Location = new System.Drawing.Point(28, 141);
            this.QueryResultGridView.Name = "QueryResultGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.QueryResultGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.QueryResultGridView.RowTemplate.Height = 23;
            this.QueryResultGridView.Size = new System.Drawing.Size(259, 299);
            this.QueryResultGridView.TabIndex = 6;
            // 
            // QueryResult
            // 
            this.QueryResult.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.QueryResult.AutoSize = true;
            this.QueryResult.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QueryResult.Location = new System.Drawing.Point(31, 118);
            this.QueryResult.Name = "QueryResult";
            this.QueryResult.Size = new System.Drawing.Size(63, 14);
            this.QueryResult.TabIndex = 7;
            this.QueryResult.Text = "查询结果";
            // 
            // FieldValue
            // 
            this.FieldValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.FieldValue.AutoSize = true;
            this.FieldValue.BackColor = System.Drawing.Color.White;
            this.FieldValue.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FieldValue.Location = new System.Drawing.Point(46, 75);
            this.FieldValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FieldValue.Name = "FieldValue";
            this.FieldValue.Size = new System.Drawing.Size(59, 16);
            this.FieldValue.TabIndex = 9;
            this.FieldValue.Text = "字段值";
            // 
            // ValueComboBox
            // 
            this.ValueComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ValueComboBox.FormattingEnabled = true;
            this.ValueComboBox.Location = new System.Drawing.Point(132, 73);
            this.ValueComboBox.Name = "ValueComboBox";
            this.ValueComboBox.Size = new System.Drawing.Size(121, 20);
            this.ValueComboBox.TabIndex = 8;
            // 
            // QueryTextBox
            // 
            this.QueryTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.QueryTextBox.Location = new System.Drawing.Point(106, 107);
            this.QueryTextBox.Name = "QueryTextBox";
            this.QueryTextBox.Size = new System.Drawing.Size(121, 21);
            this.QueryTextBox.TabIndex = 10;
            // 
            // FrmAttrsQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 459);
            this.Controls.Add(this.QueryTextBox);
            this.Controls.Add(this.FieldValue);
            this.Controls.Add(this.ValueComboBox);
            this.Controls.Add(this.QueryResult);
            this.Controls.Add(this.QueryResultGridView);
            this.Controls.Add(this.QueryButton);
            this.Controls.Add(this.FieldName);
            this.Controls.Add(this.FieldComboBox);
            this.Controls.Add(this.LayerName);
            this.Controls.Add(this.LayerComboBox);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmAttrsQuery";
            this.Text = "属性查询";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAttrsQuery_FormClosed);
            this.Load += new System.EventHandler(this.FrmAttrsQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QueryResultGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox LayerComboBox;
        private System.Windows.Forms.Label LayerName;
        private System.Windows.Forms.Label FieldName;
        private System.Windows.Forms.ComboBox FieldComboBox;
        private System.Windows.Forms.Button QueryButton;
        private System.Windows.Forms.DataGridView QueryResultGridView;
        private System.Windows.Forms.Label QueryResult;
        private System.Windows.Forms.Label FieldValue;
        private System.Windows.Forms.ComboBox ValueComboBox;
        private System.Windows.Forms.TextBox QueryTextBox;
    }
}