using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace IntroductieProject.Code.View.GameEntities.Classes
{
    internal class Warrior : Character
    {
        public Warrior(Vector2 center, int width, int height, string assetName = "Steampunk") : base(center, width, height, assetName)
        {
            this.Health = 100;
            this.Damage = 10;
            this.MoveSpeed = 5;
        }
    }
}
