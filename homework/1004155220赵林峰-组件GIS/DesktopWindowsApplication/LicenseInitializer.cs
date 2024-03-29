using System;
using ESRI.ArcGIS;

namespace DesktopWindowsApplication
{
    internal partial class LicenseInitializer
    {
        public LicenseInitializer()
        {
            ResolveBindingEvent += new EventHandler(BindingArcGISRuntime);
        }

        void BindingArcGISRuntime(object sender, EventArgs e)
        {
            //
            // TODO: Modify ArcGIS runtime binding code as needed
            //
            if (!RuntimeManager.Bind(ProductCode.Desktop))
            {
                // Failed to bind, announce and force exit
                System.Windows.Forms.MessageBox.Show("Invalid ArcGIS runtime binding. Application will shut down.");
                System.Environment.Exit(0);
            }
        }
    }
}