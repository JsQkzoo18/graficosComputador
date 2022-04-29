using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pixel
{
    internal class Segmento : Vector
    {
        //atributos
        double xo=0;
        double yo=0;
        double xf=0;
        double yf=0;

        public Segmento(double xo, double yo, double xf, double yf): base(0, 0)
        {            
            this.xo = xo;
            this.yo = yo;
            this.xf = xf;
            this.yf = yf;
        }

        public double Xo { get => xo; set => xo = value; }
        public double Yo { get => yo; set => yo = value; }
        public double Xf { get => xf; set => xf = value; }
        public double Yf { get => yf; set => yf = value; }

        //metodos 
        public Bitmap encender(Bitmap lienzo)
        {

            double t = 0;
            double dt = 0.001;
            
            do
            {
                base.X0 = (xo * (1 - t) + (xf * t));
                base.Y0 = (yo * (1 - t) + (yf * t));
                lienzo = base.encender(lienzo);
                t += dt;
            } while (t <= 1);
            t = 0;
            return lienzo;
        }
    }
}
