using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntroductieProject.Code.View.GameEntities
{
    internal class Orbital : GameEntity
    {
        public Vector2 rotationPosition;
        public int degree = 0;
        public int orbitalDistanceFromTarget;
        public int orbitalSpeed;

        public Orbital(int distanceFromTarget, Vector2 center, int width, int height, int moveSpeed, int damage, string assetName = "damageUpSprite") : base(center, width, height, assetName)
        {
            this.DamageMultiplier = damage;
            this.MoveSpeed = moveSpeed;
            orbitalDistanceFromTarget = distanceFromTarget;
            orbitalSpeed = moveSpeed;
        }

        internal override void update(GameTime gameTime)
        {
            base.update(gameTime);
        }

        internal void updatePosition(Vector2 position)
        {
            rotationPosition = rotateEntity(degree, orbitalDistanceFromTarget);
            degree += orbitalSpeed;
            if (degree >= 360)
                degree = 0;
            centerPosition = position + rotationPosition;
        }
    }
}
