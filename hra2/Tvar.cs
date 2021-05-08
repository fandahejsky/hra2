using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hra2
{
 abstract class Tvar
    {

        protected int x = 10;
        protected int y = 10;
        protected int velikost = 10;
        protected Color barva = Color.Red;
        protected int body = 0;

        public Tvar(int velikost, Color barva, int x, int y)
        {

            this.velikost = velikost;
            this.barva = barva;
            this.x = x;
            this.y = y;
        }

   

        

        public abstract void Vykresli(Graphics g);
        protected abstract void MouseUp(Point mousePos, MouseButtons button);
    }
}
