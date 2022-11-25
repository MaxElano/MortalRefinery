using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntroductieProject
{
    // ChasingEnemy, this enemy will just follow the player.
    internal class ChasingEnemy : Enemy
    {
        internal float angle;

        internal ChasingEnemy(Vector2 center, int width, int height, BaseLevel level, string assetName = "Giant_Bat") : base(center, width, height, level, assetName)
        {

        }

        internal override void update(GameTime time)
        {
            base.update(time);

            setdirection();
        }


        // calculate the direction to move in to reach the player.
        internal virtual void setdirection()
        {
            Vector2 Distance = level.player.centerPosition - centerPosition;

            angle = (float)Math.Atan2(Distance.X, Distance.Y);

            angle = MathHelper.ToDegrees(angle);
            angle += 90;
            angle = MathHelper.ToRadians(angle);

            direction.X = -(float)Math.Cos(angle);
            direction.Y = (float)Math.Sin(angle);

            if (level.player.getBoundingBox().Intersects(getBoundingBox()))
                stopMoving();
            else
                startMoving();

        }
    }
}
