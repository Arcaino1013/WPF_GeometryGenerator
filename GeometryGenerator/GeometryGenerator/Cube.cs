﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace GeometryGenerator
{
    public class Cube : Transform
    {
        DiffuseMaterial cubeFMat = new DiffuseMaterial(new SolidColorBrush(Color.FromRgb(0,0,0))), cubeBMat = new DiffuseMaterial(new SolidColorBrush(Color.FromRgb(255,0,0)));
        Int32Collection cubeInd = new Int32Collection(36);
        Vector3DCollection cubeDisplacement = new Vector3DCollection(8);

        public Cube()
        {
            materialM.InstantiateMaterial();
            createVector();
            preMesh.Positions = cubePoints(new Point3D(0, 0, 0));
            for(int i = 0; i < 6; i++)
            {
                SetIndex(i);
            }
            preMesh.TriangleIndices = cubeInd;
            model.Geometry = preMesh;
            model.Material = cubeFMat;
            model.BackMaterial = cubeBMat;
        }

        public Cube(Point3D centerP)
        {
            materialM.InstantiateMaterial();
            createVector();
            preMesh.Positions = cubePoints(centerP);
            for(int i = 0;i < 6;i++)
            {
                SetIndex(i);
            }
            preMesh.TriangleIndices = cubeInd;
            model.Geometry = preMesh;
            model.Material = cubeFMat;
            model.BackMaterial = cubeBMat;
        }

        public Cube(int scale)
        {
            materialM.InstantiateMaterial();
            createVector();
            preMesh.Positions = cubePoints(new Point3D(0,0,0),scale);
            for (int i = 0; i < 6; i++)
            {
                SetIndex(i);
            }
            preMesh.TriangleIndices = cubeInd;
            model.Geometry = preMesh;
            model.Material = cubeFMat;
            model.BackMaterial = cubeBMat;
        }

        public Cube(Point3D centerP,int scale)
        {
            materialM.InstantiateMaterial();
            createVector();
            preMesh.Positions = cubePoints(centerP,scale);
            for (int i = 0; i < 6; i++)
            {
                SetIndex(i);
            }
            preMesh.TriangleIndices = cubeInd;
            model.Geometry = preMesh;
            model.Material = cubeFMat;
            model.BackMaterial = cubeBMat;
        }

        private void createVector()
        {
            int z = -1, marker = 0;
            for (int i = 0; i < 8; i++)
            {
                if (i > 3)
                {
                    z = 1;
                    marker = i - 4;
                } else
                {
                    z = -1;
                    marker = i;
                }
                switch (marker)
                {
                    case 0:
                        cubeDisplacement.Add(new Vector3D(-1, 1, z));
                        break;
                    case 1:
                        cubeDisplacement.Add(new Vector3D(1, 1, z));
                        break;
                    case 2:
                        cubeDisplacement.Add(new Vector3D(-1, -1, z));
                        break;
                    case 3:
                        cubeDisplacement.Add(new Vector3D(1, -1, z));
                        break;
                    default:
                        throw new Exception("Something went wrong. The value for the int marker is out of range. Marker value:" + marker.ToString());
                }
            }
        }

        private Point3DCollection cubePoints(Point3D center)
        {
            Point3D newPoint = new Point3D();
            Point3DCollection value = new Point3DCollection(8);
            foreach(Vector3D vector in cubeDisplacement)
            {
                newPoint = center + vector;
                value.Add(newPoint);
            }
            return value;
        }

        private Point3DCollection cubePoints(Point3D center, int scale)
        {
            Point3D newPoint = new Point3D();
            Point3DCollection value = new Point3DCollection(8);
            foreach (Vector3D vector in cubeDisplacement)
            {
                newPoint = center + (vector*scale);
                value.Add(newPoint);
            }
            return value;
        }

        private void SetIndex(int i)
        {
            switch (i)
            {
                //Front
                case 0:
                    cubeInd.Add(0); cubeInd.Add(1); cubeInd.Add(2); cubeInd.Add(3); cubeInd.Add(2); cubeInd.Add(1);
                    break;
                //Back
                case 1:
                    cubeInd.Add(6); cubeInd.Add(5); cubeInd.Add(4); cubeInd.Add(5); cubeInd.Add(6); cubeInd.Add(7);
                    break;
                //Top
                case 2:
                    cubeInd.Add(0); cubeInd.Add(4); cubeInd.Add(5); cubeInd.Add(5); cubeInd.Add(1); cubeInd.Add(0);
                    break;
                //Bottom
                case 3:
                    cubeInd.Add(7); cubeInd.Add(6); cubeInd.Add(2); cubeInd.Add(2); cubeInd.Add(3); cubeInd.Add(7);
                    break;
                //Left
                case 4:
                    cubeInd.Add(4); cubeInd.Add(0); cubeInd.Add(2); cubeInd.Add(2); cubeInd.Add(6); cubeInd.Add(4);
                    break;
                //Right
                case 5:
                    cubeInd.Add(3); cubeInd.Add(1); cubeInd.Add(5); cubeInd.Add(5); cubeInd.Add(7); cubeInd.Add(3);
                    break;
                //0<Number>5 Creates Exception
                default:
                    throw new Exception("Wrong Number for i. i = " + i.ToString());
            }
        }

        public DiffuseMaterial CubeFMat
        {
            get 
            {
                cubeFMat = (DiffuseMaterial)model.Material;
                return cubeFMat;
            }
            set
            {
                DiffuseMaterial diffuseMaterial = value as DiffuseMaterial;
                if(diffuseMaterial != null)
                {
                    if (diffuseMaterial.Color == Color.FromRgb(255, 0, 0))
                    {
                        throw new Exception("Red is the Back material");
                    } else
                    {
                        cubeFMat = diffuseMaterial;
                        SetMaterial();
                    }
                } else 
                {
                    throw new Exception("You have not passed a material");
                }
            }
        }

        private void SetMaterial()
        {
            model.Material = cubeFMat;
        }

    }
}
