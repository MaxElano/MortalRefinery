using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace IntroductieProject
{
    class Sniper : Weapon
    {
        public Sniper(Vector2 center, int width, int height, string assetName, string bulletSpriteName) : base(center, width, height, assetName, bulletSpriteName)
        {
            weaponFireRate = 1;
            shotSpeed = 30;
            projectileSize = 2;
            gunRange = 5000;
            spreadStrength = 0;
        }
    }
}
