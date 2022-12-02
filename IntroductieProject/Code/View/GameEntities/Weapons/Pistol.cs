using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace IntroductieProject
{
    class Pistol : Weapon
    {
        public Pistol(Vector2 center, int width, int height, string assetName) : base(center, width, height, assetName)
        {
            weaponFireRate = 5;
            shotSpeed = 10;
            projectileSize = 1;
            gunRange = 600;
            spreadStrength = 5;
            spriteName = "BlueProjectile";
        }
    }
}
