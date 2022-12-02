using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace IntroductieProject
{
    internal class RangedEnemy : ChasingEnemy
    {
        internal int range;
        internal string projectileName;
        internal List<Projectile> projectiles = new List<Projectile>();
        internal int shot = 30;

        internal RangedEnemy(Vector2 center, int width, int height, int range, int damage, int health, BaseLevel level, string assetName = "ChasingEnemy", string projectileName = "FireBall (0)") : base(center, width, height, damage, health, level, assetName)
        {
            this.range = range;
            this.projectileName = projectileName; 
        }

        internal override void update(GameTime time)
        {
            MouseState mouse = Mouse.GetState();
            Debug.Write(projectileName);
            if (shot <= 0)
            {
                Projectile p = new Projectile(centerPosition, 20, 20, new Vector2(level.player.centerPosition.X - centerPosition.X, level.player.centerPosition.Y - centerPosition.Y), 1, 10, projectileName, 500);
                projectiles.Add(p);
                shot = 60;
            }
            shot--; ;

            foreach (Projectile p in projectiles)
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

            foreach (Projectile p in projectiles)
                p.draw(batch);
        }
    }
}