using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstCode
{
    
    public class DrawningDumpTruck
    {
        
        public DumpTruck EntityDumpTruck { get; private set; }

        private int _pictureWidth;

        private int _pictureHeight;
        
        private int _startPosX;

        private int _startPosY;

        private readonly int _carWidth = 110;

        private readonly int _carHeight = 60;

        public bool Init(int speed, double weight, Color bodyColor, Color additionalColor, bool bodyKit, bool tent, int width, int height)
        {
            _pictureWidth = width;
            _pictureHeight = height;
            EntityDumpTruck = new DumpTruck();
            EntityDumpTruck.Init(speed, weight, bodyColor, additionalColor, bodyKit, tent);
            return true;
        }
       
        public void SetPosition(int x, int y)
        {
            // TODO: Изменение x, y
            _startPosX = x;
            _startPosY = y;
        }

        public void MoveTransport(DirectionType direction)
        {
            if (EntityDumpTruck == null)
            {
                
                return;
            }
            switch (direction)
            {
                //влево
                case DirectionType.Left:
                    if (_startPosX - EntityDumpTruck.Step > 0)
                    {
                        _startPosX -= (int)EntityDumpTruck.Step;
                    }
                    break;
                //вверх
                case DirectionType.Up:
                   
                    if (_startPosY - EntityDumpTruck.Step > 0)
                    {
                        _startPosY -= (int)EntityDumpTruck.Step;
                    }
                    break;
                // вправо
                case DirectionType.Right:
                    if (_startPosX + EntityDumpTruck.Step + _carWidth < _pictureWidth)
                    {
                        _startPosX += (int)EntityDumpTruck.Step;
                        
                    }
                    break;
                //вниз
                case DirectionType.Down:
                    
                    if (_startPosY + EntityDumpTruck.Step + _carHeight < _pictureHeight)
                    {
                        _startPosY += (int)EntityDumpTruck.Step;
                    }
                    break;
            }
        }
        
        public void DrawTransport(Graphics g)
        {
            if (EntityDumpTruck == null)
            {
                return;
            }
            
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(EntityDumpTruck.BodyColor);
            Brush addBrush = new SolidBrush(EntityDumpTruck.AdditionalColor);

            //границы автомобиля
            g.FillRectangle(brush, _startPosX , _startPosY + 35, 110, 10);
            g.FillRectangle(brush, _startPosX + 85, _startPosY, 25, 35);
            g.FillEllipse(brush, _startPosX, _startPosY + 35 + 10, 15, 15);
            g.FillEllipse(brush, _startPosX + 15, _startPosY + 35 + 10, 15, 15);
            g.FillEllipse(brush, _startPosX + 95, _startPosY + 35 + 10, 15, 15);

            if (EntityDumpTruck.Tent)
            {
                
                Point[] points = new Point[3];
                points[0].X = _startPosX; points[0].Y = _startPosY + 35;
                points[1].X = _startPosX + 85; points[1].Y = _startPosY;
                points[2].X = _startPosX + 85; points[2].Y = _startPosY + 35;
                g.FillPolygon(addBrush, points);
            }

            if (EntityDumpTruck.BodyKit)
            {
                Point[] points = new Point[4];
                points[0].X = _startPosX; points[0].Y = _startPosY + 35;
                points[1].X = _startPosX; points[1].Y = _startPosY;
                points[2].X = _startPosX + 85; points[2].Y = _startPosY;
                points[3].X = _startPosX + 85; points[3].Y = _startPosY + 35;
                g.FillPolygon(addBrush, points);
            }

            if (EntityDumpTruck.BodyKit && EntityDumpTruck.Tent)
            {
                int x = _startPosX;
                int y = _startPosY - 8;
                g.FillRectangle(brush, _startPosX, _startPosY, 95, 3);
                for (int i = 0; i < 6; i++)
                {
                    Rectangle smallRect = new Rectangle(x, y, 15, 15);
                    g.FillPie(brush, smallRect, 0, 180);
                    x += 15;
                }
            }
        }
    }
}


