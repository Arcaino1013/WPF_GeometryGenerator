using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace GeometryGenerator
{
    public class Triangle : Transform
    {
        private Point3DCollection points = new Point3DCollection(3);
        private Int32Collection triangleIndices = new Int32Collection(3);

        //Constructors still have to finish one
        #region
        public Triangle()
        {
            materialM.InstantiateMaterial();
            //Setting Material
            model.Material = materialM.MaterialF; model.BackMaterial = materialM.MaterialB;
            //Setting der positions of every Vertex
            points.Add(new Point3D(0, 0, 0));
            points.Add(new Point3D(0, 5, 0));
            points.Add(new Point3D(-5, 0, 0));
            //Setting the triangle Indices
            for (int i = 0; i < 3; i++)
            {
                triangleIndices.Add(i);
            }
            //Assigning points and indices to the premesh
            preMesh.Positions = points;
            preMesh.TriangleIndices = triangleIndices;
            //Assigning the premesh as the triangles geometry
            model.Geometry = preMesh;
        }

        public Triangle(Point3D a, Point3D b, Point3D c)
        {
            materialM.InstantiateMaterial();
        }
        #endregion

    }
}
