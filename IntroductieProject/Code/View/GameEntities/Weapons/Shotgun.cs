using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntroductieProject.Code.View.GameEntities.Weapons
{
    class Shotgun : Weapon
    {
        public Shotgun(Vector2 center, int width, int height, string assetName, string bulletSpriteName) : base(center, width, height, assetName, bulletSpriteName)
        {
            weaponFireRate = 0.5f;
            shotSpeed = 20;
            projectileSize = 1.5f;
            gunRange = 300;
            spreadStrength = 8;
        }

        public override void Shoot(GameTime gameTime, List<Projectile> projectiles)
        {
            if (canShoot)
            {
                for (int i = 0; i < 10; i++)
                {
                    projectiles.Add(new Projectile(centerPosition, (int)(10 * projectileSize), (int)(10 * projectileSize), addSpread(new Vector2(InputManager.MouseState.Position.X - centerPosition.X, InputManager.MouseState.Position.Y - centerPosition.Y), spreadStrength), shotSpeed, 5, spriteName, gunRange));
                }
                shootCooldown = (1 / weaponFireRate) * 1000;
                canShoot = false;
            }
        }
    }
}
