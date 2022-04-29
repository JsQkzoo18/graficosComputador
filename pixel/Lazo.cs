using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pixel
{
    internal class Lazo : Circunferencia
    {
        double t = 0;
        double dt = 0.001;
        public Lazo(double rad, double x0, double y0) : base(rad, x0, y0)
        {

        }

        public Bitmap encender(Bitmap lienzo)
        {
            do
            {
                double p0 = (base.X0) + base.Rad * (Math.Cos(2 * t));
                double q0 = (base.Y0) + base.Rad * (Math.Sin(3 * t));
                Vector v = new Vector(p0, q0);
                v.Color = base.Color;
                lienzo = v.encender(lienzo);
                t += dt;
            } while (t <= (3 * Math.PI));
            t = 0;
            return lienzo;
        }
    }
}
