namespace pixel
{
    public partial class Form1 : Form
    {
        Bitmap pixelVector;
        Bitmap lienzo = new Bitmap(700, 420);
        public Form1()
        {
            InitializeComponent();
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
            Bitmap pintura = new Bitmap(700, 420);
            Vector v = new Vector(0, 1); pintura = v.encender(pintura);
            v.X0 = -1; v.Y0 = 0; pintura = v.encender(pintura);
            v.X0 = 1; pintura = v.encender(pintura);
            v.X0 = 0; v.Y0 = 0; pintura = v.encender(pintura);
            v.X0 = 5; v.Y0 = 0; pintura = v.encender(pintura);
            v.Y0 = 3; pintura = v.encender(pintura);

            panel1.Image = v.encender(pintura);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Segmento seg = new Segmento(-10, 0, 10, 0); seg.Color = Color.Red;
            lienzo = seg.encender(lienzo);
            seg = new Segmento(0,-5.97, 0,5.97);
            lienzo = seg.encender(lienzo);
            panel1.Image = lienzo;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Segmento seg = new Segmento(7, 1.5, -7, 5);
            seg.Color = Color.Blue;
            lienzo = seg.encender(lienzo);
            seg.Xo = 7; seg.Yo = 1.5;seg.Xf = -7; seg.Yf = -4;
            //seg = new Segmento(7, 1.5, -7, -4);
            lienzo = seg.encender(lienzo);
            panel1.Image = lienzo;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Circunferencia c = new Circunferencia(1.3, 7, 1.5); c.Color = Color.Black;
            lienzo=c.encenderC(lienzo);
            c.Rad = 2.5; c.X0 = -3.5; c.Y0 = 1;
            lienzo = c.encenderC(lienzo);
            panel1.Image=lienzo;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Lazo l = new Lazo(0.4, -3.5, 2); l.Color = Color.DarkGreen;
            lienzo=l.encender(lienzo);
            l.Rad = 1; l.X0 = 3; l.Y0 = -3;
            lienzo=l.encender(lienzo); 
            panel1.Image = lienzo;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Raiz r = new Raiz(0.8, 1.5, 4); r.Color = Color.Pink;
            lienzo=r.encenderR(lienzo);
            panel1.Image = lienzo;
        }
    }
}