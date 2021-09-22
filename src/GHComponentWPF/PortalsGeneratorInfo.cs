using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace GHComponentWPF
{
    public class PortalsGeneratorInfo : GH_AssemblyInfo
    {
        public override string Name => "PortalsGenerator";

        //Return a 24x24 pixel bitmap to represent this GHA library.
        public override Bitmap Icon => null;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "A base project setting up a GH component with a WPF UI interface used to generate geometry";

        public override Guid Id => new Guid("553116FD-6BD6-4877-95C5-B9E4521BE785");

        //Return a string identifying you or your company.
        public override string AuthorName => "Mirco Bianchini";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "";
    }
}