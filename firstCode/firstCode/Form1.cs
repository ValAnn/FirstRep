using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstCode
{
    public partial class DumpTruckForm : Form
    {
        
        public DumpTruckForm()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            
            Random random = new Random();
            _drawningDumpTruck = new DrawningDumpTruck();
            _drawningDumpTruck.Init(random.Next(100, 300),
            random.Next(1000, 3000),
            Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)),
            Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)),
            Convert.ToBoolean(random.Next(0, 2)),
            Convert.ToBoolean(random.Next(0, 2)), 
            pictureBox.Width, pictureBox.Height);

            _drawningDumpTruck.SetPosition(random.Next(10, 100),
            random.Next(10, 100));

            Draw();
        }

        private DrawningDumpTruck _drawningDumpTruck;

        private void Draw()
        {
            if (_drawningDumpTruck == null)
            {
                return;
            }
            
            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics gr = Graphics.FromImage(bmp);
            _drawningDumpTruck.DrawTransport(gr);
            pictureBox.Image = bmp;
        }

    private void buttonMove_Click(object sender, EventArgs e)
        {
            
            if (_drawningDumpTruck == null)
            {
                return;
            }
            string name = ((Button)sender) ?. Name ?? string.Empty;
            switch (name)
            {
                case "buttonUp":
                    _drawningDumpTruck.MoveTransport(DirectionType.Up);
                    break;
                case "buttonDown":
                    _drawningDumpTruck.MoveTransport(DirectionType.Down);
                    break;
                case "buttonLeft":
                    _drawningDumpTruck.MoveTransport(DirectionType.Left);
                    break;
                case "buttonRight":
                    _drawningDumpTruck.MoveTransport(DirectionType.Right);
                    break;
            }
            Draw();
        }

    }

    
}
