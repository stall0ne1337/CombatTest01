using CombatTest01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatTest01
{
    public static class Extensions
    {
        public static bool IsColliding(this Entity entity, Entity targetEntity)
        {
            return IsColliding(entity, targetEntity.Position, targetEntity.CollisionDistanceX, targetEntity.CollisionDistanceY);
        }

        public static bool IsColliding(this Entity entity, EntityPosition targetEntityPosition, double targetEntityCollisionDistanceX, double targetEntityCollisionDistanceY)
        {
            double bottom = entity.Position.PosY + entity.CollisionDistanceY;
            double top = entity.Position.PosY;
            double left = entity.Position.PosX;
            double right = entity.Position.PosX + entity.CollisionDistanceX;

            return !((bottom < targetEntityPosition.PosY) ||
                     (top > targetEntityPosition.PosY + targetEntityCollisionDistanceY) ||
                     (left > targetEntityPosition.PosX + targetEntityCollisionDistanceX) ||
                     (right < targetEntityPosition.PosX));
        }
    }
}
