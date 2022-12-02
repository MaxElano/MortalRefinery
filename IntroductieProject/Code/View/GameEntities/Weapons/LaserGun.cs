using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using Microsoft.Xna.Framework;

namespace IntroductieProject.Code.View.GameEntities.Weapons
{
    class LaserGun : Weapon
    {
        public LaserGun(Vector2 center, int width, int height, string assetName, string bulletSpriteName) : base(center, width, height, assetName, bulletSpriteName)
        {
            weaponFireRate = 100;
            shotSpeed = 0;
            projectileSize = 20;
            gunRange = 3000;
            spreadStrength = 0;
        }

        public override void Shoot(GameTime gameTime, List<Projectile> projectiles)
        {
            if (canShoot)
            {
               // for(int i = 0; i <= 10; i++)
                //{
                    projectiles.Add(new Projectile(centerPosition, (int)(1000 + 0.10 * projectileSize), (int)(10 + 0.10 * projectileSize), addSpread(new Vector2((InputManager.MouseState.Position.X - centerPosition.X), (InputManager.MouseState.Position.Y - centerPosition.Y)), spreadStrength), shotSpeed, 5, spriteName, gunRange));
                //}

                /*foreach (Projectile p in projectiles)
                {
                    int counter = 1;
                    p.centerPosition = new Vector2(p.centerPosition.X + counter * p.width, p.centerPosition.Y + counter * p.height);
                    counter++;
                }*/
                   
                shootCooldown = (1 / weaponFireRate) * 10;
                canShoot = false;
            }
        }
    }
}
