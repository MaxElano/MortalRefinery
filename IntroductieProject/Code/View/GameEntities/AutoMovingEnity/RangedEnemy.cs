using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntroductieProject
{
    internal class RangedEnemy : ChasingEnemy
    {
        internal int range;
        internal List<projectile> projectiles = new List<projectile>();
        internal int shot = 30;

        internal RangedEnemy(Vector2 center, int width, int height, int range, int damage, int health, BaseLevel level, string assetName = "ChasingEnemy", string projectileName = "FireBall (0)") : base(center, width, height, damage, health, level, assetName)
        {
            this.range = range;
        }

        internal override void update(GameTime time)
        {
            MouseState mouse = Mouse.GetState();

            if (mouse.RightButton == ButtonState.Pressed && shot <= 0)
            {
                projectile p = new projectile(centerPosition, level.player.centerPosition);
                projectiles.Add(p);
                shot = 30;
            }
            shot--; ;

            foreach (projectile p in projectiles)
                p.update(time);

            base.update(time);
        }

        internal override void setdirection()
        {
            base.setdirection();

            Vector2 Distance = level.player.centerPosition - centerPosition;


            // if the player is in range stop moving
            if (Distance.Length() < range)
                stopMoving();
            else
                startMoving();
        }

        internal override void draw(SpriteBatch batch)
        {
            base.draw(batch);

            foreach (projectile p in projectiles)
                p.draw(batch);
        }
    }

    class projectile
    {
        int speed = 500;
        Vector2 Location;
        Texture2D sprite;
        Vector2 Direction;
        double angle;

        public projectile(Vector2 location, Vector2 target, string assetName = "FireBall (2)")
        {
            Location = location;
            sprite = Game.GameInstance.getSprite(assetName);
            setDirection(target);
        }

        void setDirection(Vector2 target)
        {
            Vector2 Distance = target - Location;
            angle = Math.Atan2(Distance.X, Distance.Y);

            angle = MathHelper.ToDegrees((float)angle);
            angle += 90;
            angle = MathHelper.ToRadians((float)angle);

            Direction.X = -(float)Math.Cos(angle);
            Direction.Y = (float)Math.Sin(angle);
        }

        public void update(GameTime gameTime)
        {
            Location.X += Direction.X * (float)gameTime.ElapsedGameTime.TotalSeconds * speed;
            Location.Y += Direction.Y * (float)gameTime.ElapsedGameTime.TotalSeconds * speed;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, Location, null, Color.White, (float)angle, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
