using Grasshopper.GUI;
using Grasshopper.GUI.Canvas;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Attributes;

namespace GHComponentWPF
{
    public class PortalsGeneratorAttributes : GH_ComponentAttributes
    {
        public PortalsGeneratorAttributes(IGH_Component component) : base(component)
        {
        }

        public override GH_ObjectResponse RespondToMouseDoubleClick(GH_Canvas sender, GH_CanvasMouseEvent e)
        {
            (Owner as PortalsGenerator)?.DisplayWindows();
            return GH_ObjectResponse.Handled;
        }
    }
}
