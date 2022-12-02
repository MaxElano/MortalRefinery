using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using Microsoft.Xna.Framework;

namespace IntroductieProject.Code.View.GameEntities.Weapons
{
    class LaserGun : Weapon
    {
        bool firstLaser = true;
        public LaserGun(Vector2 center, int width, int height, string assetName) : base(center, width = 48, height = 32, assetName)
        {
            weaponFireRate = 100;
            shotSpeed = 1;
            projectileSize = 20;
            gunRange = 10000;
            spreadStrength = 0;
            spriteName = "laser";
        }

        public override void Shoot(GameTime gameTime, List<Projectile> projectiles)
        {
            if (canShoot)
            {
                projectiles.RemoveAt(0);
                projectiles.Add(new Projectile(centerPosition + new Vector2(width/2, 0), (int)(10 + 0.10 * projectileSize), (int)(2000 + 0.10 * projectileSize), addSpread(new Vector2(InputManager.MouseState.Position.X - centerPosition.X - width / 2, InputManager.MouseState.Position.Y - centerPosition.Y - height / 2), spreadStrength), shotSpeed, 5, spriteName, gunRange));

                shootCooldown = (1 / weaponFireRate) * 1000;
                canShoot = false;
            }
        }
    }
}
