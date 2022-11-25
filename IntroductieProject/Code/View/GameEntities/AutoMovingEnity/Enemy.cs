using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntroductieProject
{
    internal class Enemy : GameEntity
    {
        internal BaseLevel level;

        internal Enemy(Vector2 center, int width, int height, BaseLevel level, string assetName = "Enemy") : base(center, width, height, assetName)
        {
            this.level = level;
        }
    }
}
