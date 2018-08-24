using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Controls;
using System.IO;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.esriSystem;

namespace Hawkeye
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private IToolbarMenu m_ToolbarMenu = new ToolbarMenu();
        private const int WM_ENTERSIZEMOVE = 0x231;
        private const int WM_EXITSIZEMOVE = 0x232;
        private IEnvelope m_Envelope;
        private Object m_FillSymbol;
        private ITransformEvents_Event m_transform_Events;
        private ITransformEvents_VisibleBoundsUpdatedEventHandler visBoundUpdatedE;
        private int moveCount = 0;
        private IActiveViewEvents_Event m_MapActiveViewEvents;
        private ILayer properLayer = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);
            axTOCControl1.LabelEdit = esriTOCControlEdit.esriTOCControlManual;

            #region 加载工具条
            string progID;
            //添加数据
            progID = "esriControls.ControlsAddDataCommand";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            //放大
            progID = "esriControls.ControlsMapZoomInTool";
            axToolbarControl1.AddItem(progID, -1, -1, true, 0, esriCommandStyles.esriCommandStyleIconOnly);
            //缩小
            progID = "esriControls.ControlsMapZoomOutTool";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            //移动
            progID = "esriControls.ControlsMapPanTool";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            //全图
            progID = "esriControls.ControlsMapFullExtentCommand";
            axToolbarControl1.AddItem(progID, -1, -1, true, 0, esriCommandStyles.esriCommandStyleIconOnly);
            //打开地图文档
            progID = "esriControls.ControlsOpenDocCommand";
            axToolbarControl1.AddItem(progID, -1, -1, true, 0, esriCommandStyles.esriCommandStyleIconOnly);

            #endregion


            m_ToolbarMenu.CommandPool = axToolbarControl1.CommandPool;
            m_ToolbarMenu.AddItem("esriControls.ControlsMapZoomInTool", 0, -1, false, esriCommandStyles.esriCommandStyleIconOnly);
            m_ToolbarMenu.AddItem("esriControls.ControlsMapZoomOutTool", 0, -1, false, esriCommandStyles.esriCommandStyleIconOnly);
            m_ToolbarMenu.AddItem("esriControls.ControlsMapPanTool", 0, -1, false, esriCommandStyles.esriCommandStyleIconOnly);
            m_ToolbarMenu.AddItem("esriControls.ControlsMapFullExtentCommand", 0, -1, false, esriCommandStyles.esriCommandStyleIconOnly);

            m_ToolbarMenu.SetHook(axMapControl2);

            CreateOverviewSymbol();
            IMap pMap = axMapControl2.ActiveView.FocusMap as IMap;
            m_MapActiveViewEvents = pMap as IActiveViewEvents_Event;
            //添加图层事件委托
            m_MapActiveViewEvents.ItemAdded += new IActiveViewEvents_ItemAddedEventHandler(m_MapActiveViewEvents_ItemAdded);
            //删除图层事件委托
            m_MapActiveViewEvents.ItemDeleted += new IActiveViewEvents_ItemDeletedEventHandler(m_MapActiveViewEvents_ItemDeleted);

            //string filename = @"E:\专题地图设计\1004155220+赵林峰+专题地图实习一\1004155220赵林峰.mxd";

            //if (axMapControl2.CheckMxFile(filename))
            //{
            //    axMapControl2.LoadMxFile(filename, "", "");
            //    axMapControl2.Extent = axMapControl2.FullExtent;
            //}
            axTOCControl1.SetBuddyControl(axMapControl2);
            axToolbarControl1.SetBuddyControl(axMapControl2);

        }

        private void m_MapActiveViewEvents_ItemDeleted(object Item)
        {
            ILayer pLayer = Item as ILayer;
            axMapControl1.Map.DeleteLayer(pLayer);
        }

        private void m_MapActiveViewEvents_ItemAdded(object Item)
        {
            ILayer pLayer = Item as ILayer;
            axMapControl1.AddLayer(pLayer);
        }

        protected override void OnNotifyMessage(System.Windows.Forms.Message m)
        {
            base.OnNotifyMessage(m);
            if (m.Msg == WM_ENTERSIZEMOVE)
            {
                axMapControl2.SuppressResizeDrawing(true, 0);
                axMapControl1.SuppressResizeDrawing(true, 0);
                
            }
            else if (m.Msg == WM_EXITSIZEMOVE)
            {
                axMapControl2.SuppressResizeDrawing(false, 0);
                axMapControl1.SuppressResizeDrawing(false, 0);
                
            }
        }

        private void CreateOverviewSymbol()
        {
            IRgbColor color = new RgbColor();
            color.RGB = 255;

            ILineSymbol outline = new SimpleLineSymbol();
            outline.Width = 1.5;
            outline.Color = color;

            ISimpleFillSymbol simpleFillSymbol = new SimpleFillSymbol();
            simpleFillSymbol.Outline = outline;
            simpleFillSymbol.Style = esriSimpleFillStyle.esriSFSHollow;
            m_FillSymbol = simpleFillSymbol;
        }

        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 1)
            {
                IPoint pt = new ESRI.ArcGIS.Geometry.Point();
                pt.PutCoords(e.mapX, e.mapY);
                m_Envelope.CenterAt(pt);
                axMapControl2.Extent = m_Envelope;
                axMapControl2.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
               
            }
            if (e.button == 2)
            {
                m_Envelope = axMapControl1.TrackRectangle();
                axMapControl2.Extent = m_Envelope;
                axMapControl2.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
              
            }
        }
        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            if (e.button == 1)
            {
                IPoint pt = new ESRI.ArcGIS.Geometry.Point();
                pt.PutCoords(e.mapX, e.mapY);
                m_Envelope.CenterAt(pt);
                axMapControl2.Extent = m_Envelope;
                axMapControl2.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
              

            }
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

        private void axTOCControl1_OnEndLabelEdit(object sender, ITOCControlEvents_OnEndLabelEditEvent e)
        {
            string newLabel = e.newLabel;
            if (newLabel.Trim() == "")
            {
                e.canEdit = false;
            }
        }


        private void axMapControl2_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 2)
            {
                m_ToolbarMenu.PopupMenu(e.x, e.y, axMapControl2.hWnd);
            }
        }

        private void axMapControl2_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            m_Envelope = e.newEnvelope as IEnvelope;
            axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, null, null);
        }

        private void axMapControl2_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            //m_Envelope = axMapControl2.FullExtent;
            //axMapControl1.Extent = m_Envelope;
            //axMapControl1.LoadMxFile(axMapControl2.DocumentFilename, null, null);
            if (axMapControl2.LayerCount > 0)
            {
                axMapControl1.Map = new Map();
                for (int i = 0; i <= axMapControl2.Map.LayerCount - 1; i++)
                {
                    axMapControl1.AddLayer(axMapControl2.get_Layer(i));
                }
                axMapControl1.Extent = axMapControl2.FullExtent;
                axMapControl1.Refresh();
            }
        }

        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            if (axMapControl1.LayerCount > 0)
            {
                esriTOCControlItem Item = new esriTOCControlItem();
                IBasicMap pMap = new MapClass();
                object pOther = new object();
                object pIndex = new object();
                this.axTOCControl1.HitTest(e.x, e.y, ref Item, ref pMap, ref properLayer, ref pOther, ref pIndex);       
            }
            if(e.button == 2)
            {
                PropertyMenuStrip.Show(axTOCControl1, e.x, e.y);
            }
        }


        private void PropertyMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (((ContextMenuStrip)sender).Items[0] == e.ClickedItem)
            {

                FrmAttribute pFemAttribute = new FrmAttribute(axMapControl2, properLayer.Name);
                pFemAttribute.ShowDialog();
            }
            else if (((ContextMenuStrip)sender).Items[1] == e.ClickedItem)
            {
                for (int i = 0; i < axMapControl2.LayerCount; i++)
                {
                    if (axMapControl2.get_Layer(i) == properLayer)
                    {
                        axMapControl2.DeleteLayer(i);
                    }
                }
                axMapControl2.ActiveView.Refresh();
            }
            else if (((ContextMenuStrip)sender).Items[2] == e.ClickedItem)
            {

            }
        }

        private void RasterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void VectorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void LookToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
