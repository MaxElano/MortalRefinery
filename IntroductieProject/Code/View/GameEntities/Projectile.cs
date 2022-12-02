using System;
using System.Collections.Generic;
using System.Reflection.Emit;
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

        internal float angle { get; set; }

        public float gunRange { get; protected set; }

        public Vector2 startPosition;

        public Projectile(Vector2 center, int width, int height, Vector2 direction, float moveSpeed, int damage, string assetName, float range) : base (center, width, height, "Projectiles/" + assetName)
        {
            this.DamageMultiplier = damage;
            this.MoveSpeed = moveSpeed;
            this.startMoving();
            IsAlive = true;
            Health = 1;
            this.direction = direction;
            this.gunRange = range;
            startPosition = center;
            RotationInDegress = AddRotation();
        }

        internal override void update(GameTime gameTime)
        {
            if (Vector2.Distance(startPosition, centerPosition) > gunRange)
            {
                Health = 0;
                Die(this);
            }
            base.update(gameTime);
        }

        internal float AddRotation()
        {
            RotationInDegress = (float)Math.Atan2(direction.X, direction.Y);

            RotationInDegress = MathHelper.ToDegrees(RotationInDegress);

            return -RotationInDegress;

        }

        protected override void Die(GameEntity entity)
        {
            base.Die(entity);
        }

        internal override void draw(SpriteBatch batch)
        {
            batch.Draw(sprite, getBoundingBox(), null, Color.White, MathHelper.ToRadians(RotationInDegress), new Vector2(0, 0), spriteEffect, 0f);
        }

        internal override Rectangle getBoundingBox()
        {
            return new Rectangle((int)this.centerPosition.X, (int)this.centerPosition.Y, width, height);
        }
    }
}
