using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hra2
{

    public partial class Form1 : Form
    {

        Color[] colors = { Color.Green, Color.Red, Color.DarkGray, Color.Yellow, Color.DarkBlue, Color.Aqua, Color.Gold, Color.Cyan };
        Color c;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );


        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            nastavPozici();
        }
        Graphics g;
        Random rnd = new Random();
        int velikost = 10;
        int x;
        int y;
        int body = 0;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {


            setupniKolecko();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            velikost += 5;
            if(velikost > 60)
            {
                timer1.Stop();
                velikost = 60;
                timer2.Start();
            }
            
            Refresh();
        }
        private void nastavPozici()
        {
            x = rnd.Next(panel1.Width - velikost);
            y = rnd.Next(panel1.Height - velikost);
            c = colors[rnd.Next(colors.Length)];
            velikost = 0;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            velikost -= 5;
            //zdvojnasob
            //ztrojnasob

            if(velikost <= 0)
            {
                //timer2.Stop();
                //timer1.Start();
                //nastavPozici();
                //setupniKolecko();
                Application.Exit();
            }
            Refresh();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
          
        }

        private void setupniKolecko()
        {
            
            Kolecko k = new Kolecko(velikost, c, x, y);
            g = panel1.CreateGraphics();
            k.Vykresli(g);
            
            
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            int mysX = e.X;
            int mysY = e.Y;

            if(mysX > x-velikost/2 && mysX < x + velikost/2 && mysY > y-velikost/2 && mysY < y+velikost/2)
            {

                if (timer2.Enabled == true)
                {
                    if (mysX - velikost < 100 && mysY - velikost < 100)
                    {

                        body += 6;
                    }
                    else if (mysX - velikost < 200 && mysY - velikost < 200)
                    {
                        body += 4;
                    }
                    else
                    {
                        body += 2;

                    }
                }
                else
                {
                    if (mysX - velikost < 100 && mysY - velikost < 100)
                    {

                        body += 3;
                    }
                    else if (mysX - velikost < 200 && mysY - velikost < 200)
                    {
                        body += 2;
                    }
                    else
                    {
                        body++;

                    }
                }
                label1.Text = body.ToString();
                timer2.Stop();
                timer1.Start();
                nastavPozici();
                setupniKolecko();

            }
        }
    }
}
