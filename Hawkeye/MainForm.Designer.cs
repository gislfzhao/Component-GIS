namespace Hawkeye
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.menuStripTop = new System.Windows.Forms.MenuStrip();
            this.AddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SpatialQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PointQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LineQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RectangleQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CircleQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AttributeQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PropertyMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.属性表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.移除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axMapControl2 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.menuStripTop.SuspendLayout();
            this.PropertyMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.axTOCControl1.Location = new System.Drawing.Point(7, 62);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(206, 395);
            this.axTOCControl1.TabIndex = 2;
            this.axTOCControl1.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOCControl1_OnMouseDown);
            this.axTOCControl1.OnEndLabelEdit += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnEndLabelEditEventHandler(this.axTOCControl1_OnEndLabelEdit);
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 30);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(982, 28);
            this.axToolbarControl1.TabIndex = 5;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(279, 290);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 6;
            // 
            // menuStripTop
            // 
            this.menuStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToolStripMenuItem,
            this.LookToolStripMenuItem,
            this.QueryToolStripMenuItem,
            this.DeleteToolStripMenuItem});
            this.menuStripTop.Location = new System.Drawing.Point(0, 0);
            this.menuStripTop.Name = "menuStripTop";
            this.menuStripTop.Size = new System.Drawing.Size(994, 25);
            this.menuStripTop.TabIndex = 7;
            this.menuStripTop.Text = "menuStrip1";
            // 
            // AddToolStripMenuItem
            // 
            this.AddToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RasterToolStripMenuItem,
            this.VectorToolStripMenuItem});
            this.AddToolStripMenuItem.Name = "AddToolStripMenuItem";
            this.AddToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.AddToolStripMenuItem.Text = "添加";
            // 
            // RasterToolStripMenuItem
            // 
            this.RasterToolStripMenuItem.Name = "RasterToolStripMenuItem";
            this.RasterToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.RasterToolStripMenuItem.Text = "栅格";
            this.RasterToolStripMenuItem.Click += new System.EventHandler(this.RasterToolStripMenuItem_Click);
            // 
            // VectorToolStripMenuItem
            // 
            this.VectorToolStripMenuItem.Name = "VectorToolStripMenuItem";
            this.VectorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.VectorToolStripMenuItem.Text = "矢量";
            this.VectorToolStripMenuItem.Click += new System.EventHandler(this.VectorToolStripMenuItem_Click);
            // 
            // LookToolStripMenuItem
            // 
            this.LookToolStripMenuItem.Name = "LookToolStripMenuItem";
            this.LookToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.LookToolStripMenuItem.Text = "浏览";
            this.LookToolStripMenuItem.Click += new System.EventHandler(this.LookToolStripMenuItem_Click);
            // 
            // QueryToolStripMenuItem
            // 
            this.QueryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SpatialQueryToolStripMenuItem,
            this.AttributeQueryToolStripMenuItem});
            this.QueryToolStripMenuItem.Name = "QueryToolStripMenuItem";
            this.QueryToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.QueryToolStripMenuItem.Text = "查询";
            // 
            // SpatialQueryToolStripMenuItem
            // 
            this.SpatialQueryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PointQueryToolStripMenuItem,
            this.LineQueryToolStripMenuItem,
            this.RectangleQueryToolStripMenuItem,
            this.CircleQueryToolStripMenuItem});
            this.SpatialQueryToolStripMenuItem.Name = "SpatialQueryToolStripMenuItem";
            this.SpatialQueryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.SpatialQueryToolStripMenuItem.Text = "空间查询";
            // 
            // PointQueryToolStripMenuItem
            // 
            this.PointQueryToolStripMenuItem.Name = "PointQueryToolStripMenuItem";
            this.PointQueryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.PointQueryToolStripMenuItem.Text = "点查询";
            // 
            // LineQueryToolStripMenuItem
            // 
            this.LineQueryToolStripMenuItem.Name = "LineQueryToolStripMenuItem";
            this.LineQueryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.LineQueryToolStripMenuItem.Text = "线查询";
            // 
            // RectangleQueryToolStripMenuItem
            // 
            this.RectangleQueryToolStripMenuItem.Name = "RectangleQueryToolStripMenuItem";
            this.RectangleQueryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.RectangleQueryToolStripMenuItem.Text = "矩形查询";
            // 
            // CircleQueryToolStripMenuItem
            // 
            this.CircleQueryToolStripMenuItem.Name = "CircleQueryToolStripMenuItem";
            this.CircleQueryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.CircleQueryToolStripMenuItem.Text = "圆查询";
            // 
            // AttributeQueryToolStripMenuItem
            // 
            this.AttributeQueryToolStripMenuItem.Name = "AttributeQueryToolStripMenuItem";
            this.AttributeQueryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.AttributeQueryToolStripMenuItem.Text = "属性查询";
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.DeleteToolStripMenuItem.Text = "删除";
            // 
            // PropertyMenuStrip
            // 
            this.PropertyMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.属性表ToolStripMenuItem,
            this.移除ToolStripMenuItem});
            this.PropertyMenuStrip.Name = "contextMenuStrip1";
            this.PropertyMenuStrip.Size = new System.Drawing.Size(113, 48);
            this.PropertyMenuStrip.Text = "属性";
            this.PropertyMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.PropertyMenuStrip_ItemClicked);
            // 
            // 属性表ToolStripMenuItem
            // 
            this.属性表ToolStripMenuItem.Name = "属性表ToolStripMenuItem";
            this.属性表ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.属性表ToolStripMenuItem.Text = "属性表";
            // 
            // 移除ToolStripMenuItem
            // 
            this.移除ToolStripMenuItem.Name = "移除ToolStripMenuItem";
            this.移除ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.移除ToolStripMenuItem.Text = "移除";
            // 
            // axMapControl2
            // 
            this.axMapControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axMapControl2.Location = new System.Drawing.Point(219, 62);
            this.axMapControl2.Name = "axMapControl2";
            this.axMapControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl2.OcxState")));
            this.axMapControl2.Size = new System.Drawing.Size(763, 567);
            this.axMapControl2.TabIndex = 0;
            this.axMapControl2.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl2_OnMouseDown);
            this.axMapControl2.OnExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnExtentUpdatedEventHandler(this.axMapControl2_OnExtentUpdated);
            this.axMapControl2.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.axMapControl2_OnMapReplaced);
            // 
            // axMapControl1
            // 
            this.axMapControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.axMapControl1.Location = new System.Drawing.Point(7, 463);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(206, 166);
            this.axMapControl1.TabIndex = 1;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            this.axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl1_OnMouseMove);
            this.axMapControl1.OnAfterDraw += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnAfterDrawEventHandler(this.axMapControl1_OnAfterDraw);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openDataFileDialog";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 641);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axMapControl2);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.axMapControl1);
            this.Controls.Add(this.menuStripTop);
            this.MainMenuStrip = this.menuStripTop;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.menuStripTop.ResumeLayout(false);
            this.menuStripTop.PerformLayout();
            this.PropertyMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxMapControl axMapControl2;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.MenuStrip menuStripTop;
        private System.Windows.Forms.ToolStripMenuItem AddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QueryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SpatialQueryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AttributeQueryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip PropertyMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 属性表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 移除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PointQueryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LineQueryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RectangleQueryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CircleQueryToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

