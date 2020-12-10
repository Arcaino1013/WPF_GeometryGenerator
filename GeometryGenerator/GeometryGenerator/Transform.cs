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
        public void Translate(Vector3D displacement)
        {
            throw new NotImplementedException("Havent worked on this yet");
        }

        public void Scale(float factor)
        {
            throw new NotImplementedException("Havent worked on this yet");
        }

        public void Rotate(float angle)
        {
            throw new NotImplementedException("Havent worked on this yet");
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
