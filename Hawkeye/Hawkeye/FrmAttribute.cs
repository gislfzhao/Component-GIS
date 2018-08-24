using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hawkeye
{
    public partial class FrmAttribute : Form
    {
        public AxMapControl pMapControl;
        public IMap pMap;
        public int LayerIndex;
        private int rowIndex;
        public string LayerName;

        public FrmAttribute(AxMapControl pMapControl, string LyrName)
        {
            InitializeComponent();
            this.pMapControl = pMapControl;
            pMap = pMapControl.Map;
            LayerName = LyrName;
        }

        public void GetValues()
        {
            for (int i = 0; i < pMap.LayerCount; i++)
            {
                if (LayerName == pMap.get_Layer(i).Name)
                {
                    LayerIndex = i;
                    break;
                }
            }
            ILayer pLayer = pMap.get_Layer(LayerIndex);
            if(pLayer is IFeatureLayer)
            {
                IFeatureLayer pFeatureLayer = pLayer as IFeatureLayer;
                IFields pFields = pFeatureLayer.FeatureClass.Fields;
                dataGridView1.ColumnCount = pFields.FieldCount;
                for (int i = 0; i < pFields.FieldCount; i++)
                {
                    string fieldname;
                    fieldname = pFields.get_Field(i).Name;
                    dataGridView1.Columns[i].Name = fieldname;
                }
                IFeatureCursor pFeatureCursor = pFeatureLayer.FeatureClass.Search(null, false);
                IFeature pFeature = pFeatureCursor.NextFeature();
                while (pFeature != null)
                {
                    string[] fldvalue = new string[pFields.FieldCount];
                    for (int i = 0; i < pFields.FieldCount; i++)
                    {

                        if (pFields.get_Field(i).Name == "Shape")
                        {
                            fldvalue[i] = Convert.ToString(pFeature.Shape.GeometryType);
                        }
                        else
                        {
                            fldvalue[i] = Convert.ToString(pFeature.get_Value(i));
                        }
                    }
                    dataGridView1.Rows.Add(fldvalue);
                    pFeature = pFeatureCursor.NextFeature();
                }
            }
            else
            {
                IRasterLayer rasLayer = pLayer as IRasterLayer;
                //判断是否存在属性表
                if (rasLayer != null && IsRasterLayerHaveTable(rasLayer.Raster))
                {
                    ITable iTable = rasLayer as ITable;
                    IFields iFields = iTable.Fields;
                    dataGridView1.ColumnCount = iFields.FieldCount;
                    for (int i = 0; i < iFields.FieldCount; i++)
                    {
                        string fieldname;
                        fieldname = iFields.get_Field(i).Name;
                        dataGridView1.Columns[i].Name = fieldname;
                    }
                    ICursor pCursor = iTable.Search(null, false);
                    IRow pRow = pCursor.NextRow();
                    while (pRow != null)
                    {
                        string[] rasvalue = new string[iFields.FieldCount];
                        for (int i = 0; i < iFields.FieldCount; i++)
                        {

                            if (iFields.get_Field(i).Type == esriFieldType.esriFieldTypeBlob)
                            {
                                rasvalue[i] = "Element";
                            }
                            else
                            {
                                rasvalue[i] = Convert.ToString(pRow.get_Value(i));
                            }
                        }
                        dataGridView1.Rows.Add(rasvalue);
                        pRow = pCursor.NextRow();
                    }
                }
                else
                {
                    return ;
                }
            }
           

        }

        /// <summary>
        /// 判断栅格图层是否拥有属性表
        /// </summary>
        /// <param name="pRaster">栅格</param>
        /// <returns>是否拥有属性表</returns>
        public static bool IsRasterLayerHaveTable(IRaster pRaster)
        {
            IRasterProps pProp = pRaster as IRasterProps;
            if (pProp == null)
            {
                return false;
            }
            if (pProp.PixelType == rstPixelType.PT_FLOAT || pProp.PixelType == rstPixelType.PT_DOUBLE) //判断栅格像元值是否是整型
            {
                return false;
            }
            IRasterBandCollection pRasterbandCollection = (IRasterBandCollection)pRaster;
            IRasterBand rasterBand = pRasterbandCollection.Item(0);
            ITable rTable = rasterBand.AttributeTable;
            return rTable != null;
        }

        private void FrmAttribute_Load(object sender, EventArgs e)
        {
            GetValues();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0)
            {
                return;
            }

            string FID;
            FID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            if (FID == "")
                return;
            IActiveView pActiveView;
            pActiveView = (IActiveView)pMap;
            pMap.ClearSelection();
            pActiveView.Refresh();

            IQueryFilter pQueryFilter = new QueryFilter();
            pQueryFilter.WhereClause = "FID=" + FID;

            IFeatureLayer pFeatureLayer;
            pFeatureLayer = (IFeatureLayer)pMap.get_Layer(LayerIndex);

            IFeatureCursor pFeatureCursor;
            pFeatureCursor = pFeatureLayer.Search(pQueryFilter, false);

            IFeature pFeature;
            pFeature = pFeatureCursor.NextFeature();

            pMap.SelectFeature(pFeatureLayer, pFeature);
            

            IPoint pPoint = new ESRI.ArcGIS.Geometry.Point();
            pPoint.X = (pFeature.Extent.XMin + pFeature.Extent.XMax) / 2;
            pPoint.Y = (pFeature.Extent.YMin + pFeature.Extent.YMax) / 2;

            pMapControl.CenterAt(pPoint);

            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
        }

        private void FrmAttribute_FormClosed(object sender, FormClosedEventArgs e)
        {
            pMap.ClearSelection();
            pMapControl.ActiveView.Refresh();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                rowIndex = e.RowIndex;
            }
        }

        private void CellsMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (((ContextMenuStrip)sender).Items[0] == e.ClickedItem)
            {
                if(rowIndex >=0)
                {
                    ILayer pLayer = pMapControl.get_Layer(LayerIndex);
                    if(pLayer is IFeatureLayer)
                    {
                        ITable pTable = (pLayer as FeatureLayer).FeatureClass as ITable;
                        try
                        {
                            IRow pRow = pTable.GetRow(rowIndex);
                            if (MessageBox.Show("确认删除此数据？", "删除数据", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                pRow.Delete();
                                dataGridView1.Rows.RemoveAt(rowIndex);
                                dataGridView1.Refresh();
                                pMap.ClearSelection();
                                pMapControl.ActiveView.Refresh();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("删除错误！","ERROR");
                        }
                    }
                    
                }
                rowIndex = -1;
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                CellsMenuStrip.Show(dataGridView1, e.X, e.Y);
            }
        }
    }
}
