using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace GeometryGenerator
{
    public class Circle : Transform
    {
        private int sides = 32;
        public Circle()
        {
            materialM.InstantiateMaterial();
            //Setting materials
            model.Material = materialM.MaterialF; model.BackMaterial = materialM.MaterialB;
            //Creating mesh
            preMesh.Positions = genCircle(new Point3D(0, 0, 0), 1); preMesh.TriangleIndices = genInd(true);
            model.Geometry = preMesh;
        }

        public Circle(Point3D centerP)
        {
            materialM.InstantiateMaterial();
            //Setting materials
            model.Material = base.materialM.MaterialF; model.BackMaterial = materialM.MaterialB;
            //Creating mesh
            preMesh.Positions = genCircle(centerP, 1); preMesh.TriangleIndices = genInd(true);
            model.Geometry = preMesh;
        }

        public Circle(int sidesToSet)
        {
            materialM.InstantiateMaterial();
            if (sidesToSet % 2 == 0)
            {
                sides = sidesToSet;
            }
            //Setting materials
            model.Material = base.materialM.MaterialF; model.BackMaterial = materialM.MaterialB;
            //Creating mesh
            preMesh.Positions = genCircle(new Point3D(0, 0, 0), 1); preMesh.TriangleIndices = genInd(true);
            model.Geometry = preMesh;
        }

        public Circle(double radius)
        {
            materialM.InstantiateMaterial();
            //Setting materials
            model.Material = base.materialM.MaterialF; model.BackMaterial = materialM.MaterialB;
            //Creating mesh
            preMesh.Positions = genCircle(new Point3D(0, 0, 0), radius); preMesh.TriangleIndices = genInd(true);
            model.Geometry = preMesh;
        }

        public Circle(bool isTop)
        {
            materialM.InstantiateMaterial();
            //Setting materials
            model.Material = base.materialM.MaterialF; model.BackMaterial = materialM.MaterialB;
            //Creating mesh
            preMesh.Positions = genCircle(new Point3D(0, 0, 0), 1); preMesh.TriangleIndices = genInd(isTop);
            model.Geometry = preMesh;
        }

        public Circle(Point3D centerP, int sidesToSet, double radius, bool isTop)
        {
            materialM.InstantiateMaterial();
            if (sidesToSet % 2 == 0)
            {
                sides = sidesToSet;
            }
            //Setting materials
            model.Material = base.materialM.MaterialF; model.BackMaterial = materialM.MaterialB;
            //Creating mesh
            preMesh.Positions = genCircle(centerP, radius); preMesh.TriangleIndices = genInd(isTop);
            model.Geometry = preMesh;
        }

        private Point3DCollection genCircle(Point3D centerP, double radius)
        {
            materialM.InstantiateMaterial();
            Point3DCollection meshP = new Point3DCollection(sides + 1);
            double alpha, x, y;
            for (int i = 0; i < sides; i++)
            {
                alpha = 2 * Math.PI * i / sides;
                x = Math.Cos(alpha); y = Math.Sin(alpha);
                meshP.Add(new Point3D(centerP.X + (x * radius), centerP.Y + (y * radius), centerP.Z));
            }

            return meshP;
        }

        private Int32Collection genInd(bool isTop)
        {
            Int32Collection ind = new Int32Collection(sides * 3);
            if (isTop)
            {
                for (int i = 1; i < sides; i++)
                {
                    ind.Add(0); ind.Add(i); ind.Add(i + 1);
                }
                ind.Add(0); ind.Add(sides); ind.Add(1);
            }
            else
            {
                for (int i = 1; i < sides; i++)
                {
                    ind.Add(i); ind.Add(0); ind.Add(i + 1);
                }
                ind.Add(sides); ind.Add(0); ind.Add(1);
            }

            return ind;
        }
        public GeometryModel3D _Circle
        {
            get { return model; }
            set { model = value; }
        }
        public Point3DCollection Positions
        {
            get { return preMesh.Positions; }
        }

        public Int32Collection TriangleIndices
        {
            get { return preMesh.TriangleIndices; }
        }
    }
}
