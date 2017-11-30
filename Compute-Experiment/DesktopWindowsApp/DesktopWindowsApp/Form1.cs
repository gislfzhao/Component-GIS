using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.DataSourcesRaster;


namespace DesktopWindowsApp
{
    public partial class Form1 : Form
    {
        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl1;
        //private ESRI.ArcGIS.Controls.AxMapControl axMapControl2;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private IToolbarMenu m_ToolbarMenu = new ToolbarMenu();
        private const int WM_ENTERSIZEMOVE = 0x231;
        private const int WM_EXITSIZEMOVE = 0x232;
        private IEnvelope m_Envelope;
        private Object m_FillSymbol;
        private ITransformEvents_Event m_transform_Events;
        private ITransformEvents_VisibleBoundsUpdatedEventHandler visBoundUpdatedE;
        private int moveCount = 0;

       

        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnNotifyMessage(System.Windows.Forms.Message m)
        {
            base.OnNotifyMessage(m);
            if (m.Msg == WM_ENTERSIZEMOVE)
            {
                axMapControl1.SuppressResizeDrawing(true, 0);
                axPageLayoutControl1.SuppressResizeDrawing(true, 0);
            }
            else if (m.Msg == WM_EXITSIZEMOVE)
            {
                axMapControl1.SuppressResizeDrawing(false, 0);
                axPageLayoutControl1.SuppressResizeDrawing(false, 0);
            }
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);
            #region 窗体定义
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axPageLayoutControl1 = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            //this.axMapControl2 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            // 
            //axPageLayoutControl1
            // 
            this.axPageLayoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axPageLayoutControl1.Location = new System.Drawing.Point(266, 56);
            this.axPageLayoutControl1.Name = "axPageLayoutControl1";
            this.axPageLayoutControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl1.OcxState")));
            this.axPageLayoutControl1.Size = new System.Drawing.Size(525, 525);
            this.axPageLayoutControl1.TabIndex = 1;
            this.axPageLayoutControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseDownEventHandler(this.axPageLayoutControl1_OnMouseDown);
            this.axPageLayoutControl1.OnPageLayoutReplaced += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnPageLayoutReplacedEventHandler(this.axPageLayoutControl1_OnPageLayoutReplaced);
            //this.axPageLayoutControl1.OnAfterDraw += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnAfterDrawEventHandler(this.axPageLayoutControl1_OnAfterDraw);
            // 
            // axMapControl1
            //   
            this.axMapControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left));
            this.axMapControl1.Location = new System.Drawing.Point(0, 319);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(200, 200);
            this.axMapControl1.TabIndex = 2;
            this.axMapControl1.OnAfterDraw += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnAfterDrawEventHandler(this.axMapControl1_OnAfterDraw);
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            this.axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl1_OnMouseMove);
            //
            // axToolbarControl1
            // 
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 28);
            this.axToolbarControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(2130, 928);
            this.axToolbarControl1.TabIndex = 3;
            // 
           

            // axTOCControl1
            // 
            this.axTOCControl1.Location = new System.Drawing.Point(0, 56);
            this.axTOCControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(200, 200);
            this.axTOCControl1.TabIndex = 4;
            this.axTOCControl1.OnEndLabelEdit += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnEndLabelEditEventHandler(this.axTOCControl1_OnEndLabelEdit);

            this.Controls.Add(this.axPageLayoutControl1);
            //this.Controls.Add(this.axMapControl2);
            this.Controls.Add(this.axMapControl1);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.axToolbarControl1);
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            #endregion

            
            axTOCControl1.LabelEdit = esriTOCControlEdit.esriTOCControlManual;
           
            #region 加载工具条
            string progID;
            progID = "esriControls.ControlsPageZoomInTool";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
          
            progID = "esriControls.ControlsPageZoomOutTool";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);

            progID = "esriControls.ControlsPagePanTool";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);

            progID = "esriControls.ControlsPageZoomWholePageCommand";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);

            progID = "esriControls.ControlsPageZoomPageToLastExtentBackCommand";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);

            progID = "esriControls.ControlsPageZoomPageToLastExtentForwardCommand";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);

            progID = "esriControls.ControlsPageZoomPageToLastExtentBackCommand";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);

            progID = "esriControls.ControlsMapZoomInTool";
            axToolbarControl1.AddItem(progID, -1, -1, true, 0, esriCommandStyles.esriCommandStyleIconOnly);

            progID = "esriControls.ControlsMapZoomOutTool";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);

            progID = "esriControls.ControlsMapPanTool";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);

            progID = "esriControls.ControlsMapFullExtentCommand";
            axToolbarControl1.AddItem(progID, -1, -1, true, 0, esriCommandStyles.esriCommandStyleIconOnly);

            UID uID = new UID();
            uID.Value = "esriControls.ControlsOpenDocCommand";
            axToolbarControl1.AddItem(uID, -1, -1, true, 1, esriCommandStyles.esriCommandStyleIconOnly);

            ICommand command = new ControlsMapFullExtentCommand();
            axToolbarControl1.AddItem(command, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);

            command = new ControlsMapFindCommand();
            axToolbarControl1.AddItem(command, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);

            axToolbarControl1.AddItem("esriControls.ControlsDynamicDisplayNavigatorCommand", -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);

            #endregion

            m_ToolbarMenu.CommandPool = axToolbarControl1.CommandPool;
            m_ToolbarMenu.AddItem("esriControls.ControlsPageZoomInFixedCommand", 0, -1, false, esriCommandStyles.esriCommandStyleIconOnly);
            m_ToolbarMenu.AddItem("esriControls.ControlsPageZoomOutFixedCommand", 0, -1, false, esriCommandStyles.esriCommandStyleIconOnly);
            m_ToolbarMenu.AddItem("esriControls.ControlsPageZoomWholePageCommand", 0, -1, false, esriCommandStyles.esriCommandStyleIconOnly);
            m_ToolbarMenu.AddItem("esriControls.ControlsPageZoomPageToLastExtentBackCommand", 0, -1, false, esriCommandStyles.esriCommandStyleIconOnly);
            m_ToolbarMenu.AddItem("esriControls.ControlsPageZoomPageToLastExtentForwardCommand", 0, -1, false, esriCommandStyles.esriCommandStyleIconOnly);
            m_ToolbarMenu.SetHook(axPageLayoutControl1);

            CreateOverViewSymbol();
            string filename = @"E:\专题地图设计\1004155220+赵林峰+专题地图实习一\1004155220赵林峰.mxd";
            if (axPageLayoutControl1.CheckMxFile(filename))
            {
                axPageLayoutControl1.LoadMxFile(filename, "");
            }
            axTOCControl1.SetBuddyControl(axPageLayoutControl1);
            axToolbarControl1.SetBuddyControl(axPageLayoutControl1);
        }

        

        #region 建立MapControl到PageLayoutControl之间的互动

        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if(e.button == 1)
            {
                IPoint pt = new ESRI.ArcGIS.Geometry.Point();
                pt.PutCoords(e.mapX, e.mapY);
                m_Envelope.CenterAt(pt);
                IActiveView activeView = (IActiveView)axPageLayoutControl1.ActiveView.FocusMap;
                activeView.Extent = m_Envelope;
                axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
            }
            if(e.button == 2)
            {
                m_Envelope = axMapControl1.TrackRectangle();
                IActiveView activeView = (IActiveView)axPageLayoutControl1.ActiveView.FocusMap;
                activeView.Extent = m_Envelope;
                axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
            }
            
        }
        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            if (e.button == 1)
            {
                IPoint pt = new ESRI.ArcGIS.Geometry.Point();
                pt.PutCoords(e.mapX, e.mapY);
                m_Envelope.CenterAt(pt);
                IActiveView activeView = (IActiveView)axPageLayoutControl1.ActiveView.FocusMap;
                activeView.Extent = m_Envelope;
                moveCount++;
                if(moveCount % 4 == 0)//在MapControl中移动鼠标四次刷新PageLayoutControl视图中地图的范围
                {
                    axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                    axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                }
                
            }
                

        }
        #endregion

        #region 建立PageLayoutControl到MapControl之间的互动
        private void axPageLayoutControl1_OnPageLayoutReplaced(object sender, IPageLayoutControlEvents_OnPageLayoutReplacedEvent e)
        {
            axMapControl1.LoadMxFile(axPageLayoutControl1.DocumentFilename, null, null);
            axMapControl1.Extent = axMapControl1.FullExtent;
            IActiveView activeView = (IActiveView)axPageLayoutControl1.ActiveView.FocusMap;
            
            //在加载完地图文档之后，布局视图地图范围改变才执行    初始状态下是不会执行
            visBoundUpdatedE = new ITransformEvents_VisibleBoundsUpdatedEventHandler(OnVisibleBoundsUpdated);
            ((ITransformEvents_Event)activeView.ScreenDisplay.DisplayTransformation).VisibleBoundsUpdated += visBoundUpdatedE;


            m_Envelope = activeView.Extent;//初始状态装载地图执行的，其后面的情况不会执行

            //axMapControl1.LoadMxFile(axPageLayoutControl1.DocumentFilename, null, null);
            //axMapControl1.Extent = axMapControl1.FullExtent;

        }

        private void CreateOverViewSymbol()
        {
            IRgbColor color = new RgbColor();
            color.RGB = 255;

            ILineSymbol outline = new SimpleLineSymbol();
            outline.Width = 1.5;
            outline.Color = color;

            ISimpleFillSymbol simpleFillSymbol = new SimpleFillSymbolClass();
            simpleFillSymbol.Outline = outline;
            simpleFillSymbol.Style = esriSimpleFillStyle.esriSFSHollow;
            m_FillSymbol = simpleFillSymbol;
        }

        private void OnVisibleBoundsUpdated(IDisplayTransformation sender, bool sizeChanged)
        {
            m_Envelope = sender.VisibleBounds;
            axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, null, null);
            
        }

        private void axMapControl1_OnAfterDraw(object sender, IMapControlEvents2_OnAfterDrawEvent e)
        {
            if (m_Envelope == null)
            {
                return;
            }
            esriViewDrawPhase viewDrawPhase = (esriViewDrawPhase)e.viewDrawPhase;
            if (viewDrawPhase == esriViewDrawPhase.esriViewForeground)
            {
                IGeometry geometry = m_Envelope;
                axMapControl1.DrawShape(geometry, ref m_FillSymbol);
            }
           
        }
        #endregion


        private void axTOCControl1_OnEndLabelEdit(object sender, ITOCControlEvents_OnEndLabelEditEvent e)
        {
            string newLabel = e.newLabel;
            if(newLabel.Trim() == "")
            {
                e.canEdit = false;
            }
            //throw new NotImplementedException();
        }

        private void axPageLayoutControl1_OnMouseDown(object sender, IPageLayoutControlEvents_OnMouseDownEvent e)
        {
            if(e.button == 2)
            {
                m_ToolbarMenu.PopupMenu(e.x,e.y,axPageLayoutControl1.hWnd);
            }
            //throw new NotImplementedException();
        }

      
    }
}