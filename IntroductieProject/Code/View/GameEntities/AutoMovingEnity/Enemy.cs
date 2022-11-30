using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntroductieProject
{

    // Basic Enemy class
    // each enemy will be a subclass fo this class
    internal class Enemy : GameEntity
    {
        internal BaseLevel level;

        internal Enemy(Vector2 center, int width, int height, int damage, int health, BaseLevel level, string assetName = "Enemy") : base(center, width, height, assetName)
        {
            this.level = level;
            this.DamageMultiplier = damage;
            this.Health = health;
        }
    }
}
