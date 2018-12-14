using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatTest01.Models
{
    public class MovableEntity : Entity
    {
        public double Speed { get; private set; }

        private EntityOrientation _orientation;
        public EntityOrientation Orientation
        {
            get { return _orientation; }
            set
            {
                _orientation = value;
                OnPropertyChanged(nameof(Orientation));
            }
        }
        
        public MovableEntity(EntityPosition position, double speed)
            : base(position)
        {
            this.Speed = speed;
        }

        public EntityCollision Move()
        {
            return Move(Orientation);
        }

        public EntityCollision Move(EntityOrientation direction)
        {
            return Move(direction, Speed);
        }

        public EntityCollision Move(EntityOrientation direction, double speed)
        {
            this.Orientation = direction;

            EntityPosition newPosition = new EntityPosition(this.Position.PosX, this.Position.PosY);

            switch (direction)
            {
                case EntityOrientation.Left:
                    newPosition.PosX -= speed;
                    break;

                case EntityOrientation.UpLeft:
                    newPosition.PosX -= speed / 2;
                    newPosition.PosY -= speed / 2;
                    break;

                case EntityOrientation.Up:
                    newPosition.PosY -= speed;
                    break;

                case EntityOrientation.UpRight:
                    newPosition.PosX += speed / 2;
                    newPosition.PosY -= speed / 2;
                    break;

                case EntityOrientation.Right:
                    newPosition.PosX += speed;
                    break;

                case EntityOrientation.DownRight:
                    newPosition.PosX += speed / 2;
                    newPosition.PosY += speed / 2;
                    break;

                case EntityOrientation.Down:
                    newPosition.PosY += speed;
                    break;

                case EntityOrientation.DownLeft:
                    newPosition.PosX -= speed / 2;
                    newPosition.PosY += speed / 2;
                    break;
            }

            Entity collisionEntity = ParentCollection.Items.FirstOrDefault(x => x != this && x.IsColliding(newPosition, this.CollisionDistanceX, this.CollisionDistanceY));

            if (collisionEntity != null)
            {
                if (this is Projectile)
                {
                    if (((Projectile)this).IsValidCollision(collisionEntity))
                        return new EntityCollision(collisionEntity);
                }
                else
                {
                    return new EntityCollision(collisionEntity);
                }                    
            }

            this.Position.PosX = newPosition.PosX;
            this.Position.PosY = newPosition.PosY;            

            return null;
        }
    }    
}
