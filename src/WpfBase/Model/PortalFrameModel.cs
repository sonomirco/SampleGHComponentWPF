using Rhino.Geometry;
using System.Collections.Generic;

namespace WpfBase.Model
{
    /// <summary>
    /// Class used to transport the data.
    /// </summary>
    public class PortalFrameModel
    {
        public double Span { get; set; }

        public double Height { get; set; }

        public List<Brep> Portals { get; set; }
    }
}
