using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntroductieProject
{
    // teh StaticRotatingEnemy Consist of al list of fireball that move around a central position;
    internal class StaticRotatingEnemy : Enemy
    {


        List<FireBall> ballLocations = new List<FireBall>();
        int range;
        float angle;
        internal StaticRotatingEnemy(Vector2 center, int width, int height, BaseLevel level, int size = 5, int range = 0, string assetName = "FireBall (2)") : base(center, width, height, level, assetName)
        {
            // Set the range and size of the enemy
            // the size is the ammount of fireballs
            // the range is de distand from the centre where the first fireball is. this way there can be a whole in the middle for the player to stand in safely.
            for (int i = 1; i < size + range; i++)
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
            // increase the angle
            angle++;

            // update each fireball
            for (int i = range; i < ballLocations.Count; i++)
            {
                ballLocations[i].update(angle);
            }

        }


        // get the boundingbox.
        // but only if the player touches any of the ball will the bouding box of the whole object be given.
        internal override Rectangle getBoundingBox()
        {
            bool hit = false;
            for (int i = range; i < ballLocations.Count; i++)
            {
                if (level.player.getBoundingBox().Intersects(ballLocations[i].Bounds))
                    hit = true;
            }

            if (hit)
                return base.getBoundingBox();
            else
                return ballLocations[0].Bounds;
        }

        internal override void draw(SpriteBatch batch)
        {
            //base.draw(batch);


            // draw each fireball.
            for (int i = range; i < ballLocations.Count; i++)
            {
                batch.Draw(ballLocations[i].texture, ballLocations[i].Bounds, Color.White);
            }
        }
    }


    // the fireball class
    class FireBall
    {
        public Rectangle rec;
        public Texture2D texture;
        public Vector2 location = Vector2.Zero;
        int nr;
        float angle;
        int width;
        int height;


        // the nr equal what number it is in the list.
        public FireBall(Vector2 location, int width, int height, int nr, string assetName = "FireBall (2)")
        {
            this.nr = nr;
            texture = Game.GameInstance.getSprite(assetName);
            this.location = location;

            this.width = width;
            this.height = height;
        }

        // bounds gives the BoundingBox of the fireball and a rectangle used to draw the fireball.
        public Rectangle Bounds
        {
            get
            {
                return new Rectangle((int)(location.X + (nr * texture.Width) * (float)Math.Sin(MathHelper.ToRadians(angle))) - width / 2, (int)(location.Y + (nr * texture.Height) * (float)Math.Cos(MathHelper.ToRadians(angle)) - height / 2), width, height);
            }
        }

        // update the angle which is used in the bounds method
        public void update(float angle)
        {
            this.angle = angle;
        }
    }
}