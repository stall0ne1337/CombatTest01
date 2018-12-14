using CombatTest01.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace CombatTest01.Models
{
    public class Tank : MovableEntity, IExecutableEntity
    {
        private const double DefaultSpeed = 3;

        private Projectile _currentProjectile;

        public Player Player { get; private set; }

        private SolidColorBrush _fill;
        public SolidColorBrush Fill
        {
            get { return _fill; }
            set
            {
                _fill = value;
                OnPropertyChanged(nameof(Fill));
            }
        }

        private int _score;
        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                OnPropertyChanged(nameof(Score));
            }
        }

        public Tank(EntityPosition position, Player player)
            : base(position, DefaultSpeed)
        {
            this.Player = player;

            SetCollisionDistanceX(50);
            SetCollisionDistanceY(50);
        }

        public void Execute()
        {
            if (_currentProjectile != null && _currentProjectile.IsDead)
                _currentProjectile = null;

            if (_currentProjectile == null && InputHelper.GetTankShootInput(this.Player))
            {
                _currentProjectile = new Projectile(GetProjectileLaunchPosition(), this);
                _currentProjectile.Orientation = this.Orientation;

                this.ParentCollection.Add(_currentProjectile);
            }

            var input = InputHelper.GetTankMoveInput(this.Player);

            if (input != EntityOrientation.None)
                this.Move(input);
        }

        private EntityPosition GetProjectileLaunchPosition()
        {
            EntityPosition retVal = new EntityPosition(0, 0);

            switch (Orientation)
            {
                case EntityOrientation.Right:
                    retVal.PosX = this.Position.PosX + CollisionDistanceX;
                    retVal.PosY = this.Position.PosY + CollisionDistanceY / 2 - 3;
                    break;

                case EntityOrientation.DownRight:
                    retVal.PosX = this.Position.PosX + CollisionDistanceX - 7;
                    retVal.PosY = this.Position.PosY + CollisionDistanceY - 7;
                    break;

                case EntityOrientation.Down:
                    retVal.PosX = this.Position.PosX + CollisionDistanceX / 2 - 5;
                    retVal.PosY = this.Position.PosY + CollisionDistanceY;
                    break;

                case EntityOrientation.DownLeft:
                    retVal.PosX = this.Position.PosX - 3;
                    retVal.PosY = this.Position.PosY + CollisionDistanceY - 4;
                    break;

                case EntityOrientation.Left:
                    retVal.PosX = this.Position.PosX - 7;
                    retVal.PosY = this.Position.PosY + CollisionDistanceY / 2 - 2;
                    break;

                case EntityOrientation.UpLeft:
                    retVal.PosX = this.Position.PosX - 2;
                    retVal.PosY = this.Position.PosY;
                    break;

                case EntityOrientation.Up:
                    retVal.PosX = this.Position.PosX + CollisionDistanceX / 2 - 6;
                    retVal.PosY = this.Position.PosY - 7;
                    break;

                case EntityOrientation.UpRight:
                    retVal.PosX = this.Position.PosX + CollisionDistanceX - 9;
                    retVal.PosY = this.Position.PosY + 2;
                    break;
            }
            
            return retVal;
        }
    }
}
