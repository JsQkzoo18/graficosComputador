using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pixel
{
    internal class Raiz : Circunferencia
    {
        public Raiz(double rad, double x0, double y0) : base(rad, x0, y0)
        {
        }

        public Bitmap encenderR(Bitmap lienzo,bool state)
        {
            double t = 0, dt = 0.001;
            do
            {

                double rx0= ((base.X0) + (base.Rad * (Math.Sin(2*t))));
                double ry0= ((base.Y0) + (base.Rad * (Math.Cos(3*t))));
                Vector v= new Vector(rx0, ry0); v.Color = base.Color;
                if (state)
                {
                    lienzo = v.encender(lienzo);
                }
                else
                {
                    lienzo = v.apagar(lienzo);
                }
                t += dt;
            } while (t <= (2 * Math.PI));
            t = 0;
            return lienzo;
        }
    }
}
