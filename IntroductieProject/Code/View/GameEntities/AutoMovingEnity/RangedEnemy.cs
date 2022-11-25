using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntroductieProject
{
    internal class RangedEnemy : ChasingEnemy
    {
        internal int range;
        internal RangedEnemy(Vector2 center, int width, int height, int range, BaseLevel level, string assetName = "ChasingEnemy") : base(center, width, height, level, assetName)
        {
            this.range = range;
        }

        internal override void setdirection()
        {
            base.setdirection();

            Vector2 Distance = level.player.centerPosition - centerPosition;

            if (Distance.Length() < range)
                stopMoving();
            else
                startMoving();
        }
    }
}
