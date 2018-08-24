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
    public partial class FrmLayersDelete : Form
    {
        private AxMapControl pMapControl;
        public FrmLayersDelete(AxMapControl pMapControl)
        {
            InitializeComponent();
            this.pMapControl = pMapControl;
            AddItems();
        }

        private void AddItems()
        {
            for (int i = 0; i < pMapControl.LayerCount; i++)
            {
                LayersCheckedListBox.Items.Add(pMapControl.get_Layer(i).Name, false);
            }
        }

        private void SelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < LayersCheckedListBox.Items.Count; i++)
            {
                LayersCheckedListBox.SetItemChecked(i, true);
            }
        }

        private void DeleteSelectedLayers_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < LayersCheckedListBox.Items.Count; i++)
            //{
            //    if(LayersCheckedListBox.GetItemChecked(i))
            //    {
            //        pMapControl.DeleteLayer(i);
            //    }
            //    pMapControl.Refresh();
            //}

            CheckedListBox.CheckedItemCollection selectdItems = LayersCheckedListBox.CheckedItems;
            for (int i = 0; i < selectdItems.Count; i++)
            {
                for(int j =0; j < pMapControl.LayerCount; j++)
                {
                    if(pMapControl.get_Layer(j).Name == selectdItems[i].ToString())
                    {
                        pMapControl.DeleteLayer(j);
                        pMapControl.Refresh();
                    }
                }
            }
            LayersCheckedListBox.Items.Clear();
            AddItems();
        }

        private void CancelSelect_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < LayersCheckedListBox.Items.Count; i++)
            //{
            //    LayersCheckedListBox.SetItemChecked(i, false);
            //}
            LayersCheckedListBox.ClearSelected();
        }

    }
}
