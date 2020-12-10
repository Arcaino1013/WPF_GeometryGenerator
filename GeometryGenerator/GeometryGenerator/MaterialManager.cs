using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace GeometryGenerator
{
    public class MaterialManager
    {
        protected Material materialF, materialB;
        public void InstantiateMaterial()
        {
            materialF = new DiffuseMaterial(new SolidColorBrush(Color.FromRgb(0, 0, 0)));
            materialB = new DiffuseMaterial(new SolidColorBrush(Color.FromRgb(255, 0, 0)));
        }

        public Material MaterialF
        {
            get { return materialF; }
        }

        public Material MaterialB
        {
            get { return materialB; }
        }
    }
}
