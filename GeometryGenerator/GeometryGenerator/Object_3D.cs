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

        }

        protected void ApplyMaterial()
        {
            model.Material = materialM.MaterialF;
            model.BackMaterial = materialM.MaterialB;
        }

        protected void Reset_preMesh()
        {
            preMesh = (MeshGeometry3D)model.Geometry;
        }

        public GeometryModel3D ToGeometryModel3D()
        {
            return model;
        }

    }
}
