using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace IntroductieProject
{
    internal class Warrior : Player
    {
        public Warrior(Vector2 center, int width, int height, string assetName = "Warrior") : base(center, width, height, assetName)
        {
            this.MaxHealth = 100;
            this.Damage = 10;
            this.MoveSpeed = 5;
            this.FireRate = 10;
        }
    }
}
