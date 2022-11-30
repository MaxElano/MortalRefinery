using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntroductieProject.Code.View.GameEntities.Weapons
{
    class Minigun : Weapon
    {

        public Minigun(Vector2 center, int width, int height, string assetName, string bulletSpriteName) : base(center, width, height, assetName, bulletSpriteName)
        {
            weaponFireRate = 1f;
            shotSpeed = 15;
            projectileSize = 1f;
            gunRange = 900;
            spreadStrength = 6;
        }

        public override void Shoot(GameTime gameTime, List<Projectile> projectiles)
        {
            if (canShoot)
            {
                projectiles.Add(new Projectile(centerPosition, (int)(10 * projectileSize), (int)(10 * projectileSize), addSpread(new Vector2(InputManager.MouseState.Position.X - centerPosition.X, InputManager.MouseState.Position.Y - centerPosition.Y), spreadStrength), shotSpeed, 5, spriteName, gunRange));
                shootCooldown = (1 / (miniGunModifier * weaponFireRate)) * 1000;

                if(miniGunModifier < 9.5f)
                    miniGunModifier += 0.5f;

                canShoot = false;
            }

        }
    }
}
