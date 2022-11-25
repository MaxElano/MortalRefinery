using System;
using System.Collections.Generic;
using System.Text;

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

        public Item() : base (new Microsoft.Xna.Framework.Vector2(100,100), 32, 32, "damageUpSprite")
        {
            
        }
    }

    class damageUp : Item
    {
        public damageUp()
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
        healthUp()
        {
            Health = 1;
            Damage = 0;
            MoveSpeed = 0;
            MaxHealth = 1;
            name = "damage up";
        }
    }
}
