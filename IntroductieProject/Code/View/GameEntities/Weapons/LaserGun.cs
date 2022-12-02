using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace IntroductieProject.Code.View.GameEntities.Weapons
{
    class LaserGun : Weapon
    {
        bool isPressingSpace = false;

        public LaserGun(Vector2 center, int width, int height, string assetName = "LaserRifle") : base(center, width = 48, height = 32, assetName)
        {
            weaponFireRate = 100;
            shotSpeed = 0;
            projectileSize = 20;
            gunRange = 10000;
            spreadStrength = 0;
            spriteName = "laser";
        }

        public override void Shoot(GameTime gameTime, List<Projectile> projectiles)
        {
            if (canShoot)
            {
                projectiles.Add(new Projectile(centerPosition, (int)(5 + 0.10 * projectileSize), (int)(2000 + 0.10 * projectileSize), addSpread(new Vector2(InputManager.MouseState.Position.X - centerPosition.X, InputManager.MouseState.Position.Y - centerPosition.Y), spreadStrength), shotSpeed, 5, spriteName, gunRange));

                shootCooldown = (1 / weaponFireRate) * 1000;
                canShoot = false;
            }
        }
    }
}
