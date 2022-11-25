using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;


namespace IntroductieProject
{
    internal class Assassin : Player
    {
        public Assassin(Vector2 center, int width, int height, string assetName = "Warrior") : base(center, width, height, assetName)
        {
            this.MaxHealth = 30;
            this.Damage = 30;
            this.MoveSpeed = 15;
            this.FireRate = 20;
        }
    }
}
