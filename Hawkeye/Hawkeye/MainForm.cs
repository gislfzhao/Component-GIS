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
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;
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
        private System.Object m_FillSymbol;
        private IActiveViewEvents_Event m_MapActiveViewEvents;
        private ILayer properLayer = null;
        private int spatialQueryMethod = 0;
        private int selectLayerIndex = 0;
        private string mTool = "";

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
            //固定比例放大
            progID = "esriControls.ControlsMapZoomInFixedCommand";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            //固定比例缩小
            progID = "esriControls.ControlsMapZoomOutFixedCommand";
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
            //撤销
            progID = "esriControls.ControlsUndoCommand";
            axToolbarControl1.AddItem(progID, -1, -1, true, 0, esriCommandStyles.esriCommandStyleIconOnly);
            //恢复
            progID = "esriControls.ControlsRedoCommand";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            //内容帮助
            progID = "esriControls.ControlsContextHelpCommand";
            axToolbarControl1.AddItem(progID, -1, -1, true, 0, esriCommandStyles.esriCommandStyleIconOnly);
            //页面显示上
            progID = "esriControls.ControlsMapPageUpCommand";
            axToolbarControl1.AddItem(progID, -1, -1, true, 0, esriCommandStyles.esriCommandStyleIconOnly);
            //页面显示下
            progID = "esriControls.ControlsMapPageDownCommand";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            //页面显示左
            progID = "esriControls.ControlsMapPageLeftCommand";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            //页面显示右
            progID = "esriControls.ControlsMapPageRightCommand";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            //刷新活动视图
            progID = "esriControls.ControlsMapRefreshViewCommand";
            axToolbarControl1.AddItem(progID, -1, -1, true, 0, esriCommandStyles.esriCommandStyleIconOnly);
            //前视图
            progID = "esriControls.ControlsMapZoomToLastExtentBackCommand";
            axToolbarControl1.AddItem(progID, -1, -1, true, 0, esriCommandStyles.esriCommandStyleIconOnly);
            //后视图
            progID = "esriControls.ControlsMapZoomToLastExtentForwardCommand";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            //选择要素
            progID = "esriControls.ControlsSelectFeaturesTool";
            axToolbarControl1.AddItem(progID, -1, -1, true, 0, esriCommandStyles.esriCommandStyleIconOnly);
            //清除选择的要素
            progID = "esriControls.ControlsClearSelectionCommand";
            axToolbarControl1.AddItem(progID, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            //选择元素
            progID = "esriControls.ControlsSelectTool";
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

            axTOCControl1.SetBuddyControl(axMapControl2);
            axToolbarControl1.SetBuddyControl(axMapControl2);

        }

        private void m_MapActiveViewEvents_ItemDeleted(object Item)
        {
            ILayer pLayer = Item as ILayer;
            axMapControl1.Map.DeleteLayer(pLayer);
            axMapControl1.Refresh();
            if (axMapControl1.LayerCount <= 0)
            {
                IGraphicsContainer pGraphicsContainer = axMapControl1.Map as IGraphicsContainer;
                pGraphicsContainer.DeleteAllElements();
                axMapControl1.Refresh();

            }
        }

        private void m_MapActiveViewEvents_ItemAdded(object Item)
        {
            ILayer pLayer = Item as ILayer;
            int index = 0;
            for (int i = 0; i < axMapControl2.LayerCount; i++)
            {
                if (axMapControl2.get_Layer(i) == pLayer)
                {
                    index = i;
                    break;
                }
            }
            axMapControl1.AddLayer(pLayer, index);
            axMapControl1.Refresh();
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
            if (axMapControl1.LayerCount > 0)
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
        }
        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            if (axMapControl1.LayerCount > 0)
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
            else if(e.button == 1)
            {
                switch (mTool)
                {
                    case "SpatialQuery":
                        axMapControl2.Map.ClearSelection();

                        IActiveView pActiveView = axMapControl2.ActiveView;
                        IPoint pPoint = pActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y);
                        IGeometry pGeometry = null;
                        switch (spatialQueryMethod)
                        {
                            case 0:
                                pGeometry = pPoint;
                                ITopologicalOperator pTopo = pGeometry as ITopologicalOperator;
                                IGeometry pBuffer = pTopo.Buffer(0.2);
                                pGeometry = pBuffer.Envelope;
                                break;
                            case 1:
                                pGeometry = axMapControl2.TrackLine();
                                ITopologicalOperator pTopo2 = pGeometry as ITopologicalOperator;
                                IGeometry pBuffer2 = pTopo2.Buffer(0.01);
                                pGeometry = pBuffer2.Envelope;
                                break;
                            case 2:
                                pGeometry = axMapControl2.TrackRectangle();
                                break;
                            case 3:
                                pGeometry = axMapControl2.TrackCircle();
                                break;
                            default:
                                break;
                        }
                        if(axMapControl2.get_Layer(selectLayerIndex) is IFeatureLayer)
                        {
                            IFeatureLayer pFeatureLayer = axMapControl2.get_Layer(selectLayerIndex) as IFeatureLayer;
                            DataTable pDataTable = LoadQueryResult(axMapControl2, pFeatureLayer, pGeometry);
                            FrmSpatialQuery pFrmSpatialQuery = new FrmSpatialQuery(axMapControl2);
                            pFrmSpatialQuery.SetQueryResultGridView(pDataTable);
                            pFrmSpatialQuery.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("该图层不支持空间查询！");
                        }
                        break;
                    default: break;
                }
                mTool = "";
                spatialQueryMethod = 0;
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
            if (axMapControl2.LayerCount > 0)
            {
                esriTOCControlItem Item = new esriTOCControlItem();
                IBasicMap pMap = new MapClass();
                object pOther = new object();
                object pIndex = new object();
                properLayer = null;
                axTOCControl1.HitTest(e.x, e.y, ref Item, ref pMap, ref properLayer, ref pOther, ref pIndex);
                if (e.button == 2 && properLayer != null)
                {
                    PropertyMenuStrip.Show(axTOCControl1, e.x, e.y);
                }
            }
        }

        private void axTOCControl1_OnMouseUp(object sender, ITOCControlEvents_OnMouseUpEvent e)
        {
            if (axMapControl2.LayerCount > 0)
            {
                esriTOCControlItem Item = new esriTOCControlItem();
                IBasicMap pMap = new MapClass();
                object pOther = new object();
                object pIndex = new object();
                properLayer = null;
                axTOCControl1.HitTest(e.x, e.y, ref Item, ref pMap, ref properLayer, ref pOther, ref pIndex);
                if(properLayer != null)
                {
                    if (properLayer.Visible == false)
                    {
                        for (int i = 0; i < axMapControl1.LayerCount; i++)
                        {
                            if (axMapControl1.get_Layer(i).Name == properLayer.Name)
                            {
                                axMapControl1.get_Layer(i).Visible = false;
                                axMapControl1.Refresh();
                                break;
                            }
                        }

                    }
                    else
                    {
                        for (int i = 0; i < axMapControl1.LayerCount; i++)
                        {
                            if (axMapControl1.get_Layer(i).Name == properLayer.Name)
                            {
                                axMapControl1.get_Layer(i).Visible = true;
                                axMapControl1.Refresh();
                                break;
                            }
                        }
                    }
                }
               
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
            openFileDialog.Title = "栅格";
            openFileDialog.Filter = "栅格数据(*.tiff; *.tif; *.jpep; *.jpg; *.png; *.bmp)| *.tiff; *.tif; *.jpep; *.jpg; *.png; *.bmp";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rasterPath = openFileDialog.FileName;
                string rasterFolder = System.IO.Path.GetDirectoryName(rasterPath);
                string rasterName = System.IO.Path.GetFileName(rasterPath);

                IWorkspaceFactory pWorkspaceFactory = new RasterWorkspaceFactory();
                IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(rasterFolder, 0);
                IRasterWorkspace pRasterWorkpace = pWorkspace as IRasterWorkspace;
                IRasterDataset pRasterDS = pRasterWorkpace.OpenRasterDataset(rasterName);

                IRasterLayer pRLayer = new RasterLayer();
                pRLayer.CreateFromDataset(pRasterDS);
                ILayer pLayer = pRLayer as ILayer;
                axMapControl2.Map.AddLayer(pLayer);
                axMapControl2.ActiveView.Refresh();
            }
        }

        private void VectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "矢量";
            openFileDialog.Filter = "矢量文件(*.shp)|*.shp";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string shpPath = openFileDialog.FileName;
                string shpFolder = System.IO.Path.GetDirectoryName(shpPath);
                string shpName = System.IO.Path.GetFileName(shpPath);

                IWorkspaceFactory pWorkspaceFactory = new ShapefileWorkspaceFactory();
                IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(shpFolder, 0);
                IFeatureWorkspace pFeatureWorkpace = pWorkspace as IFeatureWorkspace;

                IFeatureClass pFC = pFeatureWorkpace.OpenFeatureClass(shpName);
                IFeatureLayer pFLayer = new FeatureLayer();
                pFLayer.FeatureClass = pFC;
                pFLayer.Name = pFC.AliasName;
                ILayer pLayer = pFLayer as ILayer;
                IMap pMap = axMapControl2.Map;
                pMap.AddLayer(pLayer);
                axMapControl2.ActiveView.Refresh();
            }
        }

        private void SpatialQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mTool = "SpatialQuery";
        }

        private void PointQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spatialQueryMethod = 0;
            SelectSpatialQueryMethod(spatialQueryMethod);
        }

        private void LineQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spatialQueryMethod = 1;
            SelectSpatialQueryMethod(spatialQueryMethod);
        }

        private void RectangleQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spatialQueryMethod = 2;
            SelectSpatialQueryMethod(spatialQueryMethod);
        }

        private void CircleQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spatialQueryMethod = 3;
            SelectSpatialQueryMethod(spatialQueryMethod);
        }

        private void SelectSpatialQueryMethod(int type)
        {
            axMapControl2.Map.ClearSelection();
            FrmSelectLayer pFrmSelectLayer = new FrmSelectLayer(axMapControl2);
            if (pFrmSelectLayer.ShowDialog() == DialogResult.OK)
            {
            }
            selectLayerIndex = pFrmSelectLayer.selectLayerIndex;
            axMapControl2.MousePointer = esriControlsMousePointer.esriPointerCrosshair;
            //axMapControl2.CurrentTool.Deactivate();
            if (axToolbarControl1.CurrentTool != null)
            {
                axToolbarControl1.CurrentTool.Deactivate();
            }
            axMapControl2.Refresh();
        }

        private DataTable LoadQueryResult(AxMapControl mapControl, IFeatureLayer featureLayer, IGeometry geometry)
        {
            IFeatureClass pFeatureClass = featureLayer.FeatureClass;
            //根据图层属性字段初始化DataTable
            IFields pFields = pFeatureClass.Fields;
            DataTable pDataTable = new DataTable();
            for (int i = 0; i < pFields.FieldCount; ++i)
            {
                pDataTable.Columns.Add(pFields.get_Field(i).AliasName);
            }
            //空间过滤器
            ISpatialFilter pSpatialFilter = new SpatialFilter();
            pSpatialFilter.Geometry = geometry;
            //根据图层类型选择缓冲方式
            switch (pFeatureClass.ShapeType)
            {
                case esriGeometryType.esriGeometryMultipoint:
                    pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                    break;
                case esriGeometryType.esriGeometryPolyline:
                    pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                    break;
                case esriGeometryType.esriGeometryPolygon:
                    pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                    break;
                default:
                    pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                    break;
            }
            //定义空间过滤器的空间字段
            pSpatialFilter.GeometryField = pFeatureClass.ShapeFieldName;
            IQueryFilter pQueryFilter;
            IFeatureCursor pFeatureCursor;
            IFeature pFeature;
            //利用要素过滤器查询要素
            pQueryFilter = pSpatialFilter as IQueryFilter;
            pFeatureCursor = featureLayer.Search(pQueryFilter, true);
            pFeature = pFeatureCursor.NextFeature();
            while (pFeature != null)
            {
                string strFldValue = null;
                DataRow dr = pDataTable.NewRow();
                //遍历图层属性表字段值，并加入pDataTable
                for (int i = 0; i < pFields.FieldCount; i++)
                {
                    string strFldName = pFields.get_Field(i).Name;
                    if (strFldName == "Shape")
                    {
                        strFldValue = Convert.ToString(pFeature.Shape.GeometryType);
                    }
                    else
                        strFldValue = Convert.ToString(pFeature.get_Value(i));
                    dr[i] = strFldValue;
                }
                pDataTable.Rows.Add(dr);
                //高亮选择要素
                mapControl.Map.SelectFeature(featureLayer, pFeature);
                mapControl.ActiveView.Refresh();
                pFeature = pFeatureCursor.NextFeature();
            }

            return pDataTable;

        }

        private void AttributeQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAttrsQuery pFrmAttrsQuery = new FrmAttrsQuery(axMapControl2);
            pFrmAttrsQuery.ShowDialog();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void RestartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void RemoveLayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLayersDelete pFrmLayersDelete = new FrmLayersDelete(axMapControl2);
            pFrmLayersDelete.ShowDialog();
        }
    }
}
