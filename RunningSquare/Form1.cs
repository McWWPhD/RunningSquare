using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunningSquare
{
    /*Panel skaczący losowo na ekranie i zmieniający kolor co 150ms.
Delta pozycji X i Y wynosi od -75 do 75.*/

    public partial class Form1 : Form
    {
        int maxX, maxY;
        Random random = new Random((int)DateTime.Now.Ticks);

        public Form1()
        {
            InitializeComponent();
        }


        private void timerTicker_Tick(object sender, EventArgs e)
        {
            

            var addX = pnlBox.Location.X + random.Next(-75, 75);
            var addY = pnlBox.Location.Y + random.Next(-75, 75);

            if (pnlBox.Location.X + addX >= 0 && pnlBox.Location.X + pnlBox.Width + addX <= maxX && pnlBox.Location.Y + addY >= 50 && pnlBox.Location.Y + pnlBox.Height + addY <= maxY)
            {
                pnlBox.Location = new Point(addX, addY);
            }

            else
            {
                return;
            }

            byte R = (byte)random.Next(0, 256);
            byte G = (byte)random.Next(0, 256);
            byte B = (byte)random.Next(0, 256);

            pnlBox.BackColor = Color.FromArgb(R, G, B);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form form = (Form)sender;
            maxX = form.Size.Width;
            maxY = form.Size.Height;
        }
    }
}
