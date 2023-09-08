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

        public bool Init(int speed, double weight, Color bodyColor, Color additionalColor, bool bodyKit, bool wing, bool sportLine, int width, int height)
        {
            _pictureWidth = width;
            _pictureHeight = height;
            EntityDumpTruck = new DumpTruck();
            EntityDumpTruck.Init(speed, weight, bodyColor, additionalColor, bodyKit, wing, sportLine);
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
            Brush additionalBrush = new
            SolidBrush(EntityDumpTruck.AdditionalColor);
            // обвесы
            if (EntityDumpTruck.BodyKit)
            {
                g.DrawEllipse(pen, _startPosX + 90, _startPosY, 20, 20);
                g.DrawEllipse(pen, _startPosX + 90, _startPosY + 40, 20,
                20);
                g.DrawRectangle(pen, _startPosX + 90, _startPosY + 10,
                20, 40);
                g.DrawRectangle(pen, _startPosX + 90, _startPosY, 15,
                15);
                g.DrawRectangle(pen, _startPosX + 90, _startPosY + 45,
                15, 15);
                g.FillEllipse(additionalBrush, _startPosX + 90,
                _startPosY, 20, 20);
                g.FillEllipse(additionalBrush, _startPosX + 90,
                _startPosY + 40, 20, 20);
                g.FillRectangle(additionalBrush, _startPosX + 90,
                _startPosY + 10, 20, 40);
            g.FillRectangle(additionalBrush, _startPosX + 90,
            _startPosY + 1, 15, 15);
                g.FillRectangle(additionalBrush, _startPosX + 90,
                _startPosY + 45, 15, 15);
                g.DrawEllipse(pen, _startPosX, _startPosY, 20, 20);
                g.DrawEllipse(pen, _startPosX, _startPosY + 40, 20, 20);
                g.DrawRectangle(pen, _startPosX, _startPosY + 10, 20,
                40);
                g.DrawRectangle(pen, _startPosX + 5, _startPosY, 14,
                15);
                g.DrawRectangle(pen, _startPosX + 5, _startPosY + 45,
                14, 15);
                g.FillEllipse(additionalBrush, _startPosX, _startPosY,
                20, 20);
                g.FillEllipse(additionalBrush, _startPosX, _startPosY +
                40, 20, 20);
                g.FillRectangle(additionalBrush, _startPosX + 1,
                _startPosY + 10, 25, 40);
                g.FillRectangle(additionalBrush, _startPosX + 5,
                _startPosY + 1, 15, 15);
                g.FillRectangle(additionalBrush, _startPosX + 5,
                _startPosY + 45, 15, 15);
                g.DrawRectangle(pen, _startPosX + 35, _startPosY, 39,
                15);
                g.DrawRectangle(pen, _startPosX + 35, _startPosY + 45,
                39, 15);
                g.FillRectangle(additionalBrush, _startPosX + 35,
                _startPosY + 1, 40, 15);
                g.FillRectangle(additionalBrush, _startPosX + 35,
                _startPosY + 45, 40, 15);
            }
            //границы автомобиля
            
            g.DrawEllipse(pen, _startPosX + 10, _startPosY + 5, 20, 20);
            g.DrawEllipse(pen, _startPosX + 10, _startPosY + 35, 20, 20);
            g.DrawEllipse(pen, _startPosX + 80, _startPosY + 5, 20, 20);
            g.DrawEllipse(pen, _startPosX + 80, _startPosY + 35, 20, 20);
            g.DrawRectangle(pen, _startPosX + 9, _startPosY + 15, 10, 30);
            g.DrawRectangle(pen, _startPosX + 90, _startPosY + 15, 10,
            30);
            g.DrawRectangle(pen, _startPosX + 20, _startPosY + 4, 70, 52);
            //задние фары
            Brush brRed = new SolidBrush(Color.Red);
            g.FillEllipse(brRed, _startPosX + 10, _startPosY + 5, 20, 20);
            g.FillEllipse(brRed, _startPosX + 10, _startPosY + 35, 20,
            20);
            //передние фары
            Brush brYellow = new SolidBrush(Color.Yellow);
            g.FillEllipse(brYellow, _startPosX + 80, _startPosY + 5, 20,
            20);
            g.FillEllipse(brYellow, _startPosX + 80, _startPosY + 35, 20,
            20);
            //кузов
            Brush br = new SolidBrush(EntityDumpTruck.BodyColor);
            g.FillRectangle(br, _startPosX + 10, _startPosY + 15, 10, 30);
            g.FillRectangle(br, _startPosX + 90, _startPosY + 15, 10, 30);
            g.FillRectangle(br, _startPosX + 20, _startPosY + 5, 70, 50);
            
        //стекла
Brush brBlue = new SolidBrush(Color.LightBlue);
            g.FillRectangle(brBlue, _startPosX + 70, _startPosY + 10, 5,
            40);
            g.FillRectangle(brBlue, _startPosX + 30, _startPosY + 10, 5,
            40);
            g.FillRectangle(brBlue, _startPosX + 35, _startPosY + 8, 35,
            2);
            g.FillRectangle(brBlue, _startPosX + 35, _startPosY + 51, 35,
            2);
            //выделяем рамкой крышу
            g.DrawRectangle(pen, _startPosX + 35, _startPosY + 10, 35,
            40);
            g.DrawRectangle(pen, _startPosX + 75, _startPosY + 15, 25,
            30);
            g.DrawRectangle(pen, _startPosX + 10, _startPosY + 15, 15,
            30);
            // спортивная линия
            if (EntityDumpTruck.SportLine)
            {
                g.FillRectangle(additionalBrush, _startPosX + 75,
                _startPosY + 23, 25, 15);
                g.FillRectangle(additionalBrush, _startPosX + 35,
                _startPosY + 23, 35, 15);
                g.FillRectangle(additionalBrush, _startPosX + 10,
                _startPosY + 23, 20, 15);
            }
            // крыло
            if (EntityDumpTruck.Wing)
            {
                g.FillRectangle(additionalBrush, _startPosX, _startPosY
                + 5, 10, 50);
                g.DrawRectangle(pen, _startPosX, _startPosY + 5, 10,
                50);
            }
        }
    }
}


