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
            currentClass = characterType.assassin;

            this.MaxHealth = 30;
            this.Health = MaxHealth;
            this.DamageMultiplier = 2;
            this.MoveSpeed = 15;
            this.FireRate = 20;

            specialAbilityCooldown = 20 * 1000;
            specialAbilityDuration = 10 * 1000;
        }
        public override void SpecialAbility()
        {
            DamageMultiplier *= 2;
            base.SpecialAbility();
        }
        protected override void ResetSpecialAbility()
        {
            DamageMultiplier /= 2;
            base.ResetSpecialAbility();
        }
    }
}
