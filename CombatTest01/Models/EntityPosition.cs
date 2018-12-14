using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatTest01.Models
{
    public class EntityPosition : ViewModel
    {
        private double _posX;
        public double PosX
        {
            get { return _posX; }
            set
            {
                _posX = value;
                OnPropertyChanged(nameof(PosX));
            }
        }

        private double _posY;
        public double PosY
        {
            get { return _posY; }
            set
            {
                _posY = value;
                OnPropertyChanged(nameof(PosY));
            }
        }

        public EntityPosition(double posX, double posY)
        {
            this.PosX = posX;
            this.PosY = posY;
        }
    }
}
