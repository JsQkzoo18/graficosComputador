using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pixel
{
    internal class Circunferencia:Vector
    {
        //private Vector vector = new Vector(0, 0);
        private double rad;    
        double x0;
        double y0;

        //definidos
        double t=0;
        double dt=0.001;

        public Circunferencia(double rad, double x0, double y0):base(0,0)
        {
            this.rad = rad;
            this.x0 = x0;
            this.y0 = y0;
        }

        public double Rad { get => rad; set => rad = value; }
        public double X0 { get => x0; set { x0 = value;base.X0 = value; } }
        public double Y0 { get => y0; set => y0 = value; }

        public virtual Bitmap encenderC(Bitmap lienzo)
        {
            do
            {
                
                base.X0 = ((x0) + (rad * (Math.Cos(t))));
                base.Y0 = ((y0) + (rad * (Math.Sin(t))));
                lienzo = base.encender(lienzo);
                t += dt;
            }while(t<=(2*Math.PI));
            t = 0;            
            return lienzo;
        }
    }
}
