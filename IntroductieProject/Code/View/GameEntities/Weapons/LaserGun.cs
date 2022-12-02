using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace IntroductieProject.Code.View.GameEntities.Weapons
{
    class LaserGun : Weapon
    {
        public LaserGun(Vector2 center, int width, int height, string assetName, string bulletSpriteName) : base(center, width, height, assetName, bulletSpriteName)
        {
            weaponFireRate = 500;
            shotSpeed = 100;
            projectileSize = 20;
            gunRange = 3000;
            spreadStrength = 0;
        }

        public override void Shoot(GameTime gameTime, List<Projectile> projectiles)
        {
            if (canShoot)
            {
                projectiles.Add(new Projectile(centerPosition, (int)(100 + 0.10 * projectileSize), (int)(100 + 0.10 * projectileSize), addSpread(new Vector2(InputManager.MouseState.Position.X - centerPosition.X - width / 2, InputManager.MouseState.Position.Y - centerPosition.Y - height / 2), spreadStrength), shotSpeed, 5, spriteName, gunRange));
                shootCooldown = (1 / weaponFireRate) * 1000;
                canShoot = false;
            }
        }
    }
}
