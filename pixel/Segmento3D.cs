using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pixel
{
    internal class Segmento3D:vector3D
    {
        double xf = 0;
        double yf = 0;
        double zf = 0;

        double xo=0;
        double yo=0;
        double zo=0;

        public Segmento3D(double xo, double yo, double zo,double xf, double yf, double zf):base(0,0,0)
        {
            this.xf = xf;
            this.yf = yf;
            this.zf = zf;
            this.xo = xo;
            this.yo = yo;
            this.zo = zo;
        }

        public Segmento3D():base(0,0,0)
        {
        }

        public double Xf { get => xf; set => xf = value; }
        public double Yf { get => yf; set => yf = value; }
        public double Zf { get => zf; set => zf = value; }
        public double Xo { get => xo; set => xo = value; }
        public double Yo { get => yo; set => yo = value; }
        public double Zo { get => zo; set => zo = value; }

        
        public Bitmap encenderSeg3D(Bitmap lienzo, bool state)
        {
            double t = 0, dt = 0.001;
            do
            {
                base.X = (xo * (1 - t) + (xf * t));
                base.Y = (yo * (1 - t) + (yf * t));
                base.Z = (zo * (1 - t) + (zf * t));
                if(state)
                    lienzo = encender3d(lienzo);
                else
                    lienzo = apagar3d(lienzo);
                t += dt;

            } while (t <= 1);
            return lienzo;
        }
    }
}
