using Grasshopper.Kernel;
using System;
using WpfBase.View;
using WpfBase.ViewModels;

namespace GHComponentWPF
{
    public class PortalsGenerator : GH_Component
    {
        private MainWindow _mainView;

        public PortalsGenerator()
          : base("PortalsGenerator", "PG", "Create a series of portals based on the data provided from the UI", "UI", "UI")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddBrepParameter("Portals", "P", "The portals", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            if (!(_mainView?.DataContext is MainViewModel dvm)) return;
            DA.SetDataList(0, dvm.PortalFrameModel.Portals);
            dvm.UpdateDefinition(() => ExpireSolution(true));
        }

        public override void CreateAttributes()
        {
            m_attributes = new PortalsGeneratorAttributes(this);
        }

        public void DisplayWindows()
        {
            _mainView = new MainWindow();
            _mainView.Show();
            if (!(_mainView.DataContext is MainViewModel dvm)) return;
            dvm.UpdateDefinition(() => ExpireSolution(true));
        }

        protected override System.Drawing.Bitmap Icon => null;

        public override Guid ComponentGuid => new Guid("23F03D44-F2BB-4ECF-87F5-14D5FBE6AF30");
    }
}