using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatTest01.Models
{
    public class EntityCollision
    {
        public Entity TargetEntity { get; private set; }

        public EntityCollision(Entity targetEntity)
        {
            this.TargetEntity = targetEntity;
        }
    }
}
