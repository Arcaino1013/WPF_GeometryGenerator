using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace GeometryGenerator
{
    public class Object_3D
    {
        protected GeometryModel3D model = new GeometryModel3D();
        protected MeshGeometry3D preMesh = new MeshGeometry3D();
        protected MaterialManager materialM = new MaterialManager();

        public Object_3D()
        {
            materialM = new MaterialManager();
        }

        public GeometryModel3D ToGeometryModel3D()
        {
            return model;
        }
    }
}
