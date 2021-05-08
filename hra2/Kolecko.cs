using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hra2
{
    class Kolecko : Tvar
    {
        

      

        public Kolecko(int velikost, Color barva, int x, int y): base(velikost, barva, x, y)
        {

        }

        public override void Vykresli(Graphics g)
        {
           
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            SolidBrush b = new SolidBrush(barva);
            g.FillEllipse(b, x-velikost/2, y-velikost/2, velikost, velikost);
        }
        
        protected override void MouseUp(Point mousePos, MouseButtons button)
        {
            if(button == MouseButtons.Left)
            {
                body++;
            }
            else
            {
                body--;
            }
            
        }

    }
}
