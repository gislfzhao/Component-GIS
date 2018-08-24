using ESRI.ArcGIS.Controls;
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
    public partial class FrmSpatialQuery : Form
    {
        private AxMapControl pMapControl;
        public FrmSpatialQuery(AxMapControl pMapControl)
        {
            this.pMapControl = pMapControl;
            InitializeComponent();
        }
        public void SetQueryResultGridView(DataTable pDataTable)
        {
            QueryResultGridView.DataSource = pDataTable.DefaultView;
            QueryResultGridView.Refresh();
        }

        private void FrmSpatialQuery_FormClosed(object sender, FormClosedEventArgs e)
        {
            QueryResultGridView.ClearSelection();
            QueryResultGridView.DataSource = null;
            QueryResultGridView.Refresh();
            pMapControl.Map.ClearSelection();
            pMapControl.Refresh();
        }
    }
}
