using Rhino.Geometry;
using System;
using System.Linq;
using WpfBase.Model;

namespace WpfBase.ViewModels
{
    /// <summary>
    /// Custom view model keeping the binding logic and the geometry creation.
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        private double _span;
        private double _height;
        private int _frameCount;
        private Profiles _profiles;

        public MainViewModel()
        {
            PortalFrameModel = new PortalFrameModel();
        }

        public double Span
        {
            get => _span;
            set
            {
                _span = value;
                OnPropertyChanged("Span");
            }
        }

        public double Height
        {
            get => _height;
            set
            {
                _height = value;
                OnPropertyChanged("Height");
            }
        }

        public int FrameCount
        {
            get => _frameCount;
            set
            {
                _frameCount = value;
                OnPropertyChanged("FrameCount");
            }
        }

        public Profiles Profile
        {
            get => _profiles;
            set
            {
                _profiles = value;
                OnPropertyChanged("Profile");
            }
        }

        public Action Update;

        public PortalFrameModel PortalFrameModel { get; }

        public void CreatePortals()
        {
            Brep[] portals = new Brep[FrameCount];
            portals[0] = CreatePortal();
            for (int i = 1; i < FrameCount; i++)
            {
                var portalTemp = portals[i - 1].Duplicate();
                portalTemp.Translate(Vector3d.YAxis * (Span / 2));
                portals[i] = (Brep)portalTemp;
            }

            PortalFrameModel.Portals = portals.ToList();
            PortalFrameModel.Height = Height;
            PortalFrameModel.Span = Span;
        }

        private Brep CreatePortal()
        {
            Point3d pt0 = Point3d.Origin;
            Point3d pt1 = pt0 + Vector3d.ZAxis * _height;
            Point3d pt2 = pt1 + Vector3d.XAxis * _span;
            Point3d pt3 = pt0 + Vector3d.XAxis * _span;

            Polyline centerLine = new Polyline(new[] { pt0, pt1, pt2, pt3 });
            Curve[] profiles = { GetProfile(Profile) };

            SweepOneRail sweepOneRail = new SweepOneRail();
            sweepOneRail.MiterType = 1;
            Brep[] breps = sweepOneRail.PerformSweep(centerLine.ToNurbsCurve(), profiles);
            return breps[0];
        }

        private Curve GetProfile(Profiles profiles)
        {
            if (profiles == (Profiles)1)
                return new Rectangle3d(Plane.WorldXY, new Point3d(-2.5, -2.5, 0), new Point3d(2.5, 2.5, 0)).ToNurbsCurve();
            if (profiles == (Profiles)2)
                return new Circle(Plane.WorldXY, Point3d.Origin, 5).ToNurbsCurve();
            if (profiles == (Profiles)3)
                return new Rectangle3d(Plane.WorldXY, new Point3d(-2.5, -5, 0), new Point3d(2.5, 5, 0))
                    .ToNurbsCurve();
            return new LineCurve(new Point3d(-5, 0, 0), new Point3d(5, 0, 0));
        }

        public void UpdateDefinition(Action a)
        {
            Update = a;
        }
    }
}
