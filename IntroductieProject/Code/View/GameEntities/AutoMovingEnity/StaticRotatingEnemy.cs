using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntroductieProject
{
    internal class StaticRotatingEnemy : Enemy
    {
        List<FireBall> ballLocations = new List<FireBall>();
        int range;
        float angle;
        internal StaticRotatingEnemy(Vector2 center, int width, int height, BaseLevel level, int size = 10, int range = 0, string assetName = "FireBall (2)") : base(center, width, height, level, assetName)
        {
            for (int i = 1; i < size; i++)
            {
                if (i >= range)
                    ballLocations.Add(new FireBall(center, width * 16, height * 16, i));
                else
                    ballLocations.Add(null);
            }
            this.range = range;
            this.width = width * size * 32;
            this.height = height * size * 32;
        }

        internal override void update(GameTime time)
        {
            angle++;

            for (int i = range; i < ballLocations.Count; i++)
            {
                ballLocations[i].update(angle);
            }

        }

        internal override Rectangle getBoundingBox()
        {
            bool hit = false;
            for (int i = range; i < ballLocations.Count; i++)
            {
                foreach (GameEntity g in level.gameEntities)
                {
                    if (g != this)
                        if (g.getBoundingBox().Intersects(ballLocations[i].Bounds))
                            hit = true;
                }
            }
            if (hit)
                return base.getBoundingBox();
            else
                return ballLocations[0].Bounds;
        }

        internal override void draw(SpriteBatch batch)
        {
            //base.draw(batch);

            for (int i = range; i < ballLocations.Count; i++)
            {
                batch.Draw(ballLocations[i].texture, ballLocations[i].Bounds, Color.White);
            }
        }
    }

    class FireBall
    {
        public Rectangle rec;
        public Texture2D texture;
        public Vector2 location = Vector2.Zero;
        int nr;
        float angle;
        int width;
        int height;

        public FireBall(Vector2 location, int width, int height, int nr, string assetName = "FireBall (2)")
        {
            this.nr = nr;
            texture = Game.GameInstance.getSprite(assetName);
            this.location = location;

            this.width = width;
            this.height = height;
        }
        public Rectangle Bounds
        {
            get
            {
                return new Rectangle((int)(location.X + (nr * texture.Width) * (float)Math.Sin(MathHelper.ToRadians(angle))) - width / 2, (int)(location.Y + (nr * texture.Height) * (float)Math.Cos(MathHelper.ToRadians(angle)) - height / 2), width, height);
            }
        }
        public void update(float angle)
        {
            this.angle = angle;
        }
    }
}