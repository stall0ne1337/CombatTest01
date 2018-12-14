using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatTest01.Models
{
    public class Entity : ViewModel
    {
        public EntityCollection ParentCollection { get; set; }
        public double CollisionDistanceX { get; private set; }
        public double CollisionDistanceY { get; private set; }        
        public EntityPosition Position { get; private set; }        
        public Guid Id { get; private set; }

        public Entity(EntityPosition position)
            : this(position, 0, 0)
        {

        }

        public Entity(EntityPosition position, double collisionDistanceX, double collisionDistanceY)
        {
            this.Id = Guid.NewGuid();
            this.Position = position;

            SetCollisionDistanceX(collisionDistanceX);
            SetCollisionDistanceY(collisionDistanceY);
        }

        protected void SetCollisionDistanceX(double value)
        {
            this.CollisionDistanceX = value;
        }

        protected void SetCollisionDistanceY(double value)
        {
            this.CollisionDistanceY = value;
        }
    }
}
