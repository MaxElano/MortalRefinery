using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace IntroductieProject
{
    internal class Projectile : GameEntity
    {
        public Projectile(Vector2 center, int width, int height, Vector2 direction, int moveSpeed, int damage, string assetName = "Bullet1") : base (center, width, height, assetName)
        {
            this.Damage = damage;
            this.MoveSpeed = moveSpeed;
            this.startMoving();
            Console.WriteLine("PROJECTILE");
            IsAlive = true;
            Health = 1;
            this.direction = direction;
        }

        internal override void update(GameTime gameTime)
        {
            base.update(gameTime);
        }
    }
}
