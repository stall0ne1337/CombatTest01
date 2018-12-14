using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatTest01.Models
{
    public class Wall : Entity
    {
        private double _width;
        public double Width
        {
            get { return _width; }
            set
            {
                _width = value;
                OnPropertyChanged(nameof(Width));
            }
        }

        private double _height;
        public double Height
        {
            get { return _height; }
            set
            {
                _height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        public Wall(EntityPosition position, double width, double height)
            : base(position)
        {
            this.Width = width;
            this.Height = height;

            this.SetCollisionDistanceX(width);
            this.SetCollisionDistanceY(height);
        }
    }
}
