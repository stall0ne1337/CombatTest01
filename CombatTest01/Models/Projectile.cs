using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatTest01.Models
{
    public class Projectile : MovableEntity, IExecutableEntity
    {
        private const double DefaultSpeed = 30;
        private const double MaxDistance = 350;

        public Tank Owner { get; private set; }
        public double DistanceTravelled { get; private set; }
        public bool IsDead { get; private set; }

        public Projectile(EntityPosition position, Tank owner)
            : base(position, DefaultSpeed)
        {
            this.Owner = owner;
        }

        public void Execute()
        {
            if (this.IsDead == false)
            {
                DistanceTravelled += DefaultSpeed;

                EntityCollision collision = base.Move();

                if (collision != null && collision.TargetEntity != this.Owner)
                {
                    this.Kill();

                    if (collision.TargetEntity is Tank)
                        this.Owner.Score++;

                    return;
                }

                if (DistanceTravelled >= MaxDistance)
                    this.Kill();
            }            
        }

        public void Kill()
        {
            if (this.ParentCollection != null)
                this.ParentCollection.Remove(this);

            this.IsDead = true;
        }

        public bool IsValidCollision(Entity collisionEntity)
        {
            if (collisionEntity == this.Owner)
                return false;
            
            return true;
        }
    }
}
