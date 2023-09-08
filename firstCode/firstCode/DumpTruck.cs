using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstCode
{
    public class DumpTruck
    {

        /// <summary>
        /// Скорость
        /// </summary>
        public int Speed { get; private set; }

        /// <summary>
        /// Вес
        /// </summary>
        public double Weight { get; private set; }

        /// <summary>
        /// Основной цвет
        /// </summary>
        public Color BodyColor { get; private set; }

        /// <summary>
        /// Дополнительный цвет (для опциональных элементов)
        /// </summary>
        public Color AdditionalColor { get; private set; }

        /// <summary>
        /// Признак (опция) наличия кузова
        /// </summary>
        public bool BodyKit { get; private set; }

        /// <summary>
        /// Признак (опция) наличия tent
        /// </summary>
        public bool Tent { get; private set; }

        /// <summary>
        /// Шаг перемещения автомобиля
        /// </summary>
        public double Step => (double)Speed * 100 / Weight;

        public void Init(int speed, double weight, Color bodyColor, Color
    additionalColor, bool bodyKit, bool tent)
        {
            Speed = speed;
            Weight = weight;
            BodyColor = bodyColor;
            AdditionalColor = additionalColor;
            BodyKit = bodyKit;
            Tent = tent;
           
        }
    }

}
 



