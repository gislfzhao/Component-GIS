using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;


namespace DesktopWindowsApplication
{
    public partial class FrmAttributeTable : Form
    {
        public FrmAttributeTable()
        {
            InitializeComponent();
        }
        private AxMapControl m_MapCtl;
        public FrmAttributeTable(AxMapControl pMapCtl)
        {
            InitializeComponent();
            m_MapCtl = pMapCtl;
        }

       

        private void FrmAttributeTable_Load(object sender, EventArgs e)
        {
            ILayer pLayer = m_MapCtl.get_Layer(0);
            IFeatureLayer pFLayer = pLayer as IFeatureLayer;
            IFeatureClass pFC = pFLayer.FeatureClass;

            IFeatureCursor pFCursor = pFC.Search(null, false);
            IFeature pFeature = pFCursor.NextFeature();

            DataTable pTable = new DataTable();
            DataColumn colName = new DataColumn("国家名");
            colName.DataType = System.Type.GetType("System.String");
            pTable.Columns.Add(colName);

            DataColumn colArea = new DataColumn("人口");
            colArea.DataType = System.Type.GetType("System.String");
            pTable.Columns.Add(colArea);

            int indexOfName1 = pFC.FindField("CNTRY_NAME");
            int indexOfName2 = pFC.FindField("POP_CNTRY");
            //dataGridView1.DataSource = pTable;
            while (pFeature != null)
            {
                string name = pFeature.get_Value(indexOfName1).ToString();
                string area = pFeature.get_Value(indexOfName2).ToString();
                DataRow pRow = pTable.NewRow();
                pRow[0] = name;
                pRow[1] = area;
                pTable.Rows.Add(pRow);
                pFeature = pFCursor.NextFeature();
            }

            dataGridView1.DataSource = pTable;
            //if(pFeature == null)
            //{
            //    string name = "name";
            //    string area = "area";
            //    DataRow pRow = pTable.NewRow();
            //    pRow[0] = name;
            //    pRow[1] = area;
            //    pTable.Rows.Add(pRow);
            //    pFeature = pFCursor.NextFeature();
            //}

        }
    }
}
