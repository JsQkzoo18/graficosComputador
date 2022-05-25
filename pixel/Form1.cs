namespace pixel
{
    public partial class Form1 : Form
    {
        Bitmap pixelVector;
        Bitmap lienzo = new Bitmap(700, 420);

        bool[] banderas = {true,true, true, true, true, true, true, true, true };
        
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 700; i++)
            {
                for(int j = 0; j <420; j++)
                {
                    lienzo.SetPixel(i,j, Color.White);
                }

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            pixelVector = new Bitmap(520, 260);
            panel1.BackgroundImage = pixelVector;
            Color color0 = Color.Blue;

            Point point = panel1.PointToClient(Cursor.Position);
            int x = point.X;
            int y = point.Y;
            pixelVector.SetPixel(x, y, color0);
            panel1.Image = pixelVector;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap pintura = lienzo;
            Vector v = new Vector(0, 1);
            if (banderas[0]) pintura = v.encender(pintura);
            else pintura = v.apagar(pintura);
            v.X0 = -1; v.Y0 = 0;
            if (banderas[0]) pintura = v.encender(pintura);
            else pintura = v.apagar(pintura);
            v.X0 = 1; if (banderas[0]) pintura = v.encender(pintura);
            else pintura = v.apagar(pintura);
            v.X0 = 0; v.Y0 = 0; if (banderas[0]) pintura = v.encender(pintura);
            else pintura = v.apagar(pintura);
            v.X0 = 5; v.Y0 = 0; if (banderas[0]) pintura = v.encender(pintura);
            else pintura = v.apagar(pintura);
            v.Y0 = 3; if (banderas[0]) pintura = v.encender(pintura);
            else pintura = v.apagar(pintura);

            panel1.Image = v.encender(pintura);
            banderas[0] = !banderas[0];
            button1.Text = "Pixels: " + banderas[3].ToString();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Segmento seg = new Segmento(-10, 0, 10, 0); seg.Color = Color.Red;
            lienzo = seg.encender(lienzo, banderas[1]);
            seg = new Segmento(0, -5.97, 0, 5.97);
            lienzo = seg.encender(lienzo,banderas[1]);
            panel1.Image = lienzo;
            banderas[1] = !banderas[1];
            button2.Text = "Ejes2D: " + banderas[1].ToString();


        }


        private void button3_Click(object sender, EventArgs e)
        {
            Segmento seg = new Segmento(7, 1.5, -7, 5);
            seg.Color = Color.Blue;
            lienzo = seg.encender(lienzo, banderas[2]);
            seg.Xo = 7; seg.Yo = 1.5; seg.Xf = -7; seg.Yf = -4;
            //seg = new Segmento(7, 1.5, -7, -4);
            lienzo = seg.encender(lienzo, banderas[2]);
            panel1.Image = lienzo;
            banderas[2] = !banderas[2];
            button3.Text = "Segmento: " + banderas[2].ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Circunferencia c = new Circunferencia(1.3, 7, 1.5); c.Color = Color.Black;
            lienzo = c.encenderC(lienzo,banderas[3]);
            c.Rad = 2.5; c.X0 = -3.5; c.Y0 = 1;
            lienzo = c.encenderC(lienzo,banderas[3]);
            panel1.Image = lienzo;
            banderas[3] = !banderas[3];
            button4.Text = "Circunrencia: " + banderas[3].ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Lazo l = new Lazo(0.4, -3.5, 2); l.Color = Color.DarkGreen;
            lienzo = l.encender(lienzo,banderas[4]);
            l.Rad = 1; l.X0 = 3; l.Y0 = -3;
            lienzo = l.encender(lienzo,banderas[4]);
            panel1.Image = lienzo;
            banderas[4] = !banderas[4];
            button5.Text = "Lazo: " + banderas[4].ToString();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Raiz r = new Raiz(0.8, 1.5, 4); r.Color = Color.Pink;
            lienzo = r.encenderR(lienzo,banderas[5]);
            panel1.Image = lienzo;
            banderas[5] = !banderas[5];
            button6.Text = "Raiz: " + banderas[5].ToString();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            espiral(2, 2, 2, 2, 5, 15, Color.Green);
            espiral(3, 4, 0, 0.5, 20, 20, Color.Black);
            espiral(4, 0, 1, 0.8, 15, 20, Color.Blue);
            banderas[6] = !banderas[6];
            button7.Text = "Resorte: " + banderas[6].ToString();

        }


        //proceso de espiral parametrizado
        public void espiral(double x, double y, double z, double radio, double elong, double vueltas, Color c)
        {
            double h = 0;
            vector3D V3D = new vector3D(0, 0, 0); V3D.Color = c;
            do
            { //ubicar al objeto en el espacio = [num] traslacion
                //radio = +[num] 
                //h/[num] mide la elongación del resorte mientras grande el numero mas compacto
                //h<= [num] mide cuentas vueltas da el espiral, mas vueltas aumentar num
                V3D.X = x + radio * Math.Cos(h);
                V3D.Y = y + radio * Math.Sin(h);
                V3D.Z = z + (h / elong);
                if (banderas[6])
                    lienzo = V3D.encender3d(lienzo);
                else
                    lienzo = V3D.apagar3d(lienzo);
                h += 0.002;
            } while (h <= vueltas);
            panel1.Image = lienzo;
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Segmento3D s3d = new Segmento3D();
            s3d.Color = Color.Red;
            s3d.Zf = 5;
            lienzo = s3d.encenderSeg3D(lienzo,banderas[7]);
            s3d.Zf = 0; s3d.Yf = 5;
            lienzo = s3d.encenderSeg3D(lienzo, banderas[7]);
            s3d.Yf = 0; s3d.Xf = 8;
            lienzo = s3d.encenderSeg3D(lienzo, banderas[7]);
            s3d = new Segmento3D(0, 0, 5, 8, 0, 5);
            lienzo = s3d.encenderSeg3D(lienzo, banderas[7]);
            s3d = new Segmento3D(8, 0, 5, 8, 0, 0);
            lienzo = s3d.encenderSeg3D(lienzo, banderas[7]);
            s3d = new Segmento3D(8, 0, 0, 8, 5, 0);
            lienzo = s3d.encenderSeg3D(lienzo, banderas[7]);
            s3d = new Segmento3D(8, 5, 0, 0, 5, 0);
            lienzo = s3d.encenderSeg3D(lienzo, banderas[7]);
            s3d = new Segmento3D(0, 5, 0, 0, 5, 5);
            lienzo = s3d.encenderSeg3D(lienzo, banderas[7]);
            s3d = new Segmento3D(0, 5, 5, 0, 0, 5);
            lienzo = s3d.encenderSeg3D(lienzo, banderas[7]);
            //mostrar segmentos
            panel1.Image = lienzo;
            banderas[7] = !banderas[7];
            button8.Text = "Base3D: " + banderas[7].ToString();

        }

        public void lagrange(double x)
        {
            List<double>[] puntos = new List<double>[2];
            puntos[0] = new List<double> { 0, 255 };
            puntos[1] = new List<double> { 700, 0 };

            double s = 0, p = 1;
            int n = puntos.Length;

            for(int i = 0; i < n; i++)
            {
                p = 1;
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        p = p * (x - puntos[1][0]);
                    }
                }
            }
           
        }

        
        

        //datos lagrange
        //int[] b = { 0, 0 };
        //lagrange
        //public double lagrange(double x)
        //{
        //    double s = 0, p = 1;
        //    int i = 0, j = 0;
        //    int n = 4;//tamaño del vecto

        //    for (i = 0; i < n; i++)
        //    {
        //        p = 1;
        //        for (int j = 0; j < n; j++)
        //        {
        //            if (i != j)
        //            {
        //                p = p * (x - xj) / (xi - xj);
        //            }
        //        }
        //        s += (yi * p);
        //    }


        //    return s;
        //}

        private void button9_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 700; i++)
            {
                for(int j = 0; j < 420; j++)
                {

                    //int b = (int)((255) * ((i - 700) / -700));

                    int b= (int)((-255 * (i - 700)) / 700);

                    int g = (int)((255 * i) / 700);

                    if(banderas[8])
                        lienzo.SetPixel(i, j, Color.FromArgb(255,0, g, b));
                    else
                        lienzo.SetPixel(i, j, Color.White);

                    //if (i > 350)
                    //{
                    //    lienzo.SetPixel(i, j, Color.Green);
                    //}
                    //else
                    //{
                    //    lienzo.SetPixel(i, j, Color.FromArgb(0,0,255));
                    //}
                    //lienzo.SetPixel(i, j, Color.FromArgb(255, 0, (int)((255 * i) / 700), (-255 * (i - 700)) / 700));

                }
            }
            panel1.Image = lienzo;
            banderas[8]=!banderas[8];
            button9.Text = "Colores: " + banderas[8].ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (panel1.Image != null)
            {
                //panel1.Image.Dispose();
                panel1.Image = null;
                panel1.InitialImage = null;
            }

          
        }
    }
    }
