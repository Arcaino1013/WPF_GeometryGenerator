using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace GeometryGenerator
{
    public class Transform : Object_3D
    {
        private Matrix3D transform_matrix = new MatrixTransform3D().Matrix;
        public void Translate(Vector3D displacement)
        {
            TranslateTransform3D translate = new TranslateTransform3D(displacement);
            transform_matrix = translate.Value;
            Reset_preMesh();
            Point3D[] points = Point3DCollection_ToArray(preMesh.Positions);
            preMesh.Positions = new Point3DCollection();
            for(int i = 0; i < points.Length; i++)
            {
                preMesh.Positions.Add(points[i] * transform_matrix);
            }
            model.Geometry = preMesh;
            //throw new NotImplementedException("Havent worked on this yet");
        }

        public void Scale(Vector3D scaleFaktor)
        {
            ScaleTransform3D scale = new ScaleTransform3D(scaleFaktor);
            transform_matrix = scale.Value;
            Reset_preMesh();
            Point3D[] points = Point3DCollection_ToArray(preMesh.Positions);
            preMesh.Positions = new Point3DCollection();
            for (int i = 0; i < points.Length; i++)
            {
                preMesh.Positions.Add(points[i] * transform_matrix);
            }
            model.Geometry = preMesh;
            //throw new NotImplementedException("Havent worked on this yet");
        }

        public void Rotate(Rotation3D angleR, Point3D center)
        {
            Matrix3DConverter converter = new Matrix3DConverter();
            
            Reset_preMesh();
            Point3D[] points = Point3DCollection_ToArray(preMesh.Positions);
            preMesh.Positions = new Point3DCollection();
            for (int i = 0; i < points.Length; i++)
            {
                preMesh.Positions.Add(points[i] * transform_matrix);
            }
            model.Geometry = preMesh;
            //throw new NotImplementedException("Havent worked on this yet");
        }

        protected Int32[] Int32Collection_ToArray(Int32Collection toConvert)
        {
            int size = toConvert.Count,counter = 0;
            Int32[] toReturn = new Int32[size];

            foreach(Int32 number in toConvert)
            {
                toReturn[counter] = number;
                counter++;
            }

            return toReturn;
        }

        protected Point3D[] Point3DCollection_ToArray(Point3DCollection toConvert)
        {
            int size = toConvert.Count, counter = 0;
            Point3D[] toReturn = new Point3D[size];

            foreach (Point3D point in toConvert)
            {
                toReturn[counter] = point;
                counter++;
            }

            return toReturn;
        }

        protected Point3DCollection ToAdd(Point3DCollection destiny,params Point3DCollection[] toAdd)
        {
            for(int i = 0; i < toAdd.Length; i++)
            {
                foreach (Point3D point in toAdd[i])
                {
                    destiny.Add(point);
                }
            }
            return destiny;
        }

        protected Int32Collection ToAdd(Int32Collection destiny, params Int32Collection[] toAdd)
        {
            for (int i = 0; i < toAdd.Length; i++)
            {
                foreach (int point in toAdd[i])
                {
                    destiny.Add(point);
                }
            }
            return destiny;
        }

        protected Int32Collection ToAdd(int offset,Int32Collection destiny, params Int32Collection[] toAdd)
        {
            for (int i = 0; i < toAdd.Length; i++)
            {
                foreach (int point in toAdd[i])
                {
                    destiny.Add(point + offset);
                }
            }
            return destiny;
        }
    }
}
