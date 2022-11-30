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
        public Warrior(Vector2 center, int width, int height) : base(center, width, height, "Characters/Warrior")
        {
            currentClass = characterType.warrior;

            this.MaxHealth = 125;
            this.Health = MaxHealth;
            this.DamageMultiplier = 1.5f;
            this.MoveSpeed = 2;
            this.FireRate = 10;

            specialAbilityCooldown = 30 * 1000;
            specialAbilityDuration = 5 * 1000;
        }

        public override void SpecialAbility()
        {
            CanTakeDamage = false;
            base.SpecialAbility();
        }

        protected override void ResetSpecialAbility()
        {
            CanTakeDamage = true;
            base.ResetSpecialAbility();
        }
    }
}
