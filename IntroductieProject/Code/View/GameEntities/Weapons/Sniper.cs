using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace IntroductieProject
{
    class Sniper : Weapon
    {
        public Sniper(Vector2 center, int width, int height, string assetName = "Sniper") : base(center, width = 48, height = 32, assetName)
        {
            weaponFireRate = 1;
            shotSpeed = 30;
            projectileSize = 2;
            gunRange = 5000;
            spreadStrength = 0;
            spriteName = "BlueProjectile";
        }
    }
}
