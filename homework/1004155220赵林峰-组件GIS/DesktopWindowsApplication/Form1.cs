using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Controls;
using System.IO;
using ESRI.ArcGIS.DataSourcesRaster;

namespace DesktopWindowsApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private AxMapControl m_MapCtl;

        private void Form1_Load(object sender, EventArgs e)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(286, 56);
            this.axMapControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(300, 400);
            this.axMapControl1.TabIndex = 2;
            //
			// axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 28);
            this.axToolbarControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(1125, 28);
            this.axToolbarControl1.TabIndex = 3;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.axTOCControl1.Location = new System.Drawing.Point(4, 56);
            this.axTOCControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(50, 469);
            this.axTOCControl1.TabIndex = 4;
            
            this.Controls.Add(this.axMapControl1);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.axToolbarControl1);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();

            axTOCControl1.SetBuddyControl(axMapControl1);
        }

        private void menuAddShp_Click(object sender, EventArgs e)
        {
           

            IWorkspaceFactory pWorkspaceFactory = new ShapefileWorkspaceFactory();
            openFileDialog1.Filter = "shapefile文件(*.shp)|*.shp";
            openFileDialog1.InitialDirectory = @"D:\GIS-Data";
            openFileDialog1.Multiselect = false;
            DialogResult pDialogResult = openFileDialog1.ShowDialog();
            if (pDialogResult != DialogResult.OK)
            {
                return;
            }
            string pPath = openFileDialog1.FileName;
            string pFloder = Path.GetDirectoryName(pPath);
            string pFileName = Path.GetFileName(pPath);
            IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(pFloder, 0);
            IFeatureWorkspace pFeatureWorkpace = pWorkspace as IFeatureWorkspace;

            IFeatureClass pFC = pFeatureWorkpace.OpenFeatureClass(pFileName);
            IFeatureLayer pFLayer = new FeatureLayer();
            pFLayer.FeatureClass = pFC;
            pFLayer.Name = pFC.AliasName;
            ILayer pLayer = pFLayer as ILayer;
            IMap pMap = axMapControl1.Map;
            pMap.AddLayer(pLayer);
            axMapControl1.ActiveView.Refresh();
            



            //axMapControl1.AddLayerFromFile(@"D:\GIS-Data\continent.lyr", 0);
            //axMapControl1.AddShapeFile(@"D:\GIS-Data", "continent.shp");

            //IWorkspaceFactory pWorkspaceFactory = new ShapefileWorkspaceFactory();  //创建工作区间
            //IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(@"D:\GIS-Data", 0); //打开Shapefile工作区间
            //IFeatureWorkspace pFeatureWorkpace = pWorkspace as IFeatureWorkspace; //接口转换，转化为要素类工作区间接口
            //IFeatureClass pFC = pFeatureWorkpace.OpenFeatureClass("continent.shp");//要素类接口中有打开要素类的方法
            //IFeatureLayer pFLayer = new FeatureLayer();//创建地图图层
            //pFLayer.FeatureClass = pFC;
            //pFLayer.Name = pFC.AliasName;//建立图层与Shapefile关联
            //ILayer pLayer = pFLayer as ILayer;
            //IMap pMap = axMapControl1.Map;
            //pMap.AddLayer(pLayer);//把图层文件加载到地图空间中
            //axMapControl1.ActiveView.Refresh();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAttributeTable frm = new FrmAttributeTable(axMapControl1);
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {


            //axMapControl1.AddLayerFromFile(@"D:\software\组件GIS\data\dem.lyr", 0);
            IRasterLayer pRasterLayer = new RasterLayer();
            pRasterLayer.CreateFromFilePath(@"D:\software\组件GIS\data\dem");
            axMapControl1.AddLayer(pRasterLayer, 0);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            IWorkspaceFactory pWorkspaceFactory = new RasterWorkspaceFactory();
            openFileDialog1.Filter = "|*.*";
            openFileDialog1.InitialDirectory = @"D:\software\组件GIS\data";
            openFileDialog1.Multiselect = false;
            DialogResult pDialogResult = openFileDialog1.ShowDialog();
            if (pDialogResult != DialogResult.OK)
            {
                return;
            }
            string pPath = openFileDialog1.FileName;
            string pFloder = Path.GetDirectoryName(pPath);
            string pFileName = Path.GetFileName(pPath).Split('.')[0];
            IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(pFloder, 0);
            IRasterWorkspace pRasterWorkspace = pWorkspace as IRasterWorkspace;

            IRasterDataset pRD = pRasterWorkspace.OpenRasterDataset(pFileName);
            IRaster pRaster = pRD.CreateDefaultRaster();

            IRasterLayer pRLayer = new RasterLayer();
            pRLayer.CreateFromRaster(pRaster);
            ILayer pLayer = pRLayer as ILayer;
            IMap pMap = axMapControl1.Map;
            pMap.AddLayer(pLayer);
            axMapControl1.ActiveView.Refresh();
        }
    }
}