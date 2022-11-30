using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace IntroductieProject
{
    internal class Projectile : GameEntity
    {
        public float gunRange { get; protected set; }
        public Vector2 startPosition;

        public Projectile(Vector2 center, int width, int height, Vector2 direction, float moveSpeed, int damage, string assetName, float range) : base (center, width, height, "Projectiles/" + assetName)
        {
            this.Damage = damage;
            this.MoveSpeed = moveSpeed;
            this.startMoving();
            IsAlive = true;
            Health = 1;
            this.direction = direction;
            this.gunRange = range;
            startPosition = center;
        }

        internal override void update(GameTime gameTime)
        {
            if (Vector2.Distance(startPosition, centerPosition) > gunRange)
                Die(this);
            base.update(gameTime);
        }

        protected override void Die(GameEntity entity)
        {
            base.Die(entity);
        }
    }
}
