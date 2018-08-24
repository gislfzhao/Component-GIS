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
    public partial class FrmSelectLayer : Form
    {
        public AxMapControl pMapControl;
        public int selectLayerIndex;
        public bool isSpatialQuery = false;

        public FrmSelectLayer(AxMapControl pMapControl)
        {
            InitializeComponent();
            this.pMapControl = pMapControl;
        }

        private void FrmSelectLayer_Load(object sender, EventArgs e)
        {
            if (pMapControl.LayerCount <= 0)
            {
                return;
            }
            for (int i = 0; i < pMapControl.LayerCount; i++)
            {
                LayerComboBox2.Items.Add(pMapControl.get_Layer(i).Name);
            }
            LayerComboBox2.SelectedIndex = 0;
        }

        private void Confrim_Click(object sender, EventArgs e)
        {
            if (LayerComboBox2.Items.Count <= 0)
            {
                MessageBox.Show("当前MapControl没有添加图层！", "提示");
                return;
            }
            selectLayerIndex = LayerComboBox2.SelectedIndex;
            isSpatialQuery = true;
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            selectLayerIndex = 0;
        }
    }
}
