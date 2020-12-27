using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace GeometryGenerator
{
    public class Cylinder : Circle
    {
        Point3D[] cylinder_CenterP = {new Point3D(0,0,0),new Point3D(),new Point3D()};
        Point3DCollection topV = new Point3DCollection(), bottomV = new Point3DCollection(),totalV = new Point3DCollection();
        Int32Collection topI = new Int32Collection(), bottomI = new Int32Collection(),totalI = new Int32Collection();
        int z_Displacement = 1;
        public Cylinder()
        {
            CreateCylinder();
        }

        public Cylinder(int sides)
        {
            if(sides % 2 == 0)
            {
                this.sides = sides;
            }
            CreateCylinder();
        }

        private void CreateCylinder()
        {
            SetCenterPoints();
            CreateCircles();
            CirclesToCylinder();
            preMesh.Positions = totalV;
            preMesh.TriangleIndices = totalI;
            model.Geometry = preMesh;
            ApplyMaterial();
        }

        private void CreateCircles()
        {
            topV = genCircle(cylinder_CenterP[1]); bottomV = genCircle(cylinder_CenterP[2]);
            topI = genInd(true); bottomI = genInd(false);
        }

        private void SetCenterPoints()
        {
            cylinder_CenterP[1] = cylinder_CenterP[0] + new Vector3D(0, 0, z_Displacement);
            cylinder_CenterP[2] = cylinder_CenterP[0] + new Vector3D(0, 0, -z_Displacement);
        }

        private void CirclesToCylinder()
        {
            Int32[] faceIn = new Int32[4];
            totalV = ToAdd(totalV, topV,bottomV);
            totalI = ToAdd(totalI, topI); totalI = ToAdd(topV.Count, totalI, bottomI);

            //Int32[] top_Index = Int32Collection_ToArray(topI), bottom_Index = Int32Collection_ToArray(bottomI);

            for(int i = 1; i < sides; i++)
            {
                faceIn[0] = i; faceIn[1] = i + 1; faceIn[2] = sides + i; faceIn[3] = sides + (1 + i);


            }

        }


    }
}

