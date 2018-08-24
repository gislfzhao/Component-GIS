using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
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
    public partial class FrmAttrsQuery : Form
    {
        private AxMapControl pMapControl;
        public FrmAttrsQuery(AxMapControl pMapControl)
        {
            this.pMapControl = pMapControl;
            InitializeComponent();
        }

        private void QueryButton_Click(object sender, EventArgs e)
        {
            if (pMapControl.LayerCount <= 0)
            {
                MessageBox.Show("当前MapControl没有添加图层！", "提示");
                return;
            }
            string queryExpression = "";
            if (QueryTextBox.Text == "")
            {
                if (ValueComboBox.Items.Count == 0)
                {
                    return;
                }

                ITable pTable = pMapControl.get_Layer(LayerComboBox.SelectedIndex) as ITable;
                esriFieldType fieldType = pTable.Fields.Field[FieldComboBox.SelectedIndex].Type;
                if (fieldType == esriFieldType.esriFieldTypeSmallInteger || fieldType == esriFieldType.esriFieldTypeInteger ||
                    fieldType == esriFieldType.esriFieldTypeSingle || fieldType == esriFieldType.esriFieldTypeDouble ||
                    fieldType == esriFieldType.esriFieldTypeOID)
                {
                    queryExpression = Convert.ToString(FieldComboBox.SelectedItem) + " = " + Convert.ToString(ValueComboBox.SelectedItem);
                }
                else if (fieldType == esriFieldType.esriFieldTypeGeometry)
                {
                    //要素的Shape字段
                }
                else
                {
                    queryExpression = Convert.ToString(FieldComboBox.SelectedItem) + " = '" + Convert.ToString(ValueComboBox.SelectedItem) + "'";
                }
            }
            else
            {
                if (ValueComboBox.Items.Count == 0)
                {
                    return;
                }
                ITable pTable = pMapControl.get_Layer(LayerComboBox.SelectedIndex) as ITable;
                esriFieldType fieldType = pTable.Fields.Field[FieldComboBox.SelectedIndex].Type;
                if (fieldType == esriFieldType.esriFieldTypeSmallInteger || fieldType == esriFieldType.esriFieldTypeInteger ||
                    fieldType == esriFieldType.esriFieldTypeSingle || fieldType == esriFieldType.esriFieldTypeDouble ||
                    fieldType == esriFieldType.esriFieldTypeOID)
                {
                    queryExpression = Convert.ToString(FieldComboBox.SelectedItem) + " = " + QueryTextBox.Text;
                }
                else if (fieldType == esriFieldType.esriFieldTypeGeometry)
                {
                    //要素的Shape字段
                }
                else
                {
                    queryExpression = Convert.ToString(FieldComboBox.SelectedItem) + " LIKE '%" + QueryTextBox.Text + "%'";
                }

            }
            QueryResultGridView.DataSource = QueryByExpression(pMapControl.get_Layer(LayerComboBox.SelectedIndex), queryExpression);
            QueryResultGridView.Refresh();
        }

        private DataTable QueryByExpression(ILayer pLayer, string expression)
        {
            DataTable pDataTable = new DataTable();
            IQueryFilter pQueryFilter = new QueryFilter();
            if (IsLayerHaveAttrTable(pLayer))
            {
                pQueryFilter.WhereClause = expression;
                for (int i = 0; i < FieldComboBox.Items.Count; i++)
                {
                    pDataTable.Columns.Add(FieldComboBox.Items[i].ToString());
                }
                if (pLayer is RasterLayer)
                {
                    ITable pTable = pLayer as ITable;
                    ICursor pCursor = pTable.Search(pQueryFilter, false);
                    IRow pRow = pCursor.NextRow();
                    while (pRow != null)
                    {
                        DataRow pDataRow = pDataTable.NewRow();
                        for (int i = 0; i < pDataTable.Columns.Count; i++)
                        {
                            pDataRow[i] = Convert.ToString(pRow.Value[i]);
                        }
                        pDataTable.Rows.Add(pDataRow);
                        pRow = pCursor.NextRow();
                    }
                }
                else if (pLayer is FeatureLayer)
                {
                    pMapControl.Map.ClearSelection();
                    IFeatureClass pFeatureClass = (pLayer as IFeatureLayer).FeatureClass;
                    IFeatureCursor pFCursor = pFeatureClass.Search(pQueryFilter, false);
                    IFeature pFeature = pFCursor.NextFeature();
                    while (pFeature != null)
                    {
                        DataRow pDataRow = pDataTable.NewRow();
                        for (int i = 0; i < pDataTable.Columns.Count; i++)
                        {
                            pDataRow[i] = Convert.ToString(pFeature.Value[i]);
                        }
                        pDataTable.Rows.Add(pDataRow);
                        pMapControl.Map.SelectFeature(pLayer as FeatureLayer, pFeature);
                        pMapControl.ActiveView.Refresh();
                        pFeature = pFCursor.NextFeature();
                    }
                }
            }

            return pDataTable;
        }

        private void FrmAttrsQuery_Load(object sender, EventArgs e)
        {
            if (pMapControl.LayerCount <= 0)
            {
                return;
            }
            for (int i = 0; i < pMapControl.LayerCount; i++)
            {
                LayerComboBox.Items.Add(pMapControl.get_Layer(i).Name);
            }
            LayerComboBox.SelectedIndex = 0;
        }

        //改变选择图层
        private void LayerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ILayer pLayer = pMapControl.get_Layer(LayerComboBox.SelectedIndex);
            if (IsLayerHaveAttrTable(pLayer) == false)
            {
                return;
            }
            ITable iTable = pLayer as ITable;
            IFields iFields = iTable.Fields;

            //判断字段列表是否为空
            if (FieldComboBox.Items != null)
            {
                FieldComboBox.Items.Clear();
            }
            for (int i = 0; i < iFields.FieldCount; i++)
            {
                FieldComboBox.Items.Add(iFields.Field[i].Name);
            }
            FieldComboBox.SelectedIndex = 0;
        }

        //改变选择字段
        private void FieldComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ILayer pLayer = pMapControl.get_Layer(LayerComboBox.SelectedIndex);
            if (IsLayerHaveAttrTable(pLayer) == false)
            {
                return;
            }
            if (ValueComboBox.Items != null)
            {
                ValueComboBox.Items.Clear();
            }
            ITable iTable = pLayer as ITable;
            ICursor pCursor = iTable.Search(null, false);
            IRow pRow = pCursor.NextRow();
            List<string> fieldValues = new List<string>();
            while (pRow != null)
            {
                string fieldName = iTable.Fields.Field[FieldComboBox.SelectedIndex].Name;
                fieldValues.Add(Convert.ToString(pRow.Value[FieldComboBox.SelectedIndex]));
                pRow = pCursor.NextRow();
            }
            List<string> uniqueValues = fieldValues.Distinct().ToList();
            for (int i = 0; i < uniqueValues.Count; i++)
            {
                ValueComboBox.Items.Add(uniqueValues[i]);
            }
            ValueComboBox.SelectedIndex = 0;
        }

        //判断图层是否具有属性值
        private bool IsLayerHaveAttrTable(ILayer pLayer)
        {
            if (pLayer is IFeatureLayer)
            {
                return true;
            }
            else if (pLayer is IRasterLayer)
            {
                if (pLayer != null && IsRasterLayerHaveTable((pLayer as IRasterLayer).Raster))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断栅格图层是否拥有属性表
        /// </summary>
        /// <param name="pRaster">栅格</param>
        /// <returns>是否拥有属性表</returns>
        private static bool IsRasterLayerHaveTable(IRaster pRaster)
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

        private void FrmAttrsQuery_FormClosed(object sender, FormClosedEventArgs e)
        {
            QueryTextBox.Text = "";
            QueryResultGridView.ClearSelection();
            QueryResultGridView.DataSource = null;
            QueryResultGridView.Refresh();
            pMapControl.Map.ClearSelection();
            pMapControl.Refresh();
        }
    }
}
