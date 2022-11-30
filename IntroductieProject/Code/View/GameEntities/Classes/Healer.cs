using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace IntroductieProject
{
    internal class Healer : Player
    {
        public Healer(Vector2 center, int width, int height, string assetName = "Healer") : base(center, width, height, "Characters/" + assetName)
        {
            currentClass = characterType.healer;

            this.MaxHealth = 100;
            this.Health = MaxHealth;
            this.DamageMultiplier = 1;
            this.MoveSpeed = 3;
            this.FireRate = 10;

            specialAbilityCooldown = 30 * 1000;
            specialAbilityDuration = 1 * 1000;
        }

        public override void SpecialAbility()
        {
            Heal(MaxHealth * 0.25f);
            base.SpecialAbility();
        }

        protected override void ResetSpecialAbility()
        {
            base.ResetSpecialAbility();
        }
    }
}
