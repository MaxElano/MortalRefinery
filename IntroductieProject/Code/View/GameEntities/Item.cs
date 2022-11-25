using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace IntroductieProject
{
    class Item : GameObject
    {
        public enum itemTypes
        {
            passive,
            active,
            orbital,
            test
        }

        public itemTypes type;

        public string name { get; protected set; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public float MoveSpeed { get; protected set; }
        public int MaxHealth { get; protected set; }

        public Item(Vector2 center, int width, int height, string assetName) : base (center, width, height, assetName)
        {
            
        }
    }

    class damageUp : Item
    {
        public damageUp(Vector2 center, int width, int height, string assetName) : base(center, width, height, assetName)
        {
            Health = 0;
            Damage = 1;
            MoveSpeed = 0;
            MaxHealth = 0;
            name = "damage up";
        }
    }

    class healthUp : Item
    {
        public healthUp(Vector2 center, int width, int height, string assetName) : base(center, width, height, assetName)
        {
            Health = 1;
            Damage = 0;
            MoveSpeed = 0;
            MaxHealth = 1;
            name = "damage up";
        }
    }
}
